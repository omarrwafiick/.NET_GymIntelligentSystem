 

namespace ApplicationLayer.Queries.Reports
{ 
    public record GetTrainerWorkloadReportQuery(string TrainerId) : IRequest<ServiceResult<GetTrainerWorkloadReportDto>>;
}
