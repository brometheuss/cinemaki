using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.LanguageCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly IGetLanguagesCommand getLanguages;
        private readonly IGetLanguageCommand getLanguage;
        private readonly IAddLanguageCommand addLanguage;
        private readonly IEditLanguageCommand editLanguage;
        private readonly IDeleteLanguageCommand deleteLanguage;

        public LanguagesController(IGetLanguagesCommand getLanguages, IAddLanguageCommand addLanguage, IGetLanguageCommand getLanguage, IEditLanguageCommand editLanguage, IDeleteLanguageCommand deleteLanguage)
        {
            this.getLanguages = getLanguages;
            this.addLanguage = addLanguage;
            this.getLanguage = getLanguage;
            this.editLanguage = editLanguage;
            this.deleteLanguage = deleteLanguage;
        }

        // GET: api/Languages
        [HttpGet]
        public IActionResult Get([FromQuery] LanguageQuery query)
        {
            try
            {
                return Ok(getLanguages.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // GET: api/Languages/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getLanguage.Execute(id));
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

        // POST: api/Languages
        [HttpPost]
        public IActionResult Post([FromBody] LanguageDto dto)
        {
            try
            {
                addLanguage.Execute(dto);
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

        // PUT: api/Languages/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LanguageDto dto)
        {
            try
            {
                dto.Id = id;
                editLanguage.Execute(dto);
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
                deleteLanguage.Execute(id);
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
