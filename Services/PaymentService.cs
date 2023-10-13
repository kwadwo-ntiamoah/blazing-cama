using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentService
    {
        private readonly PaymentRepo _paymentRepo;
        private readonly HubtelService _hubtel;

        public PaymentService(PaymentRepo paymentRepo, HubtelService hubtel)
        {
            _paymentRepo = paymentRepo;
            _hubtel = hubtel;
        }

        public async Task<AppResponse<string>> SubmitOffering()
        {
            var response = new AppResponse<string>();

            try
            {
                await Task.Delay(300);
                response.Data = _hubtel.PushPayment();
                response.Status = HttpStatusCode.OK;

                return response;
            }
            catch (Exception)
            {
                response.Status = HttpStatusCode.InternalServerError;
                response.Message = "An error occurred. Try again later";

                return response;
            }
        }
    }
}
