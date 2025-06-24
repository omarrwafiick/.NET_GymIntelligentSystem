using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Dtos.Subscriptions;
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/v1/subscriptions")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionsController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("purchase/{subscriberid}")]
        public async Task<IActionResult> SubscriptionPurchase([FromRoute] string subscriberid, [FromBody] PurchaseSubscriptionDto dto)
        {
            return Ok();
        }

        [HttpPost("cancel/{subscribtionid}")]
        public async Task<IActionResult> CancelSubscription([FromRoute] string subscribtionid)
        {
            return Ok();
        }

        [HttpPost("upgrade/{subscribtionid}")]
        public async Task<IActionResult> UpgradeSubscription([FromRoute] string subscribtionid)
        {
            return Ok();
        }

        [HttpGet("member/active/{subscriberid}")]
        public async Task<IActionResult> GetActiveSubscriptions([FromRoute] string subscriberid)
        {
            return Ok();
        }

        [HttpGet("member/payment-history/{memberid}")]
        public async Task<IActionResult> GetPaymentHistory([FromRoute] string memberid)
        {
            return Ok();
        }
    }
}
