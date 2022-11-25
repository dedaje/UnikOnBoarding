using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Unik.Onboarding.Application.Commands.Onboarding;
using Unik.Onboarding.Application.Queries.Onboarding;

namespace Unik.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Project : ControllerBase
{
    private readonly ICreateProjectCommand _createOnboardingCommand;
    private readonly IEditProjectCommand _editOnboardingCommand;
    private readonly IProjectGetAllQuery _onboardingGetAllQuery;
    private readonly IProjectGetQuery _onboardingGetQuery;

    // constructor
    public Project(ICreateProjectCommand createOnboardingCommand,
        IEditProjectCommand editOnboardingCommand, IProjectGetAllQuery onboardingGetAllQuery,
        IProjectGetQuery onboardingGetQuery)
    {
        _onboardingGetAllQuery = onboardingGetAllQuery;
        _createOnboardingCommand = createOnboardingCommand;
        _editOnboardingCommand = editOnboardingCommand;
        _onboardingGetQuery = onboardingGetQuery;
    }

    // GET: api/<Onboarding>
    [HttpGet("{userId}")] //("api/Onboarding/")
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<ProjectQueryResultDto>> Get(string userId) // GetAll
    {
        var result = _onboardingGetAllQuery.GetAllProjects(userId).ToList();
        if (!result.Any())

            return NotFound();

        return result.ToList();
    }

    // GET: api/<Onboarding>
    [HttpGet("{userId}/{projectId}/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProjectQueryResultDto> Get(string userId, int projectId) // Get
    {
        var result = _onboardingGetQuery.GetProject(userId, projectId);


        return result;
    }

    // POST api/<Onboarding>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Post(ProjectCreateRequestDto request) // Create
    {
        try
        {
            _createOnboardingCommand.Create(request);
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
    public ActionResult Put([FromBody] ProjectEditRequestDto request) //Edit
    {
        try
        {
            _editOnboardingCommand.Edit(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}