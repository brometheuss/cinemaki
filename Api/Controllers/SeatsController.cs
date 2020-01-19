using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.SeatCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly IGetSeatsCommand getSeats;
        private readonly IGetSeatCommand getSeat;
        private readonly IAddSeatCommand addSeat;
        private readonly IEditSeatCommand editSeat;
        private readonly IDeleteSeatCommand deleteSeat;

        public SeatsController(IAddSeatCommand addSeat, IGetSeatsCommand getSeats, IGetSeatCommand getSeat, IEditSeatCommand editSeat, IDeleteSeatCommand deleteSeat)
        {
            this.addSeat = addSeat;
            this.getSeats = getSeats;
            this.getSeat = getSeat;
            this.editSeat = editSeat;
            this.deleteSeat = deleteSeat;
        }

        // GET: api/Seats
        [HttpGet]
        public IActionResult Get([FromQuery] SeatQuery query)
        {
            try
            {
                return Ok(getSeats.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // GET: api/Seats/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getSeat.Execute(id));
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(new
                {
                    Errors = new List<string> { e.Message }
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // POST: api/Seats
        [HttpPost]
        public IActionResult Post([FromBody] SeatDto dto)
        {
            try
            {
                addSeat.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(409, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // PUT: api/Seats/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SeatDto dto)
        {
            try
            {
                dto.Id = id;
                editSeat.Execute(dto);
                return StatusCode(204);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(409, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(new
                {
                    Errors = new List<string> { e.Message }
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteSeat.Execute(id);
                return StatusCode(204);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(new
                {
                    Errors = new List<string> { e.Message }
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }
    }
}
