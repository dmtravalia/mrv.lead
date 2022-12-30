using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MRV.Lead.Domain.Models;

namespace MRV.Lead.Infra.Core.Maps;

public abstract class EntityTypeMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    protected EntityTypeBuilder<TEntity> Builder { get; private set; }

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        Builder = builder;
        CreateTable();
        CreateColumns();
        SetPrimaryKey();
        SetForeignKeys();
        SetQueryFilter();
        SetIndexes();
    }
    protected abstract void CreateTable();

    protected virtual void SetPrimaryKey() { }

    protected virtual void CreateColumns() { }

    protected virtual void SetForeignKeys() { }

    protected virtual void SetQueryFilter() { }

    protected virtual void SetIndexes() { }
}