using ApplicationLayer.Commands.Subscriptions;
using ApplicationLayer.Dtos.Subscriptions; 
using ApplicationLayer.Queries.Subscriptions; 
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

        [HttpPost("purchase/{memberid}")]
        public async Task<IActionResult> SubscriptionPurchase([FromRoute] string memberid, [FromBody] PurchaseSubscriptionDto dto)
        {
            var command = new SubscriptionPurchaseCommand(
                memberid, dto.PlanType, dto.StartDate, dto.DurationInDays, dto.Amount    
            );
            var result = await _mediator.Send(command);
            return !result ?
                BadRequest("Subscription request couldn't be fulfilled at the moment") :
                NoContent();
        }

        [HttpPost("cancel/{subscribtionid}")]
        public async Task<IActionResult> CancelSubscription([FromRoute] string subscribtionid)
        {
            var command = new CancelSubscriptionCommand(subscribtionid);
            var result = await _mediator.Send(command);
            return !result ?
                BadRequest("Subscription cancellation request couldn't be fulfilled at the moment") :
                NoContent();
        }

        [HttpPost("upgrade/{subscribtionid}")]
        public async Task<IActionResult> UpgradeSubscription([FromRoute] string subscribtionid)
        {
            var command = new UpgradeSubscriptionCommand(subscribtionid);
            var result = await _mediator.Send(command);
            return !result ?
                BadRequest("Subscription upgrade request couldn't be fulfilled at the moment") :
                NoContent();
        }

        [HttpGet("member/active/{memberid}")]
        public async Task<IActionResult> GetActiveSubscriptions([FromRoute] string memberid)
        {
            var query = new GetActiveSubscriptionsQuery(memberid);
            var result = await _mediator.Send(query);
            return !result.Any() ?
                NotFound($"No active subscription was found for member with id : {memberid}") :
                Ok(new { data = result });
        }

        [HttpGet("member/payment-history/{memberid}")]
        public async Task<IActionResult> GetPaymentHistory([FromRoute] string memberid)
        {
            var query = new GetPaymentHistoryQuery(memberid);
            var result = await _mediator.Send(query);
            return !result.Any() ?
                NotFound($"No payment history was found for member with id : {memberid}") :
                Ok(new { data = result });
        }
    }
}
