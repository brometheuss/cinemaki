﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.PosterCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostersController : ControllerBase
    {
        private readonly IGetPostersCommand getPosters;
        private readonly IGetPosterCommand getPoster;
        private readonly IAddPosterCommand addPoster;
        private readonly IEditPosterCommand editPoster;
        private readonly IDeletePosterCommand deletePoster;

        public PostersController(IAddPosterCommand addPoster, IGetPostersCommand getPosters, IGetPosterCommand getPoster, IEditPosterCommand editPoster, IDeletePosterCommand deletePoster)
        {
            this.addPoster = addPoster;
            this.getPosters = getPosters;
            this.getPoster = getPoster;
            this.editPoster = editPoster;
            this.deletePoster = deletePoster;
        }

        // GET: api/Posters
        [HttpGet]
        public IActionResult Get([FromQuery] PosterQuery query)
        {
            try
            {
                return Ok(getPosters.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // GET: api/Posters/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getPoster.Execute(id));
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

        // POST: api/Posters
        [HttpPost]
        public IActionResult Post([FromForm] PosterDto dto)
        {
            try
            {
                addPoster.Execute(dto);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // PUT: api/Posters/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PosterDto dto)
        {
            try
            {
                dto.Id = id;
                editPoster.Execute(dto);
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
                deletePoster.Execute(id);
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
