using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stgen.Api.Auth;
using Stgen.Application.Command;
using Stgen.Domain.Entities;

namespace Stgen.Api.Controller;
[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;
    public AuthController(UserManager<ApplicationUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterUser user)
    {
        var result = await _userManager.CreateAsync(
            new ApplicationUser { UserName = user.Username, Email = user.Email },
            user.Password
        );
        if (result.Succeeded)
        {
            return Ok();
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }
        return BadRequest(ModelState);
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginUser user)
    {
        var managedUser = await _userManager.FindByEmailAsync(user.Email);
        if (managedUser == null)
        {
            return BadRequest("Bad credentials");
        }
        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, user.Password);
        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }
        var accessToken = _tokenService.CreateToken(managedUser);
        return Ok(accessToken);
    }
}