using MediatR;
using Microsoft.AspNetCore.Mvc;
using MRV.Lead.Api.Core;
using MRV.Lead.Application.Contact.Command;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace MRV.Lead.Api.V1.Controllers;

[ApiController]
[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ContactController : MainController
{
    private readonly IMediator _mediator;

    public ContactController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Adicionar um Contato",
                      Description = "Adiciona um novo cadastro de Contato.")]
    public async Task<IActionResult> PostAsync([FromBody] ContactCreateCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return CustomResponse(response);
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Alterar Contato",
                      Description = "Altera o cadastro de um Contato.")]
    public async Task<IActionResult> UpdateAsync([FromBody] ContactUpdateCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return CustomResponse(response);
    }
}