using feedApi.User.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace feedApi.Users;

[Authorize]
[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        this.userService = userService;
    }

    [HttpGet(Name = "FindUsers")]
    public IEnumerable<User> FindAll()
    {
        return  this.userService.Find();
    }


    [HttpPost(Name = "CreateUser")]
    public User Create([FromBody] User user)
    {
        return this.userService.Create(user);
    }

    [HttpGet("{id}")]
    public ActionResult<User> FindOne([FromRoute] int id)
    {
        var user = this.userService.FindOne(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;

    }

    [HttpPatch("{id}")]
    public ActionResult<User> FindOne([FromRoute] int id, [FromBody] User payload)
    {
        var user = this.userService.Update(id, payload);

        if (user is null)
        {
            return NotFound();
        }

        return user;

    }
}

