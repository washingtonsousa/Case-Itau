using System.Threading.Tasks;
using Application.Interfaces;
using Core.BaseWeb.Controllers.Abstractions;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Itau.Case.Brasileirao.Web.Web.Controllers
{
    [Route("v1/api/estatisticas")]
    [ApiController]
    public class EstatisticasController : BaseController
    {
        public EstatisticasController(IDomainNotificationContext<DomainNotification> domainNotification, IEstatisticasAppService timeAppService) : base(domainNotification)
        {
            _estatisticasAppService = timeAppService;
        }

        public IEstatisticasAppService _estatisticasAppService { get; }

        [Route("time")]
        public async Task<IActionResult> ObterEstatisticasPorTime()
        {
            var times = await _estatisticasAppService.ObterEstatisticasPorTime();
            return ResponseWithAllNotifications("Sucesso!", times);
        }

        [Route("time/{nome}")]
        public async Task<IActionResult> ObterEstatisticasPorTime(string nome)
        {
            var times = await _estatisticasAppService.ObterEstatisticasPorTime(nome);
            return ResponseWithAllNotifications("Sucesso!", times);
        }


        [Route("estado")]
        public async Task<IActionResult> ObterEstatisticasPorEstado()
        {
            var times = await _estatisticasAppService.ObterEstatisticasPorEstado();
            return ResponseWithAllNotifications("Sucesso!", times);
        }

    }
}