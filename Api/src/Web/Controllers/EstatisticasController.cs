using System.Threading.Tasks;
using Application.Interfaces;
using Core.BaseWeb.Controllers.Abstractions;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Itau.Case.Brasileirao.Web.Web.Controllers
{
    [Route("v1/api/estatisticas")]
    [ApiController]
    public class EstatisticasController : BaseController<EstatisticasController>
    {
        public EstatisticasController(IDomainNotificationContext<DomainNotification> domainNotification, 
            IEstatisticasAppService timeAppService,
            ILogger<EstatisticasController> logger) : base(domainNotification, logger)
        {
            _estatisticasAppService = timeAppService;
        }

        public IEstatisticasAppService _estatisticasAppService { get; }

        [Route("time")]
        public async Task<IActionResult> ObterEstatisticasPorTime()
        {
            _logger.LogInformation(1, "Obtendo Estatísticas Por Time");

            var times = await _estatisticasAppService.ObterEstatisticasPorTime();
            return ResponseWithAllNotifications("Sucesso!", times);
        }

        [Route("time/{nome}")]
        public async Task<IActionResult> ObterEstatisticasPorTime(string nome)
        {

            _logger.LogInformation(2, $"Obtendo Estatísticas Por Time parametrizando pelo nome {nome}");

            var times = await _estatisticasAppService.ObterEstatisticasPorTime(nome);
            return ResponseWithAllNotifications("Sucesso!", times);
        }


        [Route("estado")]
        public async Task<IActionResult> ObterEstatisticasPorEstado()
        {

            _logger.LogInformation(4, $"Obtendo Estatísticas por Estado");

            var estados = await _estatisticasAppService.ObterEstatisticasPorEstado();
            return ResponseWithAllNotifications("Sucesso!", estados);
        }


        [Route("resultado-geral")]
        public async Task<IActionResult> ObterResultadoGeral()
        {
            _logger.LogInformation(6, $"Obtendo Resultado Geral");

            var times = await _estatisticasAppService.ObterResultadoGeral();
            return ResponseWithAllNotifications("Sucesso!", times);
        }

    }
}