using MediatR;
using MRV.Lead.Application.Core;

namespace MRV.Lead.Application.Contact.Command;

public class ContactCreateCommand : IRequest<Response>
{
    public string FullName { get; set; }
    public decimal PhoneNumber { get; set; }
    public string Email { get; set; }
}