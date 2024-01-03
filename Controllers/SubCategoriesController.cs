using Crud.Dtos;
using Crud.Models;
using Crud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoriesServices _services;
        public SubCategoriesController(ISubCategoriesServices services) { _services = services; }

        [HttpGet]
        [Route("categories")]
        public IActionResult AllCategory()
        {
            return Ok(_services.AllSubCategories());
        }

        [HttpGet]
        [Route("byid/{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(_services.GetById(id));
        }
        [HttpPost]
        [Route("store")]

        public IActionResult Store(StoreSubCategoryDto subCategory)
        {

            if (ModelState.IsValid)
            {
                return Ok(_services.Store(subCategory));
            }
            else
                return BadRequest(new ErrorsDto { Message = "Error is Happen", Status = "error", ErrorCode = 404 });
        }

        [HttpPut]
        [Route("update/{id}")]

        public IActionResult Update(StoreSubCategoryDto subCategory,int id)
        {

            if (ModelState.IsValid)
            {
                return Ok(_services.Update(subCategory, id));
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
