using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Reports;
using DomainLayer.Entities;
using DomainLayer.Enums;
using MediatR;

namespace ApplicationLayer.Handlers.Reports
{
    public class GetRevenueReportQueryHandler : IRequestHandler<GetRevenueReportQuery, GetRevenueReportDto>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetRevenueReportQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<GetRevenueReportDto?> Handle(GetRevenueReportQuery request, CancellationToken cancellationToken)
        {  
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return null;

            var member = await _repository.GetAsync(memberId);

            if (member is null) return null;

            var subscriptions = member.Subscriptions;
            var paymentHistory = member.PaymentHistory;

            decimal totalAmount = 0;
            foreach (var payment in paymentHistory)
            {
                totalAmount += payment.Amount;
            }

            var now = DateTime.UtcNow;
            var startOfLastMonth = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
            var endOfLastMonth = new DateTime(now.Year, now.Month, 1).AddDays(-1);
            var startOfCurrentMonth = new DateTime(now.Year, now.Month, 1); 

            var lastMonthRevenue = paymentHistory
                .Where(p => p.PaidAt >= startOfLastMonth && p.PaidAt <= endOfLastMonth)
                .Sum(p => p.Amount);

            var canceledSubscriptionsThisMonth = subscriptions
                .Where(s =>
                    s.StartDate >= startOfCurrentMonth && s.EndDate <= now &&
                    s.Status == SubscriptionStatus.Cancelled)
                .Count();

            return paymentHistory.Any() ?
                new GetRevenueReportDto(
                      totalAmount,
                      subscriptions.Count(),
                      subscriptions.Where(s => s.IsActive()).Count(),
                      lastMonthRevenue,
                      canceledSubscriptionsThisMonth
                )
                :
                null;
        }
    }
}
