namespace MRV.Lead.Domain.Models;

public class ContactModel : BaseControleEntity
{
    public string FullName { get; set; }
    public decimal PhoneNumber { get; set; }
    public string Email { get; set; }
}