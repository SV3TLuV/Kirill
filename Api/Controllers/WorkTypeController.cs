using Api.Context;
using Api.Models;
using Api.Models.WorkTypes;
using Api.Models.WorkTypes.Commands;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class WorkTypeController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<WorkTypeViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.WorkTypes
            .AsNoTracking()
            .ProjectTo<WorkTypeViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult> Post(
        [FromBody] WorkTypeCommand command,
        [FromServices] ApiDbContext context)
    {
        var workType = mapper.Map<WorkType>(command);

        await context.AddAsync(workType);
        await context.SaveChangesAsync();

        return Created(string.Empty, workType.Id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(
        int id,
        [FromBody] WorkTypeCommand command,
        [FromServices] ApiDbContext context)
    {
        var workType = await context.WorkTypes
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (workType is null)
        {
            return NotFound();
        }

        workType.Name = command.Name;

        context.Update(workType);
        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(
        int id,
        [FromServices] ApiDbContext context)
    {
        var workType = await context.WorkTypes
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (workType is null)
        {
            return NotFound();
        }

        context.Remove(workType);
        await context.SaveChangesAsync();

        return Ok();
    }
}