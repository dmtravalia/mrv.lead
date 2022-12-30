using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MRV.Lead.Application.Core;

namespace MRV.Lead.Api.Core;

[ApiController]
public abstract class MainController : Controller
{
    protected ICollection<string> _erros = new List<string>();

    protected ActionResult CustomResponse(Response result = default)
    {

        if (result == default)
            return NotFound();

        if (result.IsValid)
            return Ok(result);

        return BadRequest(new ValidationProblemDetails(
            new Dictionary<string, string[]>
            {
                    { "Mensagens", result.Error.Select(x => x.ErrorMessage).ToArray() }
            }));
    }
}