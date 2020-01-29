using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.HallCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private readonly IGetHallsCommand getHalls;
        private readonly IGetHallCommand getHall;
        private readonly IAddHallCommand addHall;
        private readonly IEditHallCommand editHall;
        private readonly IDeleteHallCommand deleteHall;

        public HallsController(IAddHallCommand addHall, IGetHallsCommand getHalls, IGetHallCommand getHall, IEditHallCommand editHall, IDeleteHallCommand deleteHall)
        {
            this.addHall = addHall;
            this.getHalls = getHalls;
            this.getHall = getHall;
            this.editHall = editHall;
            this.deleteHall = deleteHall;
        }

        // GET: api/Halls
        [HttpGet]
        public IActionResult Get([FromQuery] HallQuery query)
        {
            try
            {
                return Ok(getHalls.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // GET: api/Halls/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getHall.Execute(id));
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

        // POST: api/Halls
        [HttpPost]
        public IActionResult Post([FromBody] HallDto dto)
        {
            try
            {
                addHall.Execute(dto);
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

        // PUT: api/Halls/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HallDto dto)
        {
            try
            {
                dto.Id = id;
                editHall.Execute(dto);
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
                deleteHall.Execute(id);
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
