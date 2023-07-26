using DesafioDev.Domain.Entities;

namespace DesafioDev.Domain.Repositories;

public interface IEstablishmentRepository
{
    Task SaveAsync(ICollection<Establishment> establishment);
}