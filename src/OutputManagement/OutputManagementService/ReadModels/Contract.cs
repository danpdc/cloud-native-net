using ContractManagement.Domain.Aggregates.ContractAggregate.Enums;

namespace OutputManagementService.ReadModels;

public record Contract(
    string ContractNumber,
    string CustomerNumber,
    string ProductNumber,
    decimal Amount,
    DateTime StartDate,
    DateTime EndDate,
    PaymentPeriod Paymentperiod,
    bool ContractSent);
