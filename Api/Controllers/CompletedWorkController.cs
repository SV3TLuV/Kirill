using Api.Context;
using Api.Models.CompletedWorks;
using Api.Models.CompletedWorks.Commands;
using Api.Models.CompletedWorkTasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class CompletedWorkController(IMapper mapper) : BaseController
{
    [HttpPost]
    public async Task<ActionResult> Post(
        [FromBody] CompletedWorkCommand command,
        [FromServices] ApiDbContext context)
    {
        var work = await context.Works
            .AsNoTracking()
            .Include(e => e.WorkMarks)
            .Include(e => e.Tasks)
            .FirstOrDefaultAsync(e => e.Id == command.WorkId);

        if (work is null)
            return NotFound($"Work with id: {command.WorkId}");

        var completedWork = mapper.Map<CompletedWork>(command);
        completedWork.Percentage = (int)(100d / work.Tasks!.Count) * completedWork.CompletedTasks.Count;
        completedWork.MarkId = work.WorkMarks
            .FirstOrDefault(e => e.TaskCount == completedWork.CompletedTasks.Count)
            ?.MarkId;

        await context.AddAsync(completedWork);
        await context.SaveChangesAsync();

        foreach (var taskId in command.CompletedTaskIds)
        {
            await context.AddAsync(new CompletedWorkTask
            {
                CompletedWorkId = completedWork.Id,
                TaskId = taskId,
            });
        }

        await context.SaveChangesAsync();

        return Created(string.Empty, completedWork.Id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(
        int id,
        [FromBody] CompletedWorkCommand command,
        [FromServices] ApiDbContext context)
    {
        var completedWork = await context.CompletedWorks
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (completedWork is null)
        {
            return NotFound();
        }

        var work = await context.Works
            .AsNoTracking()
            .Include(e => e.WorkMarks)
            .Include(e => e.Tasks)
            .FirstOrDefaultAsync(e => e.Id == command.WorkId);

        if (work is null)
            return NotFound($"Work with id: {command.WorkId}");

        await context.CompletedWorkTasks
            .AsNoTracking()
            .Where(e => e.CompletedWorkId == id)
            .ExecuteDeleteAsync();

        foreach (var taskId in command.CompletedTaskIds)
        {
            await context.AddAsync(new CompletedWorkTask
            {
                CompletedWorkId = completedWork.Id,
                TaskId = taskId,
            });
        }

        completedWork.Percentage = (int)(100d / work.Tasks!.Count) * command.CompletedTaskIds.Count;
        completedWork.MarkId = work.WorkMarks
            .FirstOrDefault(e => e.TaskCount == command.CompletedTaskIds.Count)
            ?.MarkId;

        context.Update(completedWork);
        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(
        int id,
        [FromServices] ApiDbContext context)
    {
        var completedWork = await context.CompletedWorks
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (completedWork is null)
        {
            return NotFound();
        }

        context.Remove(completedWork);
        await context.SaveChangesAsync();

        return Ok();
    }
}