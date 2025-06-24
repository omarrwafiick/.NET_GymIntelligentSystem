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
            return Ok();
        }

        [HttpGet("recommendation/nutrition-plan/{memberId}")]
        public async Task<IActionResult> GenerateSmartNutritionPlan([FromRoute] string memberId)
        {
            return Ok();
        }
    }
}
