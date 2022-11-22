using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Onboarding.Application.Commands.User;
using Unik.Onboarding.Application.Queries.Implementation.User;
using Unik.Onboarding.Application.Queries.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        private readonly ICreateUserCommand _createUserCommand;
        private readonly IEditUserCommand _editUserCommand;
        private readonly IUserGetAllQuery _userGetAllQuery;
        private readonly IUserGetQuery _userGetQuery;

        public User(ICreateUserCommand createUserCommand, IEditUserCommand editUserCommand, IUserGetAllQuery userGetAllQuery, IUserGetQuery userGetQuery)
        {
            _createUserCommand = createUserCommand;
            _editUserCommand = editUserCommand;
            _userGetAllQuery = userGetAllQuery;
            _userGetQuery = userGetQuery;
        }

        // GET: api/<User>
        [HttpGet("{roleId}")] //("api/User/")
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserQueryResultDto>> Get(int roleId) // GetAllByRole
        {
            var result = _userGetAllQuery.GetAllByRole(roleId).ToList();
            if (!result.Any())

                return NotFound();

            return result.ToList();
        }

        // GET: api/<User>
        [HttpGet] //("api/User/")
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
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserQueryResultDto> Get(string userId) // Get
        {
            var result = _userGetQuery.GetUser(userId);


            return result;
        }

        // POST api/<User>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post(UserCreateRequestDto request) // Create
        {
            try
            {
                _createUserCommand.Create(request);
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
        public ActionResult PutEdit([FromBody] UserEditRequestDto request) //Edit
        {
            try
            {
                _editUserCommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
