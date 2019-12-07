using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.GenreCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IAddGenreCommand addGenre;
        private readonly IGetGenresCommand getGenres;
        private readonly IGetGenreCommand getGenre;
        private readonly IEditGenreCommand editGenre;
        private readonly IDeleteGenreCommand deleteGenre;

        public GenresController(IAddGenreCommand addGenre, IGetGenresCommand getGenres, IGetGenreCommand getGenre, IEditGenreCommand editGenre, IDeleteGenreCommand deleteGenre)
        {
            this.addGenre = addGenre;
            this.getGenres = getGenres;
            this.getGenre = getGenre;
            this.editGenre = editGenre;
            this.deleteGenre = deleteGenre;
        }

        // GET: api/Genres
        [HttpGet]
        public IActionResult Get([FromQuery] GenreQuery query)
        {
            try
            {
                return Ok(getGenres.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getGenre.Execute(id));
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

        // POST: api/Genres
        [HttpPost]
        public IActionResult Post([FromBody] GenreDto dto)
        {
            try
            {
                addGenre.Execute(dto);
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

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenreDto dto)
        {
            try
            {
                dto.Id = id;
                editGenre.Execute(dto);
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
                deleteGenre.Execute(id);
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
