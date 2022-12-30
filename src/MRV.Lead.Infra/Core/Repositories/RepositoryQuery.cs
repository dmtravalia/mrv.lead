using Microsoft.EntityFrameworkCore;
using MRV.Lead.Domain.Models;
using MRV.Lead.Infra.Context;
using MRV.Lead.Infra.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MRV.Lead.Infra.Repositories.Core;

public class RepositoryQuery<TEntity> : IRepositoryQuery<TEntity>
        where TEntity : BaseEntity
{
    private readonly AppDbContext _context;

    public RepositoryQuery(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> FirstOrDefaultAsync(Guid id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var query = _context.Set<TEntity>().AsNoTracking();
        return await query.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> ToListAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var query = _context.Set<TEntity>().AsNoTracking();
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await _context.Set<TEntity>().AsNoTracking().Where(expression).ToListAsync(cancellationToken);
    }
}