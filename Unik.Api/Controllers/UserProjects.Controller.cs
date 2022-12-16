using Microsoft.AspNetCore.Mvc;
using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Application.Queries.UserProjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProjects : ControllerBase
    {
        private readonly IUserProjectsGetAllQuery _userProjectsGetAllQuery;

        public UserProjects(IUserProjectsGetAllQuery userProjectsGetAllQuery)
        {
            _userProjectsGetAllQuery = userProjectsGetAllQuery;
        }

        // GET: api/<UserProjects>
        [HttpGet("{userId}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserProjectsQueryResultDto>> Get(int usersId) // GetAllProjectUsers
        {
            var result = _userProjectsGetAllQuery.GetAllUserProjects(usersId).ToList();
            if (!result.Any())
                return NotFound();

            return result.ToList();
        }

        // GET api/<UserProjects>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UserProjects>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<UserProjects>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UserProjects>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
