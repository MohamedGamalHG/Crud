using Crud.Dtos;
using Crud.Models;
using Crud.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices _services;
        public CategoriesController(ICategoriesServices services) { _services = services; }

        [HttpGet]
        [Route("categories")]
        public IActionResult AllCategory()
        {
            return Ok(_services.AllCategories());
        }

        [HttpGet]
        [Route("byid/{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(_services.GetById(id));
        }
        [HttpPost]
        [Route("store")]

        public IActionResult Store(StoreCategoryDto category)
        {

            if (ModelState.IsValid)
            {
                return Ok(_services.Store(category));
            }
            else
                return BadRequest(new ErrorsDto { Message = "Error is Happen", Status = "error", ErrorCode = 404 });
        }

        [HttpPut]
        [Route("update/{id}")]

        public IActionResult Update(StoreCategoryDto category,int id)
        {

            if (ModelState.IsValid)
            {
                return Ok(_services.Update(category,id));
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
