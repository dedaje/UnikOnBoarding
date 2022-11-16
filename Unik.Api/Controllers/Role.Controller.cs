using Microsoft.AspNetCore.Mvc;
using Unik.Onboarding.Application.Commands.Role;
using Unik.Onboarding.Application.Queries.Role;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Role : ControllerBase
    {
        private readonly ICreateRoleCommand _createRoleCommand;
        private readonly IEditRoleCommand _editRoleCommand;
        private readonly IRoleGetAllQuery _roleGetAllQuery;
        private readonly IRoleGetQuery _roleGetQuery;

        public Role(ICreateRoleCommand createRoleCommand, IEditRoleCommand editRoleCommand, IRoleGetAllQuery roleGetAllQuery, IRoleGetQuery roleGetQuery)
        {
            _createRoleCommand = createRoleCommand;
            _editRoleCommand = editRoleCommand;
            _roleGetAllQuery = roleGetAllQuery;
            _roleGetQuery = roleGetQuery;
        }

        // GET: api/<Role>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Role>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Role>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Role>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Role>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
