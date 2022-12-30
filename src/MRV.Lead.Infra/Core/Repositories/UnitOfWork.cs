using MRV.Lead.Infra.Context;
using MRV.Lead.Infra.Interfaces.Core;
using System.Threading.Tasks;

namespace MRV.Lead.Infra.Repositories.Core;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}