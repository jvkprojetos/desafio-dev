using DesafioDev.Application.Abstractions.Command;
using DesafioDev.Application.Helpers;
using DesafioDev.Domain.Entities;
using DesafioDev.Domain.Enums;

namespace DesafioDev.Application.Features.File
{
    internal sealed class UploadFileCommandHandler : ICommandHandler<UploadFileCommand, object>
    {
        public async Task<object> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            List<Establishment> establishments = new();
            var fileConverted = request.File.ReadAndConvertInListString();

            fileConverted.ForEach(line =>
            {
                var type = line[0..1];
                var date = line[1..9];
                var value = line[9..19];
                var cpf = line[19..30];
                var card = line[30..42];
                var hour = line[42..48];
                var ownerName = line[48..62];
                var name = line[62..80];

                Establishment? establishment = establishments.FirstOrDefault(_ => _.Name == name);
                if(establishment is not null)
                {
                    establishments.Remove(establishment);
                }

                establishment ??= new Establishment(name, cpf, ownerName);

                establishment.AddTransaction((TransactionType)Convert.ToInt16(type), date, Convert.ToDecimal(value), card, TimeSpan.Parse(hour));
                establishments.Add(establishment);
            });

            return establishments;
        }
    }
}
