using System;

namespace MRV.Lead.Domain.Models;

public class BaseEntity
{
    public Guid Id { get; set; }
}

public class BaseControleEntity : BaseEntity
{
    public DateTime DataInclusao { get; set; }
    public DateTime? DataAlteracao { get; set; }
}