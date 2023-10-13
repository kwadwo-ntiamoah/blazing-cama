using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("offering")]
        public async Task<ActionResult<AppResponse<string>>> MakePayment()
        {
            return await _paymentService.SubmitOffering();
        }
    }
}
