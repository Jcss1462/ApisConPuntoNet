using Microsoft.AspNetCore.Mvc;

namespace ApisConPuntoNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWoldController : ControllerBase
{

    IHelloWorldService helloWorldService;

    private readonly ILogger<HelloWoldController> _logger;

    public HelloWoldController(IHelloWorldService helloWorld,ILogger<HelloWoldController> logger)
    {
        helloWorldService = helloWorld;
        _logger = logger;
    }

    public IActionResult Get()
    {
        //_logger.LogError("Probando error");
        return Ok(helloWorldService.GetHelloWorld());
    }


}