﻿ 
using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Dtos.Subscriptions
{ 
    public record PurchaseSubscriptionDto(
        [Required] string MemberId, [Required] PlanType PlanType, [Required] DateTime StartDate,
        [Required] int DurationInDays, [Required] decimal Amount);
    
    public record GetSubscriptionDto(
        string MemberId, PlanType PlanType,DateTime StartDate, DateTime EndDate, int DurationInDays, decimal Amount);
     
    public record GetPaymentHistoryDto(
            decimal Amount, CurrencyType Currency, PaymentMethod PaymentMethod,
            string TransactionId, DateTime PaidAt, string Description);
}
