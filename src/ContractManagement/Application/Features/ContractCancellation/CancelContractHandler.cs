namespace Contractmanagement.Features.ContractCancellation;

public class CancelContractHandler : ICommandHandler<CancelContract>
{
    private readonly IAggregateService<EventSourcedEntityId, Contract> _aggregateService;

    public CancelContractHandler(IAggregateService<EventSourcedEntityId, Contract> aggregateService)
    {
        _aggregateService = aggregateService;
    }

    public async ValueTask HandleAsync(CancelContract command)
    {
        var contract = await _aggregateService.RehydrateAsync(command.ContractNumber, command.ExpectedVersion);
        await contract.CancelContract(command);
        await _aggregateService.ProcessChangesAsync(contract);
    }
}