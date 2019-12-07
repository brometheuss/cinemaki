using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.RatedCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatedsController : ControllerBase
    {
        private readonly IGetRatedsCommand getRateds;
        private readonly IGetRatedCommand getRated;
        private readonly IAddRatedCommand addRated;
        private readonly IEditRatedCommand editRated;
        private readonly IDeleteRatedCommand deleteRated;

        public RatedsController(IGetRatedsCommand getRateds, IGetRatedCommand getRated, IAddRatedCommand addRated, IEditRatedCommand editRated, IDeleteRatedCommand deleteRated)
        {
            this.getRateds = getRateds;
            this.getRated = getRated;
            this.addRated = addRated;
            this.editRated = editRated;
            this.deleteRated = deleteRated;
        }

        // GET: api/Rateds
        [HttpGet]
        public IActionResult Get([FromQuery] RatedQuery query)
        {
            try
            {
                return Ok(getRateds.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // GET: api/Rateds/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getRated.Execute(id));
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // POST: api/Rateds
        [HttpPost]
        public IActionResult Post([FromBody] RatedDto dto)
        {
            try
            {
                addRated.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // PUT: api/Rateds/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RatedDto dto)
        {
            try
            {
                dto.Id = id;
                editRated.Execute(dto);
                return StatusCode(204);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteRated.Execute(id);
                return StatusCode(204);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
