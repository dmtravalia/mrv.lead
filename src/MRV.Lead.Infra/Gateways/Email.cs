using MRV.Lead.Infra.Gateways.Interfaces;
using System.Threading.Tasks;

namespace MRV.Lead.Infra.Gateways;

public class Email : IEmail
{
    public Task Enviar() =>
        Task.FromResult(Task.CompletedTask);
}