using ApplicationLayer.Queries.Recommendations; 
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
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
            return result is null ?
                BadRequest($"Generation of a smart workout plan couldn't be created to member with id : {memberId}") :
                Ok(new { data = result });
        }

        [HttpGet("recommendation/nutrition-plan/{memberId}")]
        public async Task<IActionResult> GenerateSmartNutritionPlan([FromRoute] string memberId)
        {
            var query = new GenerateSmartNutritionPlanQuery(memberId);
            var result = await _mediator.Send(query);
            return result is null ?
                BadRequest($"Generation of a smart nutrition plan couldn't be created to member with id : {memberId}") :
                Ok(new { data = result });
        }
    }
}
