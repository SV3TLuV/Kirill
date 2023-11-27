using Api.Context;
using Api.Models.Disciplines;
using Api.Models.Disciplines.Commands;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class DisciplineController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<DisciplineViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Disciplines
            .AsNoTracking()
            .ProjectTo<DisciplineViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult> Post(
        [FromBody] DisciplineCommand command,
        [FromServices] ApiDbContext context)
    {
        var discipline = mapper.Map<Discipline>(command);

        await context.AddAsync(discipline);
        await context.SaveChangesAsync();

        return Created(string.Empty, discipline.Id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(
        int id,
        [FromBody] DisciplineCommand command,
        [FromServices] ApiDbContext context)
    {
        var discipline = await context.Disciplines
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (discipline is null)
        {
            return NotFound();
        }

        discipline.Name = command.Name;

        context.Update(discipline);
        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(
        int id,
        [FromServices] ApiDbContext context)
    {
        var discipline = await context.Disciplines
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (discipline is null)
        {
            return NotFound();
        }

        context.Remove(discipline);
        await context.SaveChangesAsync();

        return Ok();
    }
}