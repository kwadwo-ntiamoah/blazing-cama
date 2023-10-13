using Data.DTOs;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ShopService
    {
        private readonly CategoryRepo _catRepo;
        private readonly ItemRepo _itemRepo;
        private readonly OrderRepo _orderRepo;

        public ShopService(CategoryRepo catRepo, ItemRepo itemRepo, OrderRepo orderRepo)
        {
            _catRepo = catRepo;
            _itemRepo = itemRepo;
            _orderRepo = orderRepo;
        }

        public async Task<AppResponse<List<Category>>> GetShopCategories()
        {
            var response = new AppResponse<List<Category>>();

            try
            {
                var categories = await _catRepo.GetCategories();

                response.Data = categories;
                response.Status = System.Net.HttpStatusCode.OK;

                return response;
            }
            catch (Exception)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Message = "An error occurred. Try again later";

                return response;
            }
        }

        public async Task<AppResponse<List<Item>>> GetShopItems()
        {
            var response = new AppResponse<List<Item>>();

            try
            {
                var items = await _itemRepo.GetItems();

                response.Data = items;
                response.Status = System.Net.HttpStatusCode.OK;

                return response;
            }
            catch (Exception)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Message = "An error occurred. Try again later";

                return response;
            }
        }

        public async Task<AppResponse<Order>> CreateOrder(CreateOrderDto dto)
        {
            var response = new AppResponse<Order>();

            try
            {
                decimal totalSum = 0;

                var order = new Order
                {
                    CityTown = dto.CityTown,
                    Country = dto.Country,
                    CustomerEmail = dto.CustomerEmail,
                    CustomerName = dto.CustomerName,
                    CustomerPhone = dto.CustomerPhone,
                };

                // create order Items
                List<OrderItem> tempOrderItems = dto.OrderItems.Select(x => new OrderItem
                {
                    ItemId = x.ItemId,
                    OrderId = order.Id,
                    Quantity = x.Quantity
                }).ToList();

                await _orderRepo.CreateOrderItems(tempOrderItems);

                foreach (var orderItem in tempOrderItems)
                {
                    var tempItem = _itemRepo.GetItem(orderItem.ItemId);
                    totalSum += tempItem.Price;
                }

                order.TotalPrice = totalSum.ToString();
                var newOrder = await _orderRepo.CreateOrder(order);

                if (newOrder != null)
                {
                    response.Status = System.Net.HttpStatusCode.OK;
                    response.Data = newOrder;

                    return response;
                }

                response.Message = "An error occurred placing order. Try again later";
                response.Status = System.Net.HttpStatusCode.BadRequest;

                return response;
            }
            catch (Exception)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Message = "Sorry an error occurred. Try again later";

                return response;
            }
        }
    }
}
