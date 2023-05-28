using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using feedApi.Roles.dto;

namespace feedApi.Roles;

[Authorize]
[ApiController]
[Route("roles")]
public class RoleController : ControllerBase
{
    private readonly ILogger<RoleController> _logger;
    private readonly IRoleService service;
    private readonly IMapper mapper;

    public RoleController(ILogger<RoleController> logger, IRoleService userService, IMapper mapper)
    {
        _logger = logger;
        this.service = userService;
        this.mapper = mapper;
    }

    [HttpGet(Name = "FindRoles")]
    public IEnumerable<RoleResponseDto> FindAll()
    {
        return  this.service.Find().Select(this.mapper.Map<RoleResponseDto>);
    }


    [HttpPost(Name = "CreateRole")]
    public RoleResponseDto Create([FromBody] CreateRoleDto createDto)
    {
        var user = this.mapper.Map<Role>(createDto);
        var newUser = this.service.Create(user);

        return this.mapper.Map<RoleResponseDto>(newUser);
    }

    [HttpGet( "{id}", Name = "FindOneRole")]
    public ActionResult<RoleResponseDto> FindOne([FromRoute] int id)
    {
        var user = this.service.FindOne(id);

        if (user is null)
        {
            return NotFound();
        }

        return this.mapper.Map<RoleResponseDto>(user);

    }

    [HttpPatch("{id}", Name = "UpdateRole")]
    public ActionResult<RoleResponseDto> Update([FromRoute] int id, [FromBody] UpdateRoleDto updateUser)
    {
        var payload = this.mapper.Map<Role>(updateUser);
        var user = this.service.Update(id, payload);

        if (user is null)
        {
            return NotFound();
        }

        return this.mapper.Map<RoleResponseDto>(user); ;

    }
}

