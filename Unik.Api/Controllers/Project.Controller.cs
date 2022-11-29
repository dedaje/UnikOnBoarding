using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Unik.Onboarding.Application.Commands.Implementation.Project;
using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Queries.Implementation.Project;
using Unik.Onboarding.Application.Queries.Project;

namespace Unik.Api.Controllers;

[Route("api/[controller]/")]
[ApiController]
public class Project : ControllerBase
{
    private readonly ICreateProjectCommand _createProjectCommand;
    private readonly IEditProjectCommand _editProjectCommand;
    private readonly IProjectGetAllQuery _projectGetAllQuery;
    private readonly IProjectGetQuery _projectGetQuery;

    // constructor
    public Project(ICreateProjectCommand createProjectCommand,
        IEditProjectCommand editProjectCommand, IProjectGetAllQuery projectGetAllQuery,
        IProjectGetQuery projectGetQuery)
    {
        _projectGetAllQuery = projectGetAllQuery;
        _createProjectCommand = createProjectCommand;
        _editProjectCommand = editProjectCommand;
        _projectGetQuery = projectGetQuery;
    }

    // GET: api/<Project>
    [HttpGet("u/{userId}")] //("api/Project/")
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<ProjectQueryResultDto>> Get(string userId) // GetAllUserProjects
    {
        var result = _projectGetAllQuery.GetAllUserProjects(userId).ToList();
        if (!result.Any())

            return NotFound();

        return result.ToList();
    }

    // GET: api/<Project>
    [HttpGet("p/{projectId}")] //("api/Project/")
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<ProjectQueryResultDto>> Get(int? projectId) // GetAllEditProjects
    {
        var result = _projectGetAllQuery.GetAllEditProjects(projectId).ToList();
        if (!result.Any())

            return NotFound();

        return result.ToList();
    }

    // GET: api/<Project>
    [HttpGet("{userId}/{projectId}/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProjectQueryResultDto> Get(string userId, int projectId) // Get
    {
        var result = _projectGetQuery.GetProject(userId, projectId);


        return result;
    }

    // POST api/<Project>
    [HttpPost("Create/")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Post(ProjectCreateRequestDto request) // Create
    {
        try
        {
            _createProjectCommand.Create(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("Edit/")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Put([FromBody] ProjectEditRequestDto request) //Edit
    {
        try
        {
            _editProjectCommand.Edit(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}