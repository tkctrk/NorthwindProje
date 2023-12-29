using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindProje.BL.Abstract;
using NorthwindProje.BL.Concrete;
using NorthwindProje.Entities;

namespace NorthwindProje.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IGeneralService<Product> _productService;
        public ProductController()
        {
            _productService = new ProductManager();
        }
        [HttpGet]
        public ActionResult Get() 
        {
            return Ok(_productService.Serch(x=>x.ProductId>0));
        }
    }
}
