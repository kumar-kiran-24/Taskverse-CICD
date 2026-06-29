using System.Net.Mime;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Taskverse.Api.Controllers;

public record SystemModel
{
    public string? AssemblyName { get; init; }
    public string? AssemblyVersion { get; init; }
}


[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SystemController : Controller
{
    // TODO: Remove this temporary endpoint once the API is ready
    [AllowAnonymous]
    [HttpGet("status")]
    [SwaggerResponse(200, Type = typeof(string))]
    public IActionResult GetStatus()
    {
        return Ok("API is under construction");
    }

    [HttpGet]
    [SwaggerResponse(200, Type = typeof(SystemModel))]
    public IActionResult Get()
    {
        var assembly = Assembly.GetEntryAssembly();

        var model = new SystemModel
        {
            AssemblyName = assembly?.GetName().Name,
            AssemblyVersion = assembly?.GetName().Version?.ToString()
        };

        return Ok(model);
    }
}
