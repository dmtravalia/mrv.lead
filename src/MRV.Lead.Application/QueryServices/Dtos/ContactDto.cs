using MRV.Lead.Domain.Models;

namespace MRV.Lead.Application.QueryServices.Dtos;

public class ContactDto : BaseControleEntity
{
    public string FullName { get; set; }
    public decimal PhoneNumber { get; set; }
    public string Email { get; set; }
}