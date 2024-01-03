using Crud.Dtos;
using Crud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _services;
        public ProductsController(IProductsServices productsServices)
        {
            _services = productsServices;
        }

        [HttpGet]
        [Route("products")]
        public IActionResult AllCategory()
        {
            return Ok(_services.AllProducts());
        }

        [HttpGet]
        [Route("byid/{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(_services.GetById(id));
        }
        [HttpPost]
        [Route("store")]

        public IActionResult Store(StoreProductDto product)
        {

            if (ModelState.IsValid)
            {
                return Ok(_services.Store(product));
            }
            else
                return BadRequest(new ErrorsDto { Message = "Error is Happen", Status = "error", ErrorCode = 404 });
        }

        [HttpPut]
        [Route("update/{id}")]

        public IActionResult Update(StoreProductDto product, int id)
        {

            if (ModelState.IsValid)
            {
                return Ok(_services.Update(product, id));
            }
            else
                return BadRequest(new ErrorsDto { Message = "Error is Happen", Status = "error", ErrorCode = 404 });
        }

        [HttpDelete]
        [Route("delete/{id}")]

        public IActionResult Delete(int id)
        {

            if (ModelState.IsValid)
            {
                return Ok(_services.Delete(id));
            }
            else
                return BadRequest(new ErrorsDto { Message = "Error is Happen", Status = "error", ErrorCode = 404 });
        }
    }
}
