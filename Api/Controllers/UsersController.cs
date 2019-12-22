using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.ApiResponse;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.UserCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGetUsersCommand getUsers;
        private readonly IGetUserCommand getUser;
        private readonly IAddUserCommand addUser;
        private readonly IEditUserCommand editUser;
        private readonly IDeleteUserCommand deleteUser;

        public UsersController(IGetUsersCommand getUsers, IGetUserCommand getUser, IAddUserCommand addUser, IEditUserCommand editUser, IDeleteUserCommand deleteUser)
        {
            this.getUsers = getUsers;
            this.getUser = getUser;
            this.addUser = addUser;
            this.editUser = editUser;
            this.deleteUser = deleteUser;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get([FromQuery]UserQuery query)
        {
            try
            {
                return Ok(getUsers.Execute(query));
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Errors = new List<string> { e.Message }
                });
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getUser.Execute(id));
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

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] AddUserDto dto)
        {
            try
            {
                addUser.Execute(dto);
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

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ShowUserDto dto)
        {
            try
            {
                dto.Id = id;
                editUser.Execute(dto);
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
                deleteUser.Execute(id);
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
