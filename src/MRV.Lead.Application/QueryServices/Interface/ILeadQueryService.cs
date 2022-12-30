using MRV.Lead.Application.QueryServices.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MRV.Lead.Application.QueryServices.Interface;

public interface ILeadQueryService
{
    Task<IEnumerable<LeadDto>> ListLeadAsync(CancellationToken cancellationToken);
    Task<IEnumerable<LeadDto>> ListLeadAcceptAsync(CancellationToken cancellationToken);
    Task<IEnumerable<LeadDto>> ListLeadDeclineAsync(CancellationToken cancellationToken);
}