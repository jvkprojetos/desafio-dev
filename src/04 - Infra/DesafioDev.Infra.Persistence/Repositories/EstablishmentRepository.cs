using DesafioDev.Domain.Entities;
using DesafioDev.Domain.Repositories;

namespace DesafioDev.Infra.Persistence.Repositories;

internal class EstablishmentRepository : IEstablishmentRepository
{
    private readonly ApplicationDbContext _context;

    public EstablishmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(ICollection<Establishment> establishment)
    {
        await _context.Establishments.AddRangeAsync(establishment);        
    }
}
