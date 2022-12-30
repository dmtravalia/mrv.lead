using System.Threading.Tasks;

namespace MRV.Lead.Infra.Gateways.Interfaces;

public interface IEmail
{
    Task Enviar();
}