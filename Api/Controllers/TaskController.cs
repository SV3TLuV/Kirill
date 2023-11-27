using Api.Context;
using Api.Models.Tasks;
using Api.Models.Tasks.Commands;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = Api.Models.Tasks.Task;

namespace Api.Controllers;

public sealed class TaskController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<TaskViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.WorkTypes
            .AsNoTracking()
            .ProjectTo<TaskViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult> Post(
        [FromBody] TaskCommand command,
        [FromServices] ApiDbContext context)
    {
        var task = mapper.Map<Task>(command);

        await context.AddAsync(task);
        await context.SaveChangesAsync();

        return Created(string.Empty, task.Id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(
        int id,
        [FromBody] TaskCommand command,
        [FromServices] ApiDbContext context)
    {
        var task = await context.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (task is null)
        {
            return NotFound();
        }

        task.WorkId = command.WorkId;
        task.Title = command.Title;
        task.Description = command.Description;

        context.Update(task);
        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(
        int id,
        [FromServices] ApiDbContext context)
    {
        var task = await context.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (task is null)
        {
            return NotFound();
        }

        context.Remove(task);
        await context.SaveChangesAsync();

        return Ok();
    }
}