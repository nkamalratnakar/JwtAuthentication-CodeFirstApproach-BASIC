using JwtAuthentication.Data;
using JwtAuthentication.Model;
using JwtAuthentication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class ManageLoginsController : ControllerBase
    {
        private readonly ILogin _login;
        public ManageLoginsController(ILogin login)
        {
            _login = login;
        }
        // GET: api/<ManageLoginsController>
        [HttpGet("GetAllLogins")]
        public IActionResult Get()
        {
            var login = _login.Get();
            if (login != null)
                return new ObjectResult(login) { StatusCode = StatusCodes.Status200OK };
            else return new ObjectResult(login) { StatusCode = StatusCodes.Status204NoContent };
        }

        // GET api/<ManageLoginsController>/5
        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            Login login = _login.Get(id);
            if (login != null)
                return new ObjectResult(login) { StatusCode = StatusCodes.Status302Found };
            else return new ObjectResult(login) { StatusCode = StatusCodes.Status404NotFound };
        }

        // POST api/<ManageLoginsController>
        [HttpPost("{AddLogin}")]
        public IActionResult Post([FromBody] Login login)
        {
            try
            {
                _login.Post(login);
                return new ObjectResult(login) { StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        // PUT api/<ManageLoginsController>/5
        [HttpPut("UpdateLogin")]
        public IActionResult Put([FromBody] Login login)
        {
            try
            {
                if (login == null)
                    return NotFound();

                _login.Put(login);
                return new ObjectResult(login) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = StatusCodes.Status422UnprocessableEntity };

            }
        }

        // DELETE api/<ManageLoginsController>/5
        [HttpDelete("DeleteLogin/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _login.Delete(id);
                return new ObjectResult(id) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = StatusCodes.Status422UnprocessableEntity };

            }
        }
    }
}
