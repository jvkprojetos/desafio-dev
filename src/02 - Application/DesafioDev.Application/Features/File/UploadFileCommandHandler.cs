using DesafioDev.Application.Abstractions.Command;
using DesafioDev.Application.Helpers;
using DesafioDev.Application.Response;
using DesafioDev.Domain.Entities;
using DesafioDev.Domain.Enums;
using DesafioDev.Domain.Repositories;

namespace DesafioDev.Application.Features.File;

internal sealed class UploadFileCommandHandler : ICommandHandler<UploadFileCommand, BaseResponse<string>>
{
    readonly IUnitOfWork _unitOfWork;

    public UploadFileCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<string>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        ICollection<Establishment> establishments = new List<Establishment>();
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

            Establishment establishment = establishments.FirstOrDefault(_ => _.Name == name);
            if(establishment is not null)
            {
                establishments.Remove(establishment);
            }

            establishment ??= new Establishment(name, cpf, ownerName);

            establishment.AddTransaction((TransactionType)Convert.ToInt16(type), date, Convert.ToDecimal(value), card, hour);
            establishments.Add(establishment);
        });

        await _unitOfWork.EstablishmentRepository.SaveAsync(establishments);

        await _unitOfWork.CommitAsync();

        return new BaseResponse<string>(true, "Upload realizado com sucesso!", null);
    }
}
