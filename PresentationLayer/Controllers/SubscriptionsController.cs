using ApplicationLayer.Commands.Subscriptions;
using ApplicationLayer.Dtos.Subscriptions; 
using ApplicationLayer.Queries.Subscriptions; 
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [AuthorizeRoles(["MEMBER", "ADMIN"])]
    [Route("api/v1/subscriptions")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionsController(IMediator mediator)
        {
            _mediator = mediator;  
        }

        [HttpPost("purchase/{memberid}/{subscribtionid}")]
        public async Task<IActionResult> SubscriptionPurchase([FromRoute] string memberid, [FromRoute] string subscribtionid, [FromBody] PurchaseSubscriptionDto dto)
        {
            var command = new SubscriptionPurchaseCommand(
                memberid, subscribtionid, dto.PlanType, dto.StartDate, dto.DurationInDays, 
                dto.Amount, dto.Currency, dto.PaymentMethod, dto.Description
            );
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }

        [HttpPost("cancel/{subscribtionid}")]
        public async Task<IActionResult> CancelSubscription([FromRoute] string subscribtionid)
        {
            var command = new CancelSubscriptionCommand(subscribtionid);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }

        [HttpPost("upgrade/{memberid}/{subscribtionid}")]
        public async Task<IActionResult> UpgradeSubscription([FromRoute] string memberid, [FromRoute] string subscribtionid, [FromBody] UpgradeSubscriptionDto dto)
        {
            var command = new UpgradeSubscriptionCommand(
                memberid, subscribtionid, dto.StartDate, dto.EndDate, dto.PlanType, 
                dto.Amount, dto.Currency, dto.PaymentMethod, dto.Description
            );
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }

        [HttpGet("member/active/{memberid}")]
        public async Task<IActionResult> GetActiveSubscriptions([FromRoute] string memberid)
        {
            var query = new GetActiveSubscriptionsQuery(memberid);
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new { data = result }) :
                BadRequest(result.Message);
        }

        [HttpGet("member/payment-history/{memberid}")]
        public async Task<IActionResult> GetPaymentHistory([FromRoute] string memberid)
        {
            var query = new GetPaymentHistoryQuery(memberid);
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new { data = result }) :
                BadRequest(result.Message);
        }
    }
}
