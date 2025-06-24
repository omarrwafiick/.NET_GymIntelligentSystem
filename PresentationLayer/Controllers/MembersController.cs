using ApplicationLayer.Dtos;
using ApplicationLayer.Dtos.Feedbacks;
using ApplicationLayer.Dtos.Members;
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/v1/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterMemberDto dto)
        {
            //var command = new RegisterMemberCommand();
            //var id = await _mediator.Send(command);
            var id = 1;
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        { 
            return Ok();
        }

        [HttpPost("{userid}/workout")]
        public async Task<IActionResult> CreateWorkoutLog([FromBody] CreateWorkoutLogDto dto)
        {
            return Ok();
        }

        [HttpGet("{userid}/workouts/log")]
        public async Task<IActionResult> GetWorkoutLogs([FromRoute] string userid)
        {
            return Ok();
        }

        [HttpPost("{userid}/nutrition")]
        public async Task<IActionResult> CreateNutritionPlan([FromRoute] string userid, [FromBody] CreateNutritionPlanDto dto)
        {
            return Ok();
        }

        [HttpGet("{userid}/nutrition")]
        public async Task<IActionResult> GetNutritionPlan([FromRoute] string userid)
        {
            return Ok();
        }

        [HttpGet("{userid}/progress")]
        public async Task<IActionResult> GetProgressReport([FromRoute] string userid)
        {
            return Ok();
        }
    }
}
