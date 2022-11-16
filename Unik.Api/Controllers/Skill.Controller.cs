using Microsoft.AspNetCore.Mvc;
using Unik.Onboarding.Application.Commands.Skill;
using Unik.Onboarding.Application.Queries.Skill;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Skill : ControllerBase
    {
        private readonly ICreateSkillCommand _createSkillCommand;
        private readonly IEditSkillCommand _editSkillCommand;
        private readonly ISkillGetAllQuery _skillGetAllQuery;
        private readonly ISkillGetQuery _skillGetQuery;

        public Skill(ICreateSkillCommand createSkillCommand, IEditSkillCommand editSkillCommand, ISkillGetAllQuery skillGetAllQuery, ISkillGetQuery skillGetQuery)
        {
            _createSkillCommand = createSkillCommand;
            _editSkillCommand = editSkillCommand;
            _skillGetAllQuery = skillGetAllQuery;
            _skillGetQuery = skillGetQuery;
        }

        // GET: api/<Skill>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Skill>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Skill>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Skill>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Skill>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
