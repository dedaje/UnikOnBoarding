using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Onboarding.Application.Commands.Implementation.Project;
using Unik.Onboarding.Application.Commands.Project;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        private readonly IAddUserCommand _addUserCommand;
        private readonly IRemoveUserCommand _removeUserCommand;

        public User(IAddUserCommand addUserCommand, IRemoveUserCommand removeUserCommand)
        {
            _addUserCommand = addUserCommand;
            _removeUserCommand = removeUserCommand;
        }

        // GET: api/<User>
        //[HttpGet]
        //public IEnumerable<string> Get() // GetAll
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<User>/5
        //[HttpGet("{id}")]
        //public string Get(int id) // Get
        //{
        //    return "value";
        //}

        // POST api/<User>
        [HttpPost("AddUser/")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post(AddUserRequestDto request) // AddUser
        {
            try
            {
                _addUserCommand.AddUser(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<User>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value) // Edit
        //{
        //}

        // DELETE api/<User>/5
        [HttpDelete("RemoveUser/{userId}/{projectId}/")]
        //[Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RemoveUserRequestDto> Delete(string userId, int projectId) // RemoveUser
        {
            try
            {
                _removeUserCommand.RemoveUser(userId, projectId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
