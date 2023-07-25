using DesafioDev.Domain.Enums;

namespace DesafioDev.Domain.Entities
{
    public class Establishment
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Owner Owner { get; private set; }

        public List<Transaction> Transactions { get; private set; }

        public Establishment(string name, string cpf, string ownerName)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetOwner(cpf, ownerName);
            Transactions = new List<Transaction>();
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetOwner(string cpf, string name)
        {
            Owner = new Owner(cpf, name);
        }

        public void AddTransaction(TransactionType type, string date, decimal value, string card, TimeSpan hour)
        {
            Transactions.Add(new Transaction(type, date, value, card, hour));
        }
    }
}
