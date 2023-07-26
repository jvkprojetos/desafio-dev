using DesafioDev.Domain.Repositories;
using DesafioDev.Infra.Persistence.Repositories;

namespace DesafioDev.Infra.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private IEstablishmentRepository _transactionRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEstablishmentRepository TransactionRepository
    {
        get 
        {
            _transactionRepository ??= new EstablishmentRepository(_context);
            return _transactionRepository;
        }
    }

    public async Task CommitAsync()
        => await _context.SaveChangesAsync();
}
