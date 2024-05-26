using Microsoft.AspNetCore.Mvc;

namespace LispInterpreter;

[ApiController]
[Route("api/[controller]")]
public class InterpreterController : ControllerBase
{

    [HttpGet()]
    public async Task<IActionResult> Parse([FromQuery] string expression, CancellationToken cancellationToken = default)
    {

    }
}