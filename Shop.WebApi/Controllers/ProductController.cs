using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Services.Products;
using Shop.ViewModels.Products;
using System.Threading.Tasks;

namespace EShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _productService.GetAll();
            return Ok(list);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] GetPublicProductPagingRequest request)
        {
            var list = await _productService.GetAllByCategoryId(request);
            return Ok(list);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(int productId)
        {
            var res = await _productService.GetById(productId);
            if (res.Status)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpPost]
       // [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromBody]ProductCreateRequest request)
        {
            var res = await _productService.Create(request);
            if (res.Status)
                return Created(nameof(GetById), res);
            return BadRequest(res);

        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update([FromBody]ProductUpdateRequest request)
        {
            var res = await _productService.Update(request);
            if (res.Status)
                return Ok();
            return BadRequest(res);
        }

        [HttpPatch("update-price/{id}/{newPrice}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice)
        {
            var res = await _productService.UpdatePrice(id, newPrice);
            if (res.Status)
                return Ok();
            return BadRequest(res);
        }

        [HttpPatch("update-quantity/{id}/{quantity}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            var res = await _productService.UpdateStock(id, quantity);
            if (res.Status)
                return Ok();
            return BadRequest(res);
        }

        [HttpDelete]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _productService.Delete(id);
            if (res.Status)
                return Ok();
            return BadRequest(res);
        }
    }
}
