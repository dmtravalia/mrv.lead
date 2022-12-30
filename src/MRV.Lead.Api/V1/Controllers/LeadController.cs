using MediatR;
using Microsoft.AspNetCore.Mvc;
using MRV.Lead.Api.Core;
using MRV.Lead.Application.Lead.Command;
using MRV.Lead.Application.QueryServices.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace MRV.Lead.Api.V1.Controllers;

[ApiController]
[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
public class LeadController : MainController
{
    private readonly IMediator _mediator;
    private readonly ILeadQueryService _ileadQueryService;

    public LeadController(IMediator mediator, ILeadQueryService ileadQueryService)
    {
        _mediator = mediator;
        _ileadQueryService = ileadQueryService;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Adicionar um Lead",
                      Description = "Adiciona um novo cadastro de Lead.")]
    public async Task<IActionResult> CreateAsync([FromBody] LeadCreateCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return CustomResponse(response);
    }

    [HttpPost("accept")]
    public async Task<IActionResult> AcceptAsync([FromBody] LeadAcceptCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return CustomResponse(response);
    }

    [HttpPost("decline")]
    public async Task<IActionResult> DeclineAsync([FromBody] LeadDeclineCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return CustomResponse(response);
    }

    [HttpGet("list")]
    public async Task<ActionResult> ListLeadAsync(CancellationToken cancellationToken)
    {
        var result = await _ileadQueryService.ListLeadAsync(cancellationToken);

        return Ok(result);
    }

    [HttpGet("list-accept")]
    public async Task<ActionResult> ListLeadAcceptAsync(CancellationToken cancellationToken)
    {
        var result = await _ileadQueryService.ListLeadAcceptAsync(cancellationToken);

        return Ok(result);
    }

    [HttpGet("list-decline")]
    public async Task<ActionResult> ListLeadDeclineAsync(CancellationToken cancellationToken)
    {
        var result = await _ileadQueryService.ListLeadDeclineAsync(cancellationToken);

        return Ok(result);
    }
}