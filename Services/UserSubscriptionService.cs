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
    public class UserSubscriptionService
    {
        private readonly UserSubscriptionRepo _uSubsRepo;

        public UserSubscriptionService(UserSubscriptionRepo uSubsRepo)
        {
            _uSubsRepo = uSubsRepo;
        }

        public async Task<AppResponse<UserSubscription>> AddUserSubscription(string UserId, CreateUserSubDto dto)
        {
            var response = new AppResponse<UserSubscription>();

            try
            {
                var temp = new UserSubscription
                {
                    UserId = UserId,
                    SubscriptionId = dto.SubscriptionId
                };

                var subscriptions = await _uSubsRepo.AddUserSubscription(temp);

                response.Status = System.Net.HttpStatusCode.OK;
                response.Data = subscriptions;

                return response;
            }
            catch (Exception)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Message = "Sorry an error occurred. Try again later";

                return response;
            }
        }

        public Task ActivateUserSubscription()
        {
            return Task.CompletedTask;
        }
    }
}
