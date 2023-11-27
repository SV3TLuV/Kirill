using Api.Context;
using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class WorkController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<WorkViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Works
            .AsNoTracking()
            .Include(e => e.WorkType)
            .Include(e => e.Tasks)
            .Include(e => e.WorkMarks)
            .ThenInclude(e => e.Mark)
            .ProjectTo<WorkViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }
}