using Api.Context;
using Api.Models;
using Api.Models.GroupDisciplines;
using Api.Models.Groups;
using Api.Models.Groups.Commands;
using Api.Models.Students;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class GroupController(IMapper mapper) : BaseController
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GroupViewModel[]>> Get(
        int id,
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Groups
            .AsNoTracking()
            .Include(e => e.Course)
            .Include(e => e.Semester)
            .Include(e => e.GroupDisciplines)
            .ProjectTo<GroupViewModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(e => e.Id == id));
    }

    [HttpGet("{id:int}/students")]
    public async Task<ActionResult<StudentViewModel>> GetStudents(
        int id,
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Students
            .AsNoTracking()
            .Include(e => e.User)
            .Include(e => e.Group)
            .Where(e => e.GroupId == id)
            .ProjectTo<StudentViewModel>(mapper.ConfigurationProvider)
            .OrderBy(e => e.IsRetired)
            .FirstOrDefaultAsync(e => e.Id == id));
    }

    [HttpGet]
    public async Task<ActionResult<GroupViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Groups
            .AsNoTracking()
            .Include(e => e.Course)
            .Include(e => e.Semester)
            .Include(e => e.GroupDisciplines)
            .ProjectTo<GroupViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult> Post(
        [FromBody] GroupCommand command,
        [FromServices] ApiDbContext context)
    {
        var group = mapper.Map<Group>(command);

        await context.AddAsync(group);

        if (command.DisciplineIds is not null)
        {
            var groupDisciplines = command.DisciplineIds
                .Select(disciplineId => new GroupDiscipline
                {
                    GroupId = group.Id,
                    DisciplineId = disciplineId,
                });

            await context.AddRangeAsync(groupDisciplines);
        }

        await context.SaveChangesAsync();

        return Created(string.Empty, group.Id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(
        int id,
        [FromBody] GroupCommand command,
        [FromServices] ApiDbContext context)
    {
        var group = await context.Groups
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (group is null)
        {
            return NotFound();
        }

        if (command.DisciplineIds is not null)
        {
            await context.GroupDisciplines
                .Where(e => e.GroupId == id)
                .AsNoTracking()
                .ExecuteDeleteAsync();

            var groupDisciplines = command.DisciplineIds
                .Select(disciplineId => new GroupDiscipline
                {
                    GroupId = group.Id,
                    DisciplineId = disciplineId,
                });

            await context.AddRangeAsync(groupDisciplines);
        }

        group.Name = command.Name;
        group.Year = command.Year;
        group.CourseId = command.CourseId;
        group.SemesterId = command.SemesterId;

        context.Update(group);
        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(
        int id,
        [FromServices] ApiDbContext context)
    {
        var group = await context.Groups
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (group is null)
        {
            return NotFound();
        }

        context.Remove(group);
        await context.SaveChangesAsync();

        return Ok();
    }
}