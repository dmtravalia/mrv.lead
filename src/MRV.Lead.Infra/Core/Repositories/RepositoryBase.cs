using FluentValidation;
using MRV.Lead.Domain.Models;
using MRV.Lead.Infra.Context;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MRV.Lead.Infra.Interfaces.Core;

namespace MRV.Lead.Infra.Repositories.Core;

public class RepositoryBase<TEntity, TEntityValidador> : IRepositoryBase<TEntity, TEntityValidador>
        where TEntity : BaseControleEntity
        where TEntityValidador : AbstractValidator<TEntity>
{
    private readonly AppDbContext _context;
    private readonly TEntityValidador _entityValidador;

    public RepositoryBase(AppDbContext context)
    {
        _context = context;
        _entityValidador = Activator.CreateInstance<TEntityValidador>();
    }

    public async Task<ValidationResult> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var validationResult = _entityValidador.Validate(entity);
        if (!validationResult.IsValid)
            return validationResult;

        cancellationToken.ThrowIfCancellationRequested();
        entity.DataInclusao = DateTime.Now;
        entity.DataAlteracao = null;
        await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
        return validationResult;
    }

    public async Task<TEntity> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var objRemove = await _context.Set<TEntity>().AsQueryable().Where(x => x.Id == id).FirstOrDefaultAsync();
        if (objRemove == default)
            return default;
        return _context.Set<TEntity>().Remove(objRemove).Entity;
    }

    public ValidationResult UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var validationResult = _entityValidador.Validate(entity);
        if (!validationResult.IsValid)
            return validationResult;

        cancellationToken.ThrowIfCancellationRequested();
        _context.Set<TEntity>().Attach(entity);
        _context.Set<TEntity>().Update(entity).State = EntityState.Modified;

        var entry = _context.Entry(entity);
        entry.Property(nameof(entry.Entity.DataInclusao)).IsModified = false;
        entity.DataAlteracao = DateTime.Now;

        return validationResult;
    }
}