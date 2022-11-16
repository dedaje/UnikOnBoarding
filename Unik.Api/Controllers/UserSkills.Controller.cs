using Microsoft.AspNetCore.Mvc;
using Unik.Onboarding.Application.Commands.UserSkills;
using Unik.Onboarding.Application.Queries.UserSkills;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSkills : ControllerBase
    {
        private readonly ICreateUserSkillsCommand _createUserSkillsCommand;
        private readonly IEditUserSkillsCommand _editUserSkillsCommand;
        private readonly IUserSkillsGetAllQuery _userSkillsGetAllQuery;
        private readonly IUserSkillsGetQuery _userSkillsGetQuery;

        public UserSkills(ICreateUserSkillsCommand createUserSkillsCommand, IEditUserSkillsCommand editUserSkillsCommand, 
            IUserSkillsGetAllQuery userSkillsGetAllQuery, IUserSkillsGetQuery userSkillsGetQuery)
        {
            _createUserSkillsCommand = createUserSkillsCommand;
            _editUserSkillsCommand = editUserSkillsCommand;
            _userSkillsGetAllQuery = userSkillsGetAllQuery;
            _userSkillsGetQuery = userSkillsGetQuery;
        }

        // GET: api/<UserSkills>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserSkills>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserSkills>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserSkills>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserSkills>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
