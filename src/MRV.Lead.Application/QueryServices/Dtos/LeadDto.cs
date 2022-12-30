using MRV.Lead.Domain.Enums;
using MRV.Lead.Domain.Models;
using System;

namespace MRV.Lead.Application.QueryServices.Dtos;

public class LeadDto : BaseControleEntity
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Suburb { get; set; }
    public string Category { get; set; }
    public Status Status { get; set; }
    public Guid ContactID { get; set; }
    public ContactDto Contact { get; set; }
}