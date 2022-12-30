using AutoMapper;
using MediatR;
using MRV.Lead.Application.Contact.Command;
using MRV.Lead.Application.Core;
using MRV.Lead.Domain.Models;
using MRV.Lead.Domain.Validators;
using MRV.Lead.Infra.Interfaces.Core;
using System.Threading;
using System.Threading.Tasks;

namespace MRV.Lead.Application.Contact.Handler;

public class ContactHandler : IRequestHandler<ContactCreateCommand, Response>, IRequestHandler<ContactUpdateCommand, Response>
{
    private readonly IRepositoryBase<ContactModel, ContactModelValidator> _repositoryBase;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContactHandler(IRepositoryBase<ContactModel, ContactModelValidator> repositoryBase, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repositoryBase = repositoryBase;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(ContactCreateCommand request, CancellationToken cancellationToken)
    {
        var contactModel = _mapper.Map<ContactModel>(request);

        var result = await _repositoryBase.AddAsync(contactModel, cancellationToken);

        if (!result.IsValid)
            return Response.AddError(result.Errors);

        await _unitOfWork.CommitAsync();
        return Response.None();
    }

    public async Task<Response> Handle(ContactUpdateCommand request, CancellationToken cancellationToken)
    {
        var contactModel = _mapper.Map<ContactModel>(request);

        var result = _repositoryBase.UpdateAsync(contactModel, cancellationToken);

        if (!result.IsValid)
            return Response.AddError(result.Errors);

        await _unitOfWork.CommitAsync();
        return Response.None();
    }
}