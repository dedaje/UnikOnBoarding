using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<User>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
