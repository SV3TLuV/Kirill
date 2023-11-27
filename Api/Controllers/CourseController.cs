using Api.Context;
using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class CourseController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<CourseViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Courses
            .AsNoTracking()
            .ProjectTo<CourseViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }
}

public sealed class StudentController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<StudentViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Courses
            .AsNoTracking()
            .ProjectTo<CourseViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }
}