using AzureTest.DTOs.Requests.Auth;
using AzureTest.Entities;
using AzureTest.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzureTest.Controllers;

[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    [HttpGet]
    //[Authorize]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return Ok(await _usersService.GetUsers());
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post([FromBody] CreateUserRequest user)
    {
        try
        {
            await _usersService.AddUser(user);

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<User>> Delete([FromRoute] int id)
    {
        try
        {
            await _usersService.DeleteUser(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}