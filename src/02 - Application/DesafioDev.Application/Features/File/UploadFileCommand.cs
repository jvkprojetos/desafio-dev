using DesafioDev.Application.Abstractions.Command;
using Microsoft.AspNetCore.Http;

namespace DesafioDev.Application.Features.File;

public sealed record UploadFileCommand(IFormFile File) : ICommand<object>;
