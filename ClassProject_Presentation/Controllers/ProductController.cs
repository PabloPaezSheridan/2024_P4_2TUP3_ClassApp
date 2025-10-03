using Application.Services;
using Infrastructure.ExternalServices.PokeApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassProject_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductService _productService { get; set; }
        public BerryService _berryService { get; set; }

        public ProductController(ProductService productService, BerryService berryService) 
        {
            _productService = productService;
            _berryService = berryService;
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

        [HttpGet("berry/{id}")]
        public async Task<ActionResult> GetBerries(int id)
        {
            return Ok(await _berryService.GetBerries(id));
        }
    }
}
