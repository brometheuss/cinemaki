using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ProductionCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionsController : ControllerBase
    {
        private readonly IGetProductionsCommand getProductions;
        private readonly IGetProductionCommand getProduction;
        private readonly IAddProductionCommand addProduction;
        private readonly IEditProductionCommand editProduction;
        private readonly IDeleteProductionCommand deleteProduction;

        public ProductionsController(IGetProductionsCommand getProductions, IGetProductionCommand getProduction, IAddProductionCommand addProduction, IEditProductionCommand editProduction, IDeleteProductionCommand deleteProduction)
        {
            this.getProductions = getProductions;
            this.getProduction = getProduction;
            this.addProduction = addProduction;
            this.editProduction = editProduction;
            this.deleteProduction = deleteProduction;
        }

        // GET: api/Productions
        [HttpGet]
        public IActionResult Get([FromQuery] ProductionQuery query)
        {
            try
            {
                return Ok(getProductions.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // GET: api/Productions/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getProduction.Execute(id));
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

        // POST: api/Productions
        [HttpPost]
        public IActionResult Post([FromBody] ProductionDto dto)
        {
            try
            {
                addProduction.Execute(dto);
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

        // PUT: api/Productions/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductionDto dto)
        {
            try
            {
                dto.Id = id;
                editProduction.Execute(dto);
                return StatusCode(204);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(409, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
            catch (EntityCannotBeNullException e)
            {
                return StatusCode(422, new
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
                deleteProduction.Execute(id);
                return StatusCode(204);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(404, new
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
