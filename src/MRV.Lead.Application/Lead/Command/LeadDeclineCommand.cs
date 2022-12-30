using MediatR;
using MRV.Lead.Application.Core;
using System;

namespace MRV.Lead.Application.Lead.Command;

public class LeadDeclineCommand : IRequest<Response>
{
    public Guid Id { get; set; }
}