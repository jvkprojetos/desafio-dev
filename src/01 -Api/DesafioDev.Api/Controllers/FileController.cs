using AutoMapper;
using DesafioDev.Application.Features.File;
using DesafioDev.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDev.Api.Controllers;

[Route("api/file")]
[ApiController]
public class FileController : ControllerBase
{
    readonly IMapper _mapper;
    readonly ISender _sender;

    public FileController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload([FromForm] UploadFileRequest uploadFileRequest)
    {
        var result = await _sender.Send(_mapper.Map<UploadFileCommand>(uploadFileRequest));
        return Ok(result);
    }
 }
