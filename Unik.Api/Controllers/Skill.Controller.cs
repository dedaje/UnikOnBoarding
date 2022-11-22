using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
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

        // GET: api/<Onboarding>
        [HttpGet] //("api/Onboarding/")
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<SkillQueryResultDto>> Get() // GetAll
        {
            var result = _skillGetAllQuery.GetAllSkills().ToList();
            if (!result.Any())

                return NotFound();

            return result.ToList();
        }

        // GET: api/<Onboarding>
        [HttpGet("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SkillQueryResultDto> Get(int skillId) // Get
        {
            var result = _skillGetQuery.GetSkill(skillId);


            return result;
        }

        // POST api/<Onboarding>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post(SkillCreateRequestDto request) // Create
        {
            try
            {
                _createSkillCommand.Create(request);
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
        public ActionResult Put([FromBody] SkillEditRequestDto request) //Edit
        {
            try
            {
                _editSkillCommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
