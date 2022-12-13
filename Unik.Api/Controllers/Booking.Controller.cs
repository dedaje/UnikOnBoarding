using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Onboarding.Application.Commands.Booking;
using Unik.Onboarding.Application.Queries.Booking;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Booking : ControllerBase
    {
        private readonly ICreateBookingCommand _createBookingCommand;
        private readonly IEditBookingCommand _editBookingCommand;
        private readonly IBookingGetAllQuery _bookingGetAllQuery;
        private readonly IBookingGetQuery _bookingGetQuery;
        private readonly IDeleteBookingCommand _deleteBookingCommand;

        public Booking(ICreateBookingCommand createBookingCommand, IEditBookingCommand editBookingCommand, 
            IBookingGetAllQuery bookingGetAllQuery, IBookingGetQuery bookingGetQuery, 
            IDeleteBookingCommand deleteBookingCommand)
        {
            _createBookingCommand = createBookingCommand;
            _editBookingCommand = editBookingCommand;
            _bookingGetAllQuery = bookingGetAllQuery;
            _bookingGetQuery = bookingGetQuery;
            _deleteBookingCommand = deleteBookingCommand;
        }

        // GET: api/<Booking>
        [HttpGet("AllBookings/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BookingQueryResultDto>> Get() // GetAllProjects
        {
            var result = _bookingGetAllQuery.GetAllBookings().ToList();
            if (!result.Any())

                return NotFound();

            return result.ToList();
        }

        // GET api/<Booking>/5
        [HttpGet("{id}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingQueryResultDto> Get(int id) // Get
        {
            var result = _bookingGetQuery.GetBooking(id);


            return result;
        }

        // POST api/<Booking>
        [HttpPost("CreateBooking/")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post(BookingCreateRequestDto request) // Create
        {
            try
            {
                _createBookingCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<Booking>/5
        [HttpPut("EditBooking/")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put([FromBody] BookingEditRequestDto request) //Edit
        {
            try
            {
                _editBookingCommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<Booking>/5
        [HttpDelete("DeleteBooking/{id}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingDeleteRequestDto> Delete(int id) // DeleteProject
        {
            try
            {
                _deleteBookingCommand.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
