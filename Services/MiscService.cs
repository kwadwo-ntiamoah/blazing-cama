using Data;
using Data.DTOs;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MiscService
    {
        private readonly SubscriptionRepo _subsRepo;
        private readonly DayRepo _dayRepo;

        public MiscService(SubscriptionRepo subsRepo, DayRepo dayRepo)
        {
            _subsRepo = subsRepo;
            _dayRepo = dayRepo;
        }

        public async Task<AppResponse<List<Subscription>>> GetSubscriptions()
        {
            var response = new AppResponse<List<Subscription>>();

            try
            {
                var subscriptions = await _subsRepo.GetSubscriptions();

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

        public async Task<AppResponse<List<Day>>> GetDays()
        {
            var response = new AppResponse<List<Day>>();

            try
            {
                var days = await _dayRepo.Days();

                response.Status = System.Net.HttpStatusCode.OK;
                response.Data = days;

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
