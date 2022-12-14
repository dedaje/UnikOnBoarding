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
        private readonly IDeleteTaskCommand _deleteTaskCommand;
        private readonly ITaskGetAllQuery _taskGetAllQuery;
        private readonly ITaskGetQuery _taskGetQuery;

        public Task(ICreateTaskCommand createTaskCommand, IEditTaskCommand editTaskCommand, IDeleteTaskCommand deleteTaskCommand, ITaskGetAllQuery taskGetAllQuery, ITaskGetQuery taskGetQuery)
        {
            _createTaskCommand = createTaskCommand;
            _editTaskCommand = editTaskCommand;
            _deleteTaskCommand = deleteTaskCommand;
            _taskGetAllQuery = taskGetAllQuery;
            _taskGetQuery = taskGetQuery;
        }

        // GET: api/<Task>
        [HttpGet("AllTasks/{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<TaskQueryResultDto>> GetAll(int projectId) //GetAllByRole
        {
            var result = _taskGetAllQuery.GetAllTasks(projectId).ToList();
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
        [HttpPost("CreateTask/")]
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
        [HttpPut("EditTask/")]
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

        // DELETE api/<Task>/5
        [HttpDelete("DeleteTask/{id}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TaskDeleteRequestDto> Delete(int id) // DeleteTask
        {
            try
            {
                _deleteTaskCommand.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
