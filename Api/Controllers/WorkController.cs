using Api.Context;
using Api.Models.WorkMarks;
using Api.Models.Works;
using Api.Models.Works.Commands;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class WorkController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<WorkViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Works
            .AsNoTracking()
            .Include(e => e.WorkType)
            .Include(e => e.Tasks)
            .Include(e => e.WorkMarks)
            .ThenInclude(e => e.Mark)
            .ProjectTo<WorkViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }
    
    [HttpPost]
    public async Task<ActionResult> Post(
        [FromBody] CreateWorkCommand command,
        [FromServices] ApiDbContext context)
    {
        var work = mapper.Map<Work>(command);

        await context.Works.AddAsync(work);
        await context.SaveChangesAsync();
        
        return Created(string.Empty, work.Id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(
        int id,
        [FromBody] UpdateWorkCommand command,
        [FromServices] ApiDbContext context)
    {
        var work = await context.Works
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();

        if (work is null)
        {
            return NotFound();
        }

        if (command.WorkMarks is not null)
        {
            await context.WorkMarks
                .Where(e => e.WorkId == id)
                .AsNoTracking()
                .ExecuteDeleteAsync();

            var workMarks = mapper.Map<ICollection<WorkMark>>(command.WorkMarks);
                
            foreach (var workMark in workMarks)
            {
                workMark.WorkId = id;
            }

            await context.AddRangeAsync(workMarks);
        }

        work.Name = command.Name;
        work.WorkTypeId = command.WorkTypeId;

        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(
        int id,
        [FromServices] ApiDbContext context)
    {
        var work = await context.Works
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (work is null)
        {
            return NotFound();
        }

        context.Remove(work);
        await context.SaveChangesAsync();

        return Ok();
    }
}