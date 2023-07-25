using DesafioDev.Application.Abstractions.Command;

namespace DesafioDev.Application.Features.File
{
    internal sealed class UploadFileCommandHandler : ICommandHandler<UploadFileCommand, string>
    {
        public async Task<string> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            return "OK";
        }
    }
}
