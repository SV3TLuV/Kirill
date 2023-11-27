using Api.Context;
using Api.Models;
using Api.Models.Semesters;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class SemesterController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<SemesterViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Semesters
            .AsNoTracking()
            .OrderBy(e => e.Id)
            .ProjectTo<SemesterViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }
}