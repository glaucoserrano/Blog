using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
public class AcountController : ControllerBase
{

    [HttpPost("v1/acounts")]
    public async Task<IActionResult> Post([FromBody]RegisterViewModel model, [FromServices]BlogDataContext context)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var user = new User
        {
            Name = model.Name,
            Email = model.Email,
            Slug = model.Email.Replace("@", "-").Replace(".", "-")
        };

        return Ok();
    } 
    [HttpPost("v1/acounts/login")]
    public IActionResult Login([FromServices] TokenService tokenService)
    {
        
        var token = tokenService.GenerateToken(null);

        return Ok(token);

    }
}
