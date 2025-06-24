
using ApplicationLayer.Dtos.Trainers;
using MediatR; 

namespace ApplicationLayer.Queries.Reports
{ 
    public record GetTrainerWorkloadReportQuery(string TrainerId) : IRequest<GetTrainerWorkloadReportDto>;
}
