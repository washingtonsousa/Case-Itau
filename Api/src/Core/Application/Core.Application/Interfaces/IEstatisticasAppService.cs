using Core.BaseWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEstatisticasAppService
    {
        Task<IList<EstatisticasResultadosViewModel>> ObterEstatisticasPorTime(string nome);
        Task<IList<EstatisticasResultadosViewModel>> ObterEstatisticasPorTime();
        Task<IList<EstatisticasResultadosViewModel>> ObterEstatisticasPorEstado();
        Task<EstatisticasResultadosGeraisViewModel> ObterResultadoGeral();
    }
}
