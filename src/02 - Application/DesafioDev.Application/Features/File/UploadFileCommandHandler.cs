﻿using DesafioDev.Application.Abstractions.Command;
using DesafioDev.Application.Helpers;
using DesafioDev.Application.Interfaces;
using DesafioDev.Application.Response;
using DesafioDev.Domain.Repositories;

namespace DesafioDev.Application.Features.File;

internal sealed class UploadFileCommandHandler : ICommandHandler<UploadFileCommand, BaseResponse<string>>
{
    readonly IFileServices _fileServices;
    readonly IUnitOfWork _unitOfWork;

    public UploadFileCommandHandler(IUnitOfWork unitOfWork, IFileServices fileServices)
    {
        _unitOfWork = unitOfWork;
        _fileServices = fileServices;
    }

    public async Task<BaseResponse<string>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var fileConverted = request.File.ReadAndConvertInListString();

        var establishments = _fileServices.DesserializeValuesForEstablishment(fileConverted);

        if(!establishments.Any())
        {
            return new BaseResponse<string>(false, null, new List<Error>
            {
                new Error("Ocorreu uma falha ao ler o aquivo, verifique o padrão do documento enviado e tente novamente.")
            });
        }

        await _unitOfWork.EstablishmentRepository.SaveAsync(establishments);

        await _unitOfWork.CommitAsync();

        return new BaseResponse<string>(true, "Upload realizado com sucesso!", null);
    }
}
