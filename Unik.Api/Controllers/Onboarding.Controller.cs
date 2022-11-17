using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Unik.Onboarding.Application.Commands.Onboarding;
using Unik.Onboarding.Application.Queries.Onboarding;

namespace Unik.Api.Controllers;

[Route("api/Onboarding")]
[ApiController]
public class Onboarding : ControllerBase
{
    private readonly ICreateOnboardingCommand _createOnboardingCommand;
    private readonly IEditOnboardingCommand _editOnboardingCommand;
    private readonly IOnboardingGetAllQuery _onboardingGetAllQuery;
    private readonly IOnboardingGetQuery _onboardingGetQuery;

    // constructor
    public Onboarding(IOnboardingGetAllQuery onboardingGetAllQuery, ICreateOnboardingCommand createOnboardingCommand,
        IEditOnboardingCommand editOnboardingCommand, IOnboardingGetQuery onboardingGetQuery)
    {
        _onboardingGetAllQuery = onboardingGetAllQuery;
        _createOnboardingCommand = createOnboardingCommand;
        _editOnboardingCommand = editOnboardingCommand;
        _onboardingGetQuery = onboardingGetQuery;
    }

    // GET: api/<Onboarding>
    [HttpGet("api/Onboarding/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<OnboardingQueryResultDto>> Get() // GetAll
    {
        var result = _onboardingGetAllQuery.GetAllProjects().ToList();
        if (!result.Any())

            return NotFound();

        return result.ToList();
    }

    // GET: api/<Onboarding>
    [HttpGet("api/Onboarding/{projectId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<OnboardingQueryResultDto> Get(int projectId) // Get
    {
        var result = _onboardingGetQuery.GetProject(projectId);


        return result;
    }

    // POST api/<Onboarding>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Post(OnboardingCreateRequestDto request) // Create
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
    public ActionResult PutEdit([FromBody] OnboardingEditRequestDto request) //Edit
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