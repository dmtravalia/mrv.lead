using System.Threading.Tasks;

namespace MRV.Lead.Infra.Interfaces.Core;

public interface IUnitOfWork
{
    Task CommitAsync();
}