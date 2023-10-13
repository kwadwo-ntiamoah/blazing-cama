using Data.DTOs;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopService _shopService;

        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<AppResponse<List<Category>>>> GetItemCategories()
        {
            return await _shopService.GetShopCategories();
        }

        [HttpGet("items")]
        public async Task<ActionResult<AppResponse<List<Item>>>> GetShopItems()
        {
            return await _shopService.GetShopItems();
        }

        [HttpPost("createOrder")]
        public async Task<ActionResult<AppResponse<Order>>> CreateOrder(CreateOrderDto dto)
        {
            return await _shopService.CreateOrder(dto);
        }
    }
}
