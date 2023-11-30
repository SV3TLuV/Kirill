using Api.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[EnableCors(Constants.CorsName)]
[Route("/api/[controller]")]
public abstract class BaseController : ControllerBase
{
}