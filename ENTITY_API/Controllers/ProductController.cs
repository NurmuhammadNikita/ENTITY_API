using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;

namespace ENTITY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpPost]
        //Create uchun

        public async Task<IActionResult> CreateProduct([FromForm] ProductDto productDto)
        {
            await productRepository.CreateProductAsync(productDto);

            return Ok("Created");
        }




        [HttpGet("productid")]
        public async Task<IActionResult> GetProductId(Guid productId)
        {
            var product = await productRepository.GetProductByIdAsync(productId);
            return Ok(product);
        }




        [HttpGet]

        public async Task<IActionResult> GetAllClents()
        {
            var products = await productRepository.GetAllAsync();

            return Ok(products);
        }




        [HttpPut("productId")]
        public async Task<IActionResult> GetProductId(Guid productId, [FromForm] ProductDto productDto)
        {
            await productRepository.UpdateProductAsync(productId, productDto);
            return Ok("Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            await productRepository.DeleteProductAsync(productId);

            return Ok("Deleted");
        }
    }
}
