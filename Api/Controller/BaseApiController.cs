using Microsoft.AspNetCore.Mvc;

namespace Stgen.Api.Controller;

[ApiController]
public abstract class BaseApiController : ControllerBase
{

    protected ILogger? _logger;
    protected async Task<ActionResult<T>> HandleHttpCode<T>(Func<Task<T>> func)
    {
        try
        {
            var result = await func.Invoke();
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger!.LogError("Exception:", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}