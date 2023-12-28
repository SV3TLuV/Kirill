using Api.Context;
using Api.Models.CompletedWorks;
using Api.Models.Students;
using Api.Models.Students.Commands;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClosedXML.Excel;
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

    [HttpGet("xlsx")]
    public async Task<IResult> GetXlsx(
        [FromServices] ApiDbContext context)
    {
        const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        const string fileName = "students.xlsx";

        using var book = new XLWorkbook();

        await using var memory = new MemoryStream();
        var students = await context.Students
            .Include(e => e.Group)
            .Include(e => e.User)
            .OrderByDescending(e => e.IsRetired)
            .AsNoTracking()
            .ProjectTo<StudentViewModel>(mapper.ConfigurationProvider)
            .ToArrayAsync();

        book.AddWorksheet("Students");
        var worksheet = book.Worksheets.Last();

        worksheet.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        worksheet.Style.Border.OutsideBorder = XLBorderStyleValues.None;
        worksheet.Style.Alignment.WrapText = true;
        worksheet.Style.Font.FontSize = 16;
        worksheet.ColumnWidth = 60;

        worksheet.Cell("A1").Value = "Логин";
        worksheet.Cell("B1").Value = "Имя";
        worksheet.Cell("C1").Value = "Фамилия";
        worksheet.Cell("D1").Value = "Отчество";
        worksheet.Cell("E1").Value = "Группа";
        worksheet.Cell("F1").Value = "Отчислен";

        var row = 2;

        foreach (var student in students)
        {
            var range = worksheet.Range(row, 1, row, 6);

            var cell = range.FirstCell();
            cell.Value = student.User.Login;

            cell = cell.CellRight();
            cell.Value = student.User.Name;

            cell = cell.CellRight();
            cell.Value = student.User.Surname;

            cell = cell.CellRight();
            cell.Value = student.User.Patronymic;

            cell = cell.CellRight();
            cell.Value = student.Group.Name;

            cell = cell.CellRight();
            cell.Value = student.IsRetired;

            row++;
        }

        book.SaveAs(memory);
        var content = memory.ToArray();

        return Results.File(content, contentType, fileName);
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