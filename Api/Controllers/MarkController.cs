using Api.Context;
using Api.Models.Marks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class MarkController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<MarkViewModel[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.Marks
            .AsNoTracking()
            .OrderBy(e => e.Id)
            .ProjectTo<MarkViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }
}