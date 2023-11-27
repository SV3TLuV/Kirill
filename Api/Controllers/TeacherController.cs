using Api.Context;
using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class TeacherController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<TeacherViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Teachers
            .AsNoTracking()
            .Include(e => e.User)
            .Include(e => e.Groups)
            .ProjectTo<TeacherViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }
}