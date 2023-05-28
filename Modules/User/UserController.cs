using AutoMapper;
using feedApi.Users.dto;
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
    private readonly IMapper mapper;

    public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
    {
        _logger = logger;
        this.userService = userService;
        this.mapper = mapper;
    }

    [HttpGet(Name = "FindUsers")]
    public IEnumerable<UserResponseDto> FindAll()
    {
        return  this.userService.Find().Select(this.mapper.Map<UserResponseDto>);
    }


    [HttpPost(Name = "CreateUser")]
    public UserResponseDto Create([FromBody] CreateUserDto createUserDto)
    {
        var user = this.mapper.Map<User>(createUserDto);
        var newUser = this.userService.Create(user);

        return this.mapper.Map<UserResponseDto>(newUser);
    }

    [HttpGet("{id}")]
    public ActionResult<UserResponseDto> FindOne([FromRoute] int id)
    {
        var user = this.userService.FindOne(id);

        if (user is null)
        {
            return NotFound();
        }

        return this.mapper.Map<UserResponseDto>(user);

    }

    [HttpPatch("{id}")]
    public ActionResult<UserResponseDto> Update([FromRoute] int id, [FromBody] UpdateUserDto updateUser)
    {
        var payload = this.mapper.Map<User>(updateUser);
        var user = this.userService.Update(id, payload);

        if (user is null)
        {
            return NotFound();
        }

        return this.mapper.Map<UserResponseDto>(user); ;

    }
}

