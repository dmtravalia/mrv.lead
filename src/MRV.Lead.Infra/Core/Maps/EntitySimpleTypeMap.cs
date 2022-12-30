using MRV.Lead.Domain.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace MRV.Lead.Infra.Core.Maps;

public abstract class EntitySimpleTypeMap<TEntity> : EntityTypeMap<TEntity> where TEntity : BaseControleEntity
{
    protected override void CreateColumns()
    {
        Builder.HasKey(x => x.Id);

        Builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

        Builder.Property(x => x.DataInclusao)
            .HasColumnName("dt_inclusao")
            .HasConversion<DateTime>()
            .IsRequired();

        Builder.Property(x => x.DataAlteracao)
            .HasColumnName("dt_alteracao")
            .HasConversion<DateTime?>();
    }
}