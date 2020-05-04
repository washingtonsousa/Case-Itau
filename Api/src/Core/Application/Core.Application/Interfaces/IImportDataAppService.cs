using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IImportaDadosAppService
    {
        Task<bool> ExecutarImportacaoDeDados();
    }
}
