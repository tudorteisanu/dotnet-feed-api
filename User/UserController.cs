using feedApi.User.dto;
using Microsoft.AspNetCore.Mvc;

namespace feedApi.Users;

[ApiController]
[Route("[controller]")]
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
}

