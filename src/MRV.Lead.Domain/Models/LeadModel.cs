using MRV.Lead.Domain.Enums;
using System;

namespace MRV.Lead.Domain.Models;

public class LeadModel : BaseControleEntity
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Suburb { get; set; }
    public string Category { get; set; }
    public Status Status { get; set; }
    public Guid ContactID { get; set; }
    public ContactModel Contact { get; set; }
}