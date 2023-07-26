using DesafioDev.Domain.Entities;

namespace DesafioDev.Application.Interfaces
{
    public interface IFileServices
    {
        ICollection<Establishment> DesserializeValuesForEstablishment(List<string> lines); 
    }
}
