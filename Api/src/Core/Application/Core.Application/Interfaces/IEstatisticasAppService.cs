using Core.BaseWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEstatisticasAppService
    {
        Task<IList<EstatisticasResultViewModel>> ObterEstatisticasPorTime(string nome);
        Task<IList<EstatisticasResultViewModel>> ObterEstatisticasPorTime();
        Task<IList<EstatisticasResultViewModel>> ObterEstatisticasPorEstado();
    }
}
