using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Queries.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        private readonly ICreateUserCommand _createUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;
        private readonly IUserGetAllQuery _userGetAllQuery;
        private readonly IUserGetQuery _userGetQuery;

        public User(ICreateUserCommand createUserCommand, IDeleteUserCommand deleteUserCommand,
            IUserGetAllQuery userGetAllQuery, IUserGetQuery userGetQuery)
        {
            _createUserCommand = createUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _userGetAllQuery = userGetAllQuery;
            _userGetQuery = userGetQuery;
        }

        // GET: api/<User>
        [HttpGet("AllUsers/")] //("api/Project/")
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserQueryResultDto>> Get() // GetAllUsers
        {
            var result = _userGetAllQuery.GetAllUsers().ToList();
            if (!result.Any())

                return NotFound();

            return result.ToList();
        }

        // GET: api/<User>
        [HttpGet("{userId}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserQueryResultDto> Get(string userId) // Get
        {
            var result = _userGetQuery.GetUser(userId);


            return result;
        }

        // POST api/<User>
        [HttpPost("CreateUser/")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post(UserCreateRequestDto request) // AddUser
        {
            try
            {
                _createUserCommand.CreateUser(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<User>/5
        [HttpDelete("DeleteUser/{userId}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDeleteRequestDto> Delete(string userId) // RemoveUser
        {
            try
            {
                _deleteUserCommand.DeleteUser(userId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
