using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Net.Mime;
using Unik.Onboarding.Application.Commands.Task;
using Unik.Onboarding.Application.Queries.Task;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task : ControllerBase
    {
        private readonly ICreateTaskCommand _createTaskCommand;
        private readonly IEditTaskCommand _editTaskCommand;
        private readonly ITaskGetAllQuery _taskGetAllQuery;
        private readonly ITaskGetQuery _taskGetQuery;

        public Task(ICreateTaskCommand createTaskCommand, IEditTaskCommand editTaskCommand, ITaskGetAllQuery taskGetAllQuery, ITaskGetQuery taskGetQuery)
        {
            _createTaskCommand = createTaskCommand;
            _editTaskCommand = editTaskCommand;
            _taskGetAllQuery = taskGetAllQuery;
            _taskGetQuery = taskGetQuery;
        }

        // GET: api/<Task>
        [HttpGet("{projectId}/{roleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<TaskQueryResultDto>> Get(int projectId, int roleId) //GetAllByRole
        {
            var result = _taskGetAllQuery.GetAllTasksByRole(projectId, roleId).ToList();
            if (!result.Any())

                return NotFound();

            return result.ToList();
        }

        // GET: api/<Task>
        [HttpGet("{projectId}/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<TaskQueryResultDto>> Get(int projectId, string userId) //GetAllByUser
        {
            var result = _taskGetAllQuery.GetAllTasksByUser(projectId, userId).ToList();
            if (!result.Any())

                return NotFound();

            return result.ToList();
        }

        // GET api/<Task>/5
        [HttpGet("{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TaskQueryResultDto> Get(int taskId) // GetTask
        {
            var result = _taskGetQuery.GetTask(taskId);


            return result;
        }

        // POST api/<Task>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post(TaskCreateRequestDto request)
        {
            try
            {
                _createTaskCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<Task>/5
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put([FromBody] TaskEditRequestDto request)
        {
            try
            {
                _editTaskCommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
