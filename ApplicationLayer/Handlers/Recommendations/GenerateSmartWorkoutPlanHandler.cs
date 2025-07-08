
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Recommendations;
using ApplicationLayer.Queries.Recommendations;
using DomainLayer.Entities;
using DomainLayer.Enums;
using MediatR; 

namespace ApplicationLayer.Handlers.Recommendations
{
    public class GenerateSmartWorkoutPlanQueryHandler : IRequestHandler<GenerateSmartWorkoutPlanQuery, SmartWorkoutPlanDto>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GenerateSmartWorkoutPlanQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<SmartWorkoutPlanDto> Handle(GenerateSmartWorkoutPlanQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid trainerId)) return null;

            var member = await _repository.GetAsync(trainerId);

            if (member is null) return null;
            //we recommend basic if user is using free plans to make him incrementaly subscribe 
            //and make him get premium in case he is on basic plan 
            var planType = member.WorkoutPlans.Select(x=> x.PlanType == PlanType.FREE).ToList().Count() > 10 ?
                PlanType.BASIC :
                PlanType.PREMIUM; 

            var days = member.WorkoutPlans.Select(x => x.DurationInDays).ToList().Average();

            var lastPlan = member.WorkoutPlans.LastOrDefault();

            var planStartDate = lastPlan.StartDate.AddDays(lastPlan.DurationInDays);

            var recentFocuses = member.WorkoutPlans 
                  .OrderByDescending(ws => ws.StartDate)
                  .Take(3)
                  .Select(ws => ws.FocusArea)
                  .ToList();

            var focusArea = "";
            var sets = 0;
            var reps = 0;
            var random = new Random();
            var exerciseType = ExerciseType.BICEPS_CURL;

            switch (member.Goal)
            {
                case Goal.BUILD_MUSCLE:
                    focusArea = "Push" + "Pull" + "Legs" + recentFocuses;
                    sets = random.Next(3, 5);
                    reps = random.Next(8, 12);
                    break;

                case Goal.LOSE_WEIGHT:
                    focusArea = "Cardio" + "Full Body" + "Core" + recentFocuses;
                    sets = random.Next(2, 4);
                    reps = random.Next(12, 15);
                    break;

                case Goal.INCREASE_STRENGTH:
                    focusArea = "Upper Strength" + "Lower Strength" + recentFocuses;
                    sets = random.Next(4, 6);
                    reps = random.Next(3, 6);
                    break;

                case Goal.IMPROVE_CARDIO :
                    focusArea = recentFocuses.ToString();
                    sets = random.Next(3, 5);
                    reps = random.Next(15, 20);
                    break; 

                case Goal.MAINTAIN_WEIGHT:
                    focusArea = recentFocuses.ToString();
                    sets = random.Next(3, 5);
                    reps = random.Next(8, 12);
                    break;

                default:
                    focusArea = "Full Body";
                    sets = random.Next(3, 5);
                    reps = random.Next(8, 12);
                    break;
            }

            exerciseType = member.WorkoutLogs
                                .GroupBy(x=> x.ExerciseType)
                                .OrderBy(x=>x.Count())
                                .LastOrDefault()
                                .Select(x=>x.ExerciseType)
                                .LastOrDefault();

            var exercise = new SmartWorkoutExerciseDto(exerciseType, sets, reps);

            var sessions = new SmartWorkoutSessionDto(planStartDate.AddDays(7), focusArea, exercise);

            return new SmartWorkoutPlanDto(planType, (int) days, planStartDate, sessions);
        }
    }
}
