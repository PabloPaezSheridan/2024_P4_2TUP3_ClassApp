using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassProject_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductService _productService { get; set; }

        public ProductController(ProductService productService) 
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpPost]
        public IActionResult Add([FromBody] string name)
        {
            _productService.AddProduct(new Domain.Entities.Product() { Name = name });
            return Ok();
        }
    }
}
