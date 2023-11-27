using Api.Context;
using Api.Models;
using Api.Models.Courses;
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
            .OrderBy(e => e.Id)
            .ProjectTo<CourseViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }
}