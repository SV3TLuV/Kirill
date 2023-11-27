using Api.Context;
using Api.Entities;
using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class WorkTypeController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<WorkType[]>> Get(
        [FromServices] ApiDbContext context)
    {
        return Ok(await context.WorkTypes
            .AsNoTracking()
            .ProjectTo<WorkTypeViewModel>(mapper.ConfigurationProvider)
            .ToListAsync());
    }
}