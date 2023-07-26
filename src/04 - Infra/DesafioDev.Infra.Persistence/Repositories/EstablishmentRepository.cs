using DesafioDev.Domain.Entities;
using DesafioDev.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioDev.Infra.Persistence.Repositories
{
    internal class EstablishmentRepository : IEstablishmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EstablishmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Establishment>> GetAllAsync()
        {
            return await _context.Establishments.ToListAsync();
        }

        public async Task SaveAsync(ICollection<Establishment> establishment)
        {
            await _context.Establishments.AddRangeAsync(establishment);
        }
    }
}
