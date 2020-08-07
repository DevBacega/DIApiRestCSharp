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
    public class ProductController : ControllerBase
    {
        private IProductsService _productService;
        private IAuth _authService;
        public ProductController(IProductsService accessService, IAuth authService)
        {
            this._productService = accessService;
            this._authService = authService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult Get([FromHeader] string Token, [FromQuery] Products request)
        {
            try
            {
                _authService.Authorization(Token);
                List<Products> response = _productService.Select(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));

            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Products request, [FromHeader] string Token)
        {
            try
            {
                _authService.Authorization(Token);
                Products response = _productService.Create(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }

        // PUT api/<ProductsController>/
        [HttpPut]
        public ActionResult Put([FromBody] Products request, [FromHeader] string Token)
        {
            try
            {
                _authService.Authorization(Token);
                Products response = _productService.Update(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 403;
                return BadRequest(StatusCode(403, ex.Message));
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromHeader] string Token, [FromHeader] int Access)
        {
            try
            {
                if (_authService.Authorization(Token) == true )
                {
                    bool response = _productService.Delete(id, _authService.IsAdmin(Access));
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

