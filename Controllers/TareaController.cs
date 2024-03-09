using ApisConPuntoNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApisConPuntoNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{

    ITareasService tareasService;

    public TareaController(ITareasService service)
    {
        tareasService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareasService.Get());
    }

}