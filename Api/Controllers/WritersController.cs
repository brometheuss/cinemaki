using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.WriterCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IGetWritersCommand getWriters;
        private readonly IGetWriterCommand getWriter;
        private readonly IAddWriterCommand addWriter;
        private readonly IEditWriterCommand editWriter;
        private readonly IDeleteWriterCommand deleteWriter;

        public WritersController(IGetWritersCommand getWriters, IAddWriterCommand addWriter, IGetWriterCommand getWriter, IEditWriterCommand editWriter, IDeleteWriterCommand deleteWriter)
        {
            this.getWriters = getWriters;
            this.addWriter = addWriter;
            this.getWriter = getWriter;
            this.editWriter = editWriter;
            this.deleteWriter = deleteWriter;
        }

        // GET: api/Writers
        [HttpGet]
        public IActionResult Get([FromQuery] WriterQuery query)
        {
            try
            {
                return Ok(getWriters.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // GET: api/Writers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getWriter.Execute(id));
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

        // POST: api/Writers
        [HttpPost]
        public IActionResult Post([FromBody] WriterDto dto)
        {
            try
            {
                addWriter.Execute(dto);
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

        // PUT: api/Writers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WriterDto dto)
        {
            try
            {
                dto.Id = id;
                editWriter.Execute(dto);
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
                deleteWriter.Execute(id);
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
