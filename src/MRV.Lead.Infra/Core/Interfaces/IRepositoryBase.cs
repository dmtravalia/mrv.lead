using FluentValidation;
using FluentValidation.Results;
using MRV.Lead.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MRV.Lead.Infra.Interfaces.Core;

public interface IRepositoryBase<TEntity, TEntityValidador>
        where TEntity : BaseEntity
        where TEntityValidador : AbstractValidator<TEntity>
{
    Task<ValidationResult> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> RemoveAsync(Guid id, CancellationToken cancellationToken);
    ValidationResult UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}