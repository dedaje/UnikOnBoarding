using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Unik.Onboarding.Application.Commands.ProjectUsers;
using Unik.Onboarding.Application.Queries.Project;
using Unik.Onboarding.Application.Queries.ProjectUsers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectUsers : ControllerBase
    {
        private readonly IAddUserToProjectCommand _addUserToProjectCommand;
        private readonly IRemoveUserFromProjectCommand _removeUserFromProjectCommand;
        private readonly IProjectUsersGetAllQuery _projectUsersGetAllQuery;

        public ProjectUsers(IAddUserToProjectCommand addUserToProjectCommand, IRemoveUserFromProjectCommand removeUserFromProjectCommand, IProjectUsersGetAllQuery projectUsersGetAllQuery)
        {
            _addUserToProjectCommand = addUserToProjectCommand;
            _removeUserFromProjectCommand = removeUserFromProjectCommand;
            _projectUsersGetAllQuery = projectUsersGetAllQuery;
        }

        // GET: api/<ProjectUsers>
        [HttpGet("{projectId}/")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ProjectUsersQueryResultDto>> Get(int projectId) // GetAllProjectUsers
        {
            var result = _projectUsersGetAllQuery.GetAllProjectUsers(projectId).ToList();
            if (!result.Any())
                return NotFound();

            return result.ToList();
        }

        // POST api/<ProjectUsers>
        [HttpPost("AddUser/")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post(ProjectAddUserRequestDto request) // AddUser
        {
            try
            {
                _addUserToProjectCommand.AddUser(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ProjectUsers>/5
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
    }
}
