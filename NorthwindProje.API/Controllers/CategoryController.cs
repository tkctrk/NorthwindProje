using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindProje.BL.Abstract;
using NorthwindProje.BL.Concrete;
using NorthwindProje.Entities;

namespace NorthwindProje.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IGeneralService<Category> _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryManager();
        }

        [HttpGet]
        public IActionResult Get()
        {            
            return Ok(_categoryService.GetAllT());
        }
    }
}
