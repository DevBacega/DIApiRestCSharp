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
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IAuth _authService;
        public CategoryController(ICategoryService categoryService, IAuth authService)
        {
            this._authService = authService;
            this._categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public ActionResult Get([FromHeader] string Token, [FromQuery] Categories request)
        {
            try
            {
                _authService.Authorization(Token);
                List<Categories> response = _categoryService.Select(request);
                return Ok(response);
            }
            catch (Exception ex)
            {

                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }


        // POST api/<CategoryController>
        [HttpPost]
        public ActionResult Post([FromBody] Categories request, [FromHeader] string Token)
        {
            try
            {
                _authService.Authorization(Token);
                Categories response = _categoryService.Create(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }

       
        [HttpPut()]
        public ActionResult Put([FromBody] Categories request, [FromHeader] string Token)
        {
            try
            {
                _authService.Authorization(Token);
                Categories response = _categoryService.Update(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromHeader] string Token,[FromHeader] int Access)
        {
            try
            {
                if (_authService.Authorization(Token) == true && _authService.IsAdmin(Access) == true)
                {
                    bool response = _categoryService.Delete(id);
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
