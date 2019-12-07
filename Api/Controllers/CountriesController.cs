using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.CountryCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IGetCountriesCommand getCountries;
        private readonly IGetCountryCommand getCountry;
        private readonly IAddCountryCommand addCountry;
        private readonly IEditCountryCommand editCountry;
        private readonly IDeleteCountryCommand deleteCountry;

        public CountriesController(IGetCountriesCommand getCountries, IGetCountryCommand getCountry, IAddCountryCommand addCountry, IEditCountryCommand editCountry, IDeleteCountryCommand deleteCountry)
        {
            this.getCountries = getCountries;
            this.getCountry = getCountry;
            this.addCountry = addCountry;
            this.editCountry = editCountry;
            this.deleteCountry = deleteCountry;
        }

        // GET: api/Countries
        [HttpGet]
        public IActionResult Get([FromQuery] CountryQuery query)
        {
            try
            {
                return Ok(getCountries.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getCountry.Execute(id));
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

        // POST: api/Countries
        [HttpPost]
        public IActionResult Post([FromBody] CountryDto dto)
        {
            try
            {
                addCountry.Execute(dto);
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

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CountryDto dto)
        {
            try
            {
                dto.Id = id;
                editCountry.Execute(dto);
                return StatusCode(204);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteCountry.Execute(id);
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
