namespace DesafioDev.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IEstablishmentRepository TransactionRepository { get; }
        Task CommitAsync();
    }
}
