using DesafioDev.Application.Abstractions.Query;
using DesafioDev.Application.Response;
using DesafioDev.Domain.Repositories;

namespace DesafioDev.Application.Features.Establishment;

public class EstablishmentQueryHandler : IQueryHandler<EstablishmentQuery, IEnumerable<EstablishmentQueryResponse>>
{
    readonly IEstablishmentRepository _repository;

    public EstablishmentQueryHandler(IEstablishmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EstablishmentQueryResponse>> Handle(EstablishmentQuery request, CancellationToken cancellationToken)
    {
        var list = await _repository.GetAllAsync();

        return list.Select(_ => new EstablishmentQueryResponse(_.Name, 
                                new OwnerQueryResponse(_.Owner.Cpf, _.Owner.Name), 
                                _.Transactions.Select(_ => new TransactionQueryResponse(_.Type.ToString(), _.Date, _.Value, _.Card, _.Hour)),
                                _.CalculateTotalEntryValue(),
                                _.CalculateTotalExitValue(),
                                _.CalculateTotalBalance())) ?? new List<EstablishmentQueryResponse>();
    }
}

