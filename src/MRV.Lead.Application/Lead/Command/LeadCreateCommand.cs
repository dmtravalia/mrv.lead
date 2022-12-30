using MediatR;
using MRV.Lead.Application.Core;
using System;

namespace MRV.Lead.Application.Lead.Command;

public class LeadCreateCommand : IRequest<Response>
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Suburb { get; set; }
    public string Category { get; set; }
    public Guid ContactID { get; set; }
}