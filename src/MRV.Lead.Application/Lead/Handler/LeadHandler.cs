using AutoMapper;
using MediatR;
using MRV.Lead.Application.Core;
using MRV.Lead.Application.Lead.Command;
using MRV.Lead.Domain.Enums;
using MRV.Lead.Domain.Models;
using MRV.Lead.Domain.Validators;
using MRV.Lead.Infra.Gateways.Interfaces;
using MRV.Lead.Infra.Interfaces.Core;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MRV.Lead.Application.Lead.Handler;

public class LeadHandler : IRequestHandler<LeadCreateCommand, Response>, IRequestHandler<LeadAcceptCommand, Response>, IRequestHandler<LeadDeclineCommand, Response>
{
    private readonly IRepositoryBase<LeadModel, LeadModelValidator> _repositoryBase;
    private readonly IRepositoryQuery<LeadModel> _repositoryQuery;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmail _email;

    public LeadHandler(IRepositoryBase<LeadModel, LeadModelValidator> repositoryBase, IUnitOfWork unitOfWork, IMapper mapper, IRepositoryQuery<LeadModel> repositoryQuery, IEmail email)
    {
        _repositoryBase = repositoryBase;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repositoryQuery = repositoryQuery;
        _email = email;
    }

    public async Task<Response> Handle(LeadCreateCommand request, CancellationToken cancellationToken)
    {
        var leadModel = _mapper.Map<LeadModel>(request);
        leadModel.Status = Status.Default;

        var result = await _repositoryBase.AddAsync(leadModel, cancellationToken);

        if (!result.IsValid)
            return Response.AddError(result.Errors);

        await _unitOfWork.CommitAsync();
        return Response.None();
    }

    public async Task<Response> Handle(LeadAcceptCommand request, CancellationToken cancellationToken)
    {
        var leadModel = (await _repositoryQuery.FindAsync(x => x.Id == request.Id && x.Status == Status.Default, cancellationToken)).FirstOrDefault();
        if (leadModel == default)
            return Response.AddError(default);

        leadModel.Status = Status.Accept;
        if (leadModel.Price >= 500)
            leadModel.Price -= leadModel.Price / 10;

        var result = _repositoryBase.UpdateAsync(leadModel, cancellationToken);
        if (!result.IsValid)
            return Response.AddError(result.Errors);

        await _unitOfWork.CommitAsync();
        await _email.Enviar();
        return Response.None();
    }

    public async Task<Response> Handle(LeadDeclineCommand request, CancellationToken cancellationToken)
    {
        var leadModel = (await _repositoryQuery.FindAsync(x => x.Id == request.Id && x.Status == Status.Default, cancellationToken)).FirstOrDefault();
        if (leadModel == default)
            return Response.AddError(default);

        leadModel.Status = Status.Decline;

        var result = _repositoryBase.UpdateAsync(leadModel, cancellationToken);
        if (!result.IsValid)
            return Response.AddError(result.Errors);

        await _unitOfWork.CommitAsync();
        return Response.None();
    }
}