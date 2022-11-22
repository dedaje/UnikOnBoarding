using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Unik.Onboarding.Application.Commands.OnboardingUsers;
using Unik.Onboarding.Application.Queries.OnboardingUsers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboardingUsers : ControllerBase
    {
        private readonly ICreateOnboardingUsersCommand _createOnboardingUsersCommand;
        private readonly IEditOnboardingUsersCommand _editOnboardingUsersCommand;
        private readonly IOnboardingUsersGetAllQuery _onboardingUsersGetAllQuery;
        private readonly IOnboardingUsersGetQuery _onboardingUsersGetQuery;

        public OnboardingUsers(ICreateOnboardingUsersCommand createOnboardingUsersCommand, IEditOnboardingUsersCommand editOnboardingUsersCommand, 
            IOnboardingUsersGetAllQuery onboardingUsersGetAllQuery, IOnboardingUsersGetQuery onboardingUsersGetQuery)
        {
            _createOnboardingUsersCommand = createOnboardingUsersCommand;
            _editOnboardingUsersCommand = editOnboardingUsersCommand;
            _onboardingUsersGetAllQuery = onboardingUsersGetAllQuery;
            _onboardingUsersGetQuery = onboardingUsersGetQuery;
        }

        // GET: api/<OnboardingUsers>
        [HttpGet("Onboarding/{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<OnboardingUsersQueryResultDto>> Get(int projectId)
        {
            var result = _onboardingUsersGetAllQuery.GetAllOnboardingUsers(projectId).ToList();
            if (!result.Any())

                return NotFound();

            return result.ToList();
        }

        // GET api/<OnboardingUsers>/5
        [HttpGet("Onboarding/{projectId}/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OnboardingUsersQueryResultDto> Get(int projectId, string userId)
        {
            var result = _onboardingUsersGetQuery.GetOnboardingUser(projectId, userId);


            return result;
        }

        // POST api/<OnboardingUsers>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post(OnboardingUsersCreateRequestDto request)
        {
            try
            {
                _createOnboardingUsersCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<OnboardingUsers>/5
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put([FromBody] OnboardingUsersEditRequestDto request)
        {
            try
            {
                _editOnboardingUsersCommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
