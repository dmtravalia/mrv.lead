using MediatR;
using MRV.Lead.Application.Core;
using System;

namespace MRV.Lead.Application.Contact.Command;

public class ContactUpdateCommand : IRequest<Response>
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public decimal PhoneNumber { get; set; }
    public string Email { get; set; }
}