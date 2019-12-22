using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ActorCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IGetActorsCommand getActors;
        private readonly IGetActorCommand getActor;
        private readonly IAddActorCommand addActors;
        private readonly IEditActorCommand editActor;
        private readonly IDeleteActorCommand deleteActor;

        public ActorsController(IAddActorCommand addActors, IGetActorsCommand getActors, IGetActorCommand getActor, IEditActorCommand editActor, IDeleteActorCommand deleteActor)
        {
            this.addActors = addActors;
            this.getActors = getActors;
            this.getActor = getActor;
            this.editActor = editActor;
            this.deleteActor = deleteActor;
        }

        // GET: api/Actors
        [HttpGet]
        public IActionResult Get([FromQuery] ActorQuery query)
        {
            try
            {
                return Ok(getActors.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getActor.Execute(id));
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

        // POST: api/Actors
        [HttpPost]
        public IActionResult Post([FromBody] ActorDto dto)
        {   
            try
            {
                addActors.Execute(dto);
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

        // PUT: api/Actors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActorDto dto)
        {
            try
            {
                dto.Id = id;
                editActor.Execute(dto);
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
                deleteActor.Execute(id);
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
