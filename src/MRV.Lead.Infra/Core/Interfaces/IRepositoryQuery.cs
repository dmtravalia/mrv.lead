using MRV.Lead.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MRV.Lead.Infra.Interfaces.Core;

public interface IRepositoryQuery<TEntity>
        where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
    Task<TEntity> FirstOrDefaultAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> ToListAsync(CancellationToken cancellationToken);
}