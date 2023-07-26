using DesafioDev.Application.Features.Establishment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDev.Api.Controllers;

[Route("api/establishment")]
[ApiController]
public class EstablishmentController : ControllerBase
{
    readonly ISender _sender;

    public EstablishmentController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _sender.Send(new EstablishmentQuery());
            return result.Any() ? Ok(result) : NotFound();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return StatusCode(500);
        }
    }
}
