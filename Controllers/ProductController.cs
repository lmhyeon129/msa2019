using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using donation_MERCHANT.Models;
using donation_MERCHANT.Repositories;

namespace donation_MERCHANT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _productRepository.FindAllAsync();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet("{prodId}")]
        public async Task<ActionResult<Product>> Get(string prodId)
        {
            var product = await _productRepository.FindOneByIdAsync(prodId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            await _productRepository.CreateAsync(product);
            return CreatedAtAction(nameof(Get), new {prodId=product.ProdId}, product);
        }
        [HttpPut("{prodId}")]
        public async Task<ActionResult> Put(string prodId, [FromBody] Product product)
        {
            if (prodId != product.ProdId)
            {
                return BadRequest();
            }
            await _productRepository.Update(product);
            return NoContent();
        }
        [HttpDelete("{prodId}")]
        public async Task<ActionResult> Delete(string prodId)
        {
            var target = _productRepository.FindOneByIdAsync(prodId);
            if (target == null)
            {
                return NotFound();
            }
            await _productRepository.Delete(target.Result);
            return NoContent();
        }
    }
}