using HM_webapi_5.Interfeses; 
using HM_webapi_5.Models; 
using HM_webapi_5.Servises;
using Microsoft.AspNetCore.Mvc;

namespace HM_webapi_5.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductsController : Controller
    {
        private readonly IProductsServises _productsServises; 

        public ProductsController(IProductsServises productsServises)
        {
            _productsServises = productsServises;
        }

        [HttpGet("getProducts")]
        public IActionResult getProducts(
        [FromQuery] int? startWith,
        [FromQuery] int? endWith)
        {
          if (_productsServises.get_product_by_indexes(startWith, endWith) != null)
          {
                return Ok(new
                {
                    status = 200,
                    message = "Products retrieved successfully" , 
                    data = _productsServises.get_product_by_indexes(startWith, endWith)
                });
          }
          else
          {
            return BadRequest(new
            {
                status = 400,
                message = "Invalid start or end position" 
            });
          }
        }


        [HttpPost("addProduct")] 
        public IActionResult addProduct([FromBody] products product)
        {
            _productsServises.add_product(product);
            
            return Ok(new
            {
                status = 200,
                message = "Product added successfully"
            });
        }

        [HttpDelete("removeProduct")]
        public IActionResult removeProduct([FromQuery] Guid productId)
        {
            _productsServises.remove_product(productId);

            return Ok(new
            {
                status = 200,
                message = "Product removed successfully"
            });
        }



    }
}
