using AutoMapper;
using MRV.Lead.Application.QueryServices.Dtos;
using MRV.Lead.Application.QueryServices.Interface;
using MRV.Lead.Domain.Models;
using MRV.Lead.Infra.Interfaces.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MRV.Lead.Application.QueryServices;

public class LeadQueryService : ILeadQueryService
{
    private readonly IRepositoryQuery<LeadModel> _repositoryQuery;
    private readonly IMapper _mapper;

    public LeadQueryService(IRepositoryQuery<LeadModel> repositoryQuery, IMapper mapper)
    {
        _repositoryQuery = repositoryQuery;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LeadDto>> ListLeadAsync(CancellationToken cancellationToken) =>
        _mapper.Map<IEnumerable<LeadDto>>(await _repositoryQuery.FindAsync(x => x.Status == Domain.Enums.Status.Default, cancellationToken));

    public async Task<IEnumerable<LeadDto>> ListLeadAcceptAsync(CancellationToken cancellationToken) =>
        _mapper.Map<IEnumerable<LeadDto>>(await _repositoryQuery.FindAsync(x => x.Status == Domain.Enums.Status.Accept, cancellationToken));

    public async Task<IEnumerable<LeadDto>> ListLeadDeclineAsync(CancellationToken cancellationToken) =>
        _mapper.Map<IEnumerable<LeadDto>>(await _repositoryQuery.FindAsync(x => x.Status == Domain.Enums.Status.Decline, cancellationToken));
}