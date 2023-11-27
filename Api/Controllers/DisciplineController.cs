using Api.Context;
using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class DisciplineController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<DisciplineViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Disciplines
            .AsNoTracking()
            .ProjectTo<DisciplineViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }
}