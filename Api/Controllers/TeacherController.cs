using Api.Context;
using Api.Models;
using Api.Models.Groups;
using Api.Models.TeacherGroups;
using Api.Models.Teachers;
using Api.Models.Teachers.Commands;
using Api.Models.Teachers.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class TeacherController(IMapper mapper) : BaseController
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TeacherViewModel>> Get(
        int id,
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Teachers
            .AsNoTracking()
            .Include(e => e.User)
            .ThenInclude(e => e.Role)
            .ProjectTo<TeacherViewModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(e => e.Id == id));
    }

    [HttpGet("{id:int}/groups")]
    public async Task<ActionResult<GroupViewModel[]>> Get(
        int id,
        [FromQuery] GetTeacherGroupsQuery query,
        [FromServices] ApiDbContext context)
    {
        var groupsQuery = context.Groups
            .Include(e => e.Course)
            .Include(e => e.Semester)
            .Include(e => e.TeacherGroups)
            .Where(e => e.TeacherGroups
                .Select(e => e.TeacherId)
                .Contains(id))
            .AsNoTracking();

        if (query.CourseId is not null)
        {
            groupsQuery = groupsQuery.Where(e => e.CourseId == query.CourseId);
        }

        if (query.SemesterId is not null)
        {
            groupsQuery = groupsQuery.Where(e => e.SemesterId == query.SemesterId);
        }

        return Ok(await groupsQuery
            .ProjectTo<GroupViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }

    [HttpGet]
    public async Task<ActionResult<TeacherViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Teachers
            .AsNoTracking()
            .Include(e => e.User)
            .ThenInclude(e => e.Role)
            .ProjectTo<TeacherViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult> Post(
        [FromBody] CreateTeacherCommand command,
        [FromServices] ApiDbContext context)
    {
        var teacher = mapper.Map<Teacher>(command);
        teacher.User.RoleId = 2;

        await context.AddAsync(teacher);
        await context.SaveChangesAsync();
        
        if (command.GroupIds is not null)
        {
            var teacherGroups = command.GroupIds
                .Select(groupId => new TeacherGroup
                {
                    TeacherId = teacher.Id,
                    GroupId = groupId,
                });

            await context.AddRangeAsync(teacherGroups);
        }

        await context.SaveChangesAsync();

        return Created(string.Empty, teacher.Id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(
        int id,
        [FromBody] UpdateTeacherCommand command,
        [FromServices] ApiDbContext context)
    {
        var teacher = await context.Teachers
            .Include(teacher => teacher.User)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (teacher is null)
        {
            return NotFound();
        }

        if (command.GroupIds is not null)
        {
            await context.TeacherGroups
                .Where(e => e.TeacherId == id)
                .AsNoTracking()
                .ExecuteDeleteAsync();

            var teacherGroups = command.GroupIds
                .Select(groupId => new TeacherGroup
                {
                    TeacherId = teacher.Id,
                    GroupId = groupId,
                });

            await context.AddRangeAsync(teacherGroups);
        }

        teacher.User.Login = command.Login;
        teacher.User.Name = command.Name;
        teacher.User.Surname = command.Surname;
        teacher.User.Patronymic = command.Patronymic;

        context.Update(teacher);
        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(
        int id,
        [FromServices] ApiDbContext context)
    {
        var teacher = await context.Teachers
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (teacher is null)
        {
            return NotFound();
        }

        context.Remove(teacher);
        await context.SaveChangesAsync();

        return Ok();
    }
}