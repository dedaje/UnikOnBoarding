using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Onboarding.Application.Commands.Implementation;
using Unik.Onboarding.Application.Commands.Onboarding;
using Unik.Onboarding.Application.Queries.Implementation;
using Unik.Onboarding.Application.Queries.Onboarding;

namespace Unik.Api.Controllers
{
    [Route("api/Onboarding")]
    [ApiController]
    public class Onboarding : ControllerBase
    {
        private readonly IOnboardingGetAllQuery _onboardingGetAllQuery;
        private readonly ICreateOnboardingCommand _createOnboardingCommand;
        private readonly IEditOnboardingCommand _editOnboardingCommand;
        private readonly IOnboardingGetQuery _onboardingGetQuery;

        // constructor
        public Onboarding(IOnboardingGetAllQuery onboardingGetAllQuery, ICreateOnboardingCommand createOnboardingCommand, IEditOnboardingCommand editOnboardingCommand, IOnboardingGetQuery onboardingGetQuery)
        {
            _onboardingGetAllQuery = onboardingGetAllQuery;
            _createOnboardingCommand = createOnboardingCommand;
            _editOnboardingCommand = editOnboardingCommand;
            _onboardingGetQuery = onboardingGetQuery;
        }

        // GET: api/<Onboarding>
        [HttpGet("Onboarding/{specificUserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<OnboardingQueryResultDto>> Get()
        {
            var result = _onboardingGetAllQuery.GetAllProjects().ToList();
            if (!result.Any())

                return NotFound();

            return result.ToList();

        }

        // GET: api/<Onboarding>
        [HttpGet("{id}/{specificUserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OnboardingQueryResultDto> Get(int projectId)
        {
            var result = _onboardingGetQuery.GetProject(projectId);


            return result;

        }

        // POST api/<Onboarding>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post(OnboardingCreateRequestDto request)
        {
            try
            {
                _createOnboardingCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }

        }

        //[Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult PutAdd([FromBody] OnboardingEditRequestDto request)
        //{
        //    try
        //    {
        //        _editOnboardingCommand.AddUser(request);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);

        //    }


        //}

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult PutEdit([FromBody] OnboardingEditRequestDto request)
        {
            try
            {
                _editOnboardingCommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }


        }

        //[Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult PutRemove([FromBody] OnboardingEditRequestDto request)
        //{
        //    try
        //    {
        //        _editOnboardingCommand.RemoveUser(request);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);

        //    }


        //}

        // DELETE api/<Onboarding>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
