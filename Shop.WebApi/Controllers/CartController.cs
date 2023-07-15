using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Services.Carts;
using Shop.ViewModels.Cart;
using System;
using System.Threading.Tasks;

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "member")]
    public class CartController : ControllerBase
    {

        private ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            var list = await _cartService.GetAll(userId);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCartRequest request)
        {
            var res = await _cartService.AddToCart(request);
            if (!res.Status)
                return BadRequest();

            return Ok(res);
        }

        [HttpPatch("{cartId}/{newQuantity}")]
        public async Task<IActionResult> UpdateQuanity(int cartId, int newQuantity)
        {
            var res = await _cartService.UpdateQuanity(cartId, newQuantity);
            if (!res.Status)
                return BadRequest();
            return Ok(res);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var res = await _cartService.Delete(Id);
            if (!res.Status)
                return BadRequest();
            return Ok(res);
        }
    }
}
