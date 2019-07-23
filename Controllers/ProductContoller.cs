using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using donation_MERCHANT.Models;
namespace donation_MERCHANT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductContoller : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return null;
        }
        [HttpGet("{prodId}")]
        public async Task<ActionResult<Product>> Get(string prodId)
        {
            return null;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            return null;
        }
        [HttpPut("{prodId}")]
        public async Task<ActionResult> Put(string prodId, [FromBody] Product product)
        {
            return NoContent();
        }
        [HttpDelete("{prodId}")]
        public async Task<ActionResult> Delete(string prodId)
        {
            return NoContent();
        }
    }
}