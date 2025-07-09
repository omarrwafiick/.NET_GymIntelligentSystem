using ApplicationLayer.Queries.Recommendations; 
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [AuthorizeRoles("MEMBER")]
    [Route("api/v1/recommendations")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecommendationsController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpGet("recommendation/workout-plan/{memberId}")]
        public async Task<IActionResult> GenerateSmartWorkoutPlan([FromRoute] string memberId)
        {
            var query = new GenerateSmartWorkoutPlanQuery(memberId);
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new { data = result }) :
                BadRequest(result.Message); 
        }

        [HttpGet("recommendation/nutrition-plan/{memberId}")]
        public async Task<IActionResult> GenerateSmartNutritionPlan([FromRoute] string memberId)
        {
            var query = new GenerateSmartNutritionPlanQuery(memberId);
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new { data = result }) :
                BadRequest(result.Message);
        }
    }
}
