using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Unik.Onboarding.Application.Commands.Role;
using Unik.Onboarding.Application.Queries.Role;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Role : ControllerBase
{
    private readonly ICreateRoleCommand _createRoleCommand;
    private readonly IEditRoleCommand _editRoleCommand;
    private readonly IRoleGetAllQuery _roleGetAllQuery;
    private readonly IRoleGetQuery _roleGetQuery;

    public Role(ICreateRoleCommand createRoleCommand, IEditRoleCommand editRoleCommand,
        IRoleGetAllQuery roleGetAllQuery, IRoleGetQuery roleGetQuery)
    {
        _createRoleCommand = createRoleCommand;
        _editRoleCommand = editRoleCommand;
        _roleGetAllQuery = roleGetAllQuery;
        _roleGetQuery = roleGetQuery;
    }

    // GET: api/<Role>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<RoleQueryResultDto>> Get() // GetAll
    {
        var result = _roleGetAllQuery.GetAllRoles().ToList();
        if (!result.Any())

            return NotFound();

        return result.ToList();
    }

    // GET api/<Role>/5
    [HttpGet("{roleId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<RoleQueryResultDto> Get(int roleId) //Get
    {
        var result = _roleGetQuery.GetRole(roleId);


        return result;
    }

    // POST api/<Role>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Post(RoleCreateRequestDto request)
    {
        try
        {
            _createRoleCommand.Create(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // PUT api/<Role>/5
    [HttpPut("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Put([FromBody] RoleEditRequestDto request)
    {
        try
        {
            _editRoleCommand.Edit(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}