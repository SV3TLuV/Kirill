using Api.Context;
using Api.Models.CompletedWorks;
using Api.Models.Students;
using Api.Models.Students.Commands;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class StudentController(IMapper mapper) : BaseController
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<StudentViewModel>> Get(
        int id,
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Students
            .Include(e => e.User)
            .ThenInclude(e => e.Role)
            .Include(e => e.Group)
            .AsNoTracking()
            .ProjectTo<StudentViewModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(e => e.Id == id));
    }

    [HttpGet("{id:int}/completed_works")]
    public async Task<ActionResult<CompletedWorkViewModel[]>> GetCompletedWorks(
        int id,
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.CompletedWorks
            .AsNoTracking()
            .Include(e => e.Mark)
            .Include(e => e.Work)
            .ThenInclude(e => e.Tasks)
            .Include(e => e.Work)
            .ThenInclude(e => e.WorkType)
            .Include(e => e.Work)
            .ThenInclude(e => e.WorkMarks)
            .ThenInclude(e => e.Mark)
            .Where(e => e.StudentId == id)
            .ProjectTo<CompletedWorkViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }

    [HttpGet]
    public async Task<ActionResult<StudentViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Students
            .Include(e => e.User)
            .ThenInclude(e => e.Role)
            .Include(e => e.Group)
            .AsNoTracking()
            .ProjectTo<StudentViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult> Post(
        [FromBody] CreateStudentCommand command,
        [FromServices] ApiDbContext context)
    {
        var student = mapper.Map<Student>(command);
        student.User.RoleId = 1;

        await context.AddAsync(student);
        await context.SaveChangesAsync();

        return Created(string.Empty, student.Id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(
        int id,
        [FromBody] UpdateStudentCommand command,
        [FromServices] ApiDbContext context)
    {
        var student = await context.Students
            .AsNoTracking()
            .Include(student => student.User)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (student is null)
        {
            return NotFound();
        }

        student.User.Login = command.Login;
        student.User.Name = command.Name;
        student.User.Surname = command.Surname;
        student.User.Patronymic = command.Patronymic;
        student.GroupId = command.GroupId;
        student.IsRetired = command.IsRetired;

        context.Update(student);
        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(
        int id,
        [FromServices] ApiDbContext context)
    {
        var student = await context.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (student is null)
        {
            return NotFound();
        }

        context.Remove(student);
        await context.SaveChangesAsync();

        return Ok();
    }
}