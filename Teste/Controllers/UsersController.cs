using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Teste.Domain;
using Teste.Models;
using Teste.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _userService;
        private IAuth _authService;
        public UsersController(IUsersService userService, IAuth authService)
        {
            this._userService = userService;
            this._authService = authService;
        }
        // GET: api/<UsersController>
        [HttpGet()]
        public ActionResult Get([FromHeader] string Token, [FromQuery] Users request)
        {
            try {        
            _authService.Authorization(Token);
            List<Users> response = _userService.Select(request);
            return Ok(response);
            } catch (Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));

            }
        }



        [HttpPost("login")]
        public ActionResult Post([FromBody] Auth user)
        {
            try
            {
                Auth response = _authService.Login(user);
                return Ok(response);
            }catch(Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Users request, [FromHeader] string Token)
        {
            try
            {
                _authService.Authorization(Token);
                Users response = _userService.Create(request);
                return Ok(response);
            } catch (Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }

        // PUT api/<UsersController>/
        [HttpPut]
        public ActionResult Put([FromBody] Users request, [FromHeader] string Token)
        {
            try
            {
                _authService.Authorization(Token);
                Users response = _userService.Update(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromHeader] string Token,[FromHeader] int Access)
        {
            try
            {
                if (_authService.Authorization(Token) == true)
                {
                    bool response = _userService.Delete(id, _authService.IsAdmin(Access));
                    return Ok(response);
                }
                else
                {
                    throw new Exception("Sem Permissão para acessas.");
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }
    }
}
