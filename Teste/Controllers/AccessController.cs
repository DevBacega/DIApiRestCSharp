using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Domain;
using Teste.Models;
using Teste.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private IAccessService _accessService;
        private IAuth _authService;
        public AccessController(IAccessService accessService, IAuth authService)
        {
            this._accessService = accessService;
            this._authService = authService;
        }
        
        // GET: api/<AccessController>
        [HttpGet]
        public ActionResult Get([FromHeader] string Token, [FromQuery] Access request)
        {
            try
            {
                _authService.Authorization(Token);
                List<Access> response = _accessService.Select(request);
                return Ok(response);
            }
            catch (Exception ex)
            {

                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }

        // POST api/<AccessController>
        [HttpPost]
        public ActionResult Post([FromBody] Access request, [FromHeader] string Token)
        {
            try
            {
                _authService.Authorization(Token);
                Access response = _accessService.Create(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }

        // PUT api/<AccessController>/5
        [HttpPut()]
        public ActionResult Put([FromBody] Access request, [FromHeader] string Token)
        {

            try
            {
                _authService.Authorization(Token);
                Access response = _accessService.Update(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }

        // DELETE api/<AccessController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromHeader] string Token, [FromHeader] int Access)
        {
            try
            {
                if(_authService.Authorization(Token) == true && _authService.IsAdmin(Access) == true)
                { 
                    bool response = _accessService.Delete(id);
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
