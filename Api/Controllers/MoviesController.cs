using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.MovieCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IGetMoviesCommand getMovies;
        private readonly IGetMovieCommand getMovie;
        private readonly IAddMovieCommand addMovie;

        public MoviesController(IGetMoviesCommand getMovies, IGetMovieCommand getMovie, IAddMovieCommand addMovie)
        {
            this.getMovies = getMovies;
            this.getMovie = getMovie;
            this.addMovie = addMovie;
        }


        // GET: api/Movies
        [HttpGet]
        public IActionResult Get([FromQuery] MovieQuery query)
        {
            try
            {
                return Ok(getMovies.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getMovie.Execute(id));
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

        // POST: api/Movies
        [HttpPost]
        public IActionResult Post([FromBody] MovieDto dto)
        {
            try
            {
                addMovie.Execute(dto);
                return StatusCode(201);
            }
            catch(EntityNotFoundException ex)
            {
                return StatusCode(409, new
                {
                    Errors = new List<string> { ex.Message }
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

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MovieDto dto)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
