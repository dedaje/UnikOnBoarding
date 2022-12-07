using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Unik.Onboarding.Application.Commands.Implementation.Project;
using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Queries.Implementation.Project;
using Unik.Onboarding.Application.Queries.Project;

namespace Unik.Api.Controllers;

[Route("api/[controller]/")]
[ApiController]
public class Project : ControllerBase
{
    private readonly ICreateProjectCommand _createProjectCommand;
    private readonly IEditProjectCommand _editProjectCommand;
    private readonly IDeleteProjectCommand _deleteProjectCommand;
    private readonly IRemoveUserFromProjectCommand _removeUserFromProjectCommand;
    private readonly IProjectGetAllQuery _projectGetAllQuery;
    private readonly IProjectGetQuery _projectGetQuery;

    // constructor
    public Project(ICreateProjectCommand createProjectCommand, IEditProjectCommand editProjectCommand, 
        IDeleteProjectCommand deleteProjectCommand, IRemoveUserFromProjectCommand removeUserFromProjectCommand, 
        IProjectGetAllQuery projectGetAllQuery, IProjectGetQuery projectGetQuery)
    {
        _projectGetAllQuery = projectGetAllQuery;
        _createProjectCommand = createProjectCommand;
        _editProjectCommand = editProjectCommand;
        _deleteProjectCommand = deleteProjectCommand;
        _removeUserFromProjectCommand = removeUserFromProjectCommand;
        _projectGetQuery = projectGetQuery;
    }

    // GET: api/<Project>
    [HttpGet("{projectId}/{userId}/")] //("api/Project/")
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<ProjectUsersQueryResultDto>> Get(int projectId, int usersId) // GetAllUserProjects
    {
        var result = _projectGetAllQuery.GetAllUserProjects(projectId, usersId).ToList();
        if (!result.Any())
            return NotFound();

        return result.ToList();
    }

    // GET: api/<Project>
    [HttpGet("AllProjects/")] //("api/Project/")
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<ProjectQueryResultDto>> Get() // GetAllProjects
    {
        var result = _projectGetAllQuery.GetAllProjects().ToList();
        if (!result.Any())

            return NotFound();

        return result.ToList();
    }

    // GET: api/<Project>
    [HttpGet("{projectId}/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProjectQueryResultDto> Get(int projectId) // Get
    {
        var result = _projectGetQuery.GetProject(projectId);


        return result;
    }

    // POST api/<Project>
    [HttpPost("CreateProject/")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Post(ProjectCreateWithUserRequestDto request) // Create
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

    [HttpPut("EditProject/")]
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

    // DELETE api/<Project>/5
    [HttpDelete("RemoveUserFromProject/{userId}/{projectId}/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProjectRemoveUserRequestDto> Delete(string userId, int projectId) // RemoveUserFromProject
    {
        try
        {
            _removeUserFromProjectCommand.RemoveUserFromProject(userId, projectId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // DELETE api/<Project>/6
    [HttpDelete("DeleteProject/{projectId}/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProjectDeleteRequestDto> Delete(int projectId) // DeleteProject
    {
        try
        {
            _deleteProjectCommand.Delete(projectId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}