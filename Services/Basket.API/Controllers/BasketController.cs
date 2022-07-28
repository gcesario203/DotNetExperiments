using System.Net;
using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Basket.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repo;
        private readonly ILogger<BasketController> _logger;

        private readonly DiscountService _discountService;

        public BasketController(IBasketRepository repository, ILogger<BasketController> logger, DiscountService discountService)
        {
            _repo = repository;
            _logger = logger;
            _discountService = discountService;
        }

        [Route("{userName}", Name = "GetCart")]
        [HttpGet]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetCart(string userName)
        {
            return Ok(await _repo.GetBasket(userName) ?? new ShoppingCart(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateCart([FromBody] ShoppingCart cart)
        {
            // TODO::CONSUME GRPC METHODS]
            foreach(var item in cart.Items)
            {
                var coupon = await _discountService.GetDiscount(item.Product.Name);

                item.Quantity -= coupon.Amount;
            }

            return Ok(await _repo.UpdateBasket(cart));
        }

        [HttpDelete("{userName}", Name = "DeleteCart")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> DeleteCart(string userName)
        {
            await _repo.DeleteBasket(userName);

            return Ok();
        }
    }
}