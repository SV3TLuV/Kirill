using Api.Context;
using Api.Models;
using Api.Models.Groups;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class GroupController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GroupViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Groups
            .AsNoTracking()
            .Include(e => e.Course)
            .Include(e => e.Semester)
            .Include(e => e.Disciplines)
            .ProjectTo<GroupViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }
}