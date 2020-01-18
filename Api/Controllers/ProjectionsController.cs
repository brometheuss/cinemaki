using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ProjectionCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionsController : ControllerBase
    {
        private readonly IGetProjectionsCommand getProjections;
        private readonly IGetProjectionCommand getProjection;
        private readonly IAddProjectionCommand addProjection;
        private readonly IEditProjectionCommand editProjection;
        private readonly IDeleteProjectionCommand deleteProjection;

        public ProjectionsController(IGetProjectionsCommand getProjections, IAddProjectionCommand addProjection, IGetProjectionCommand getProjection, IEditProjectionCommand editProjection, IDeleteProjectionCommand deleteProjection)
        {
            this.getProjections = getProjections;
            this.addProjection = addProjection;
            this.getProjection = getProjection;
            this.editProjection = editProjection;
            this.deleteProjection = deleteProjection;
        }

        // GET: api/Projections
        [HttpGet]
        public IActionResult Get([FromQuery] ProjectionQuery query)
        {
            try
            {
                return Ok(getProjections.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // GET: api/Projections/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getProjection.Execute(id));
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

        // POST: api/Projections
        [HttpPost]
        public IActionResult Post([FromBody] ProjectionDto dto)
        {
            try
            {
                addProjection.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(409, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
            catch (EntityAlreadyHasAnEntryException e)
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

        // PUT: api/Projections/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProjectionDto dto)
        {
            try
            {
                dto.Id = id;
                editProjection.Execute(dto);
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
                deleteProjection.Execute(id);
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
