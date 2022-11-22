using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Unik.Onboarding.Application.Commands.UserSkills;
using Unik.Onboarding.Application.Queries.UserSkills;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserSkills : ControllerBase
{
    private readonly ICreateUserSkillsCommand _createUserSkillsCommand;
    private readonly IEditUserSkillsCommand _editUserSkillsCommand;
    private readonly IUserSkillsGetAllQuery _userSkillsGetAllQuery;
    private readonly IUserSkillsGetQuery _userSkillsGetQuery;

    public UserSkills(ICreateUserSkillsCommand createUserSkillsCommand, IEditUserSkillsCommand editUserSkillsCommand,
        IUserSkillsGetAllQuery userSkillsGetAllQuery, IUserSkillsGetQuery userSkillsGetQuery)
    {
        _createUserSkillsCommand = createUserSkillsCommand;
        _editUserSkillsCommand = editUserSkillsCommand;
        _userSkillsGetAllQuery = userSkillsGetAllQuery;
        _userSkillsGetQuery = userSkillsGetQuery;
    }

    // GET: api/<UserSkills>
    [HttpGet("{userId}")] //("api/UserSkills/")
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<UserSkillsQueryResultDto>> Get(string userId) // GetAll
    {
        var result = _userSkillsGetAllQuery.GetAllUserSkills(userId).ToList();
        if (!result.Any())

            return NotFound();

        return result.ToList();
    }

    // GET: api/<Onboarding>
    [HttpGet("{userId}/{skillId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<UserSkillsQueryResultDto> Get(string userId, int skillId) // Get
    {
        var result = _userSkillsGetQuery.GetUserSkill(userId, skillId);


        return result;
    }

    // POST api/<Onboarding>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Post(UserSkillsCreateRequestDto request) // Create
    {
        try
        {
            _createUserSkillsCommand.Create(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Put([FromBody] UserSkillsEditRequestDto request) //Edit
    {
        try
        {
            _editUserSkillsCommand.Edit(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}