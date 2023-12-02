using EHA.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "divide")]
    public IActionResult Calc([FromBody] DivideRequest request)
    {
        var result = Calculator.Divide(request.X, request.Y);

        return result.Match<IActionResult>(left =>
        {
            _logger.LogError(left.Message);
            return BadRequest(left.Message);
        }
        , right => Ok(right));
    }
}
