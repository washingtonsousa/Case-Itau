using System.Threading.Tasks;
using Application.Interfaces;
using Core.BaseWeb.Controllers.Abstractions;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Itau.Case.Brasileirao.Web.Web.Controllers
{
    [Route("v1/api")]
    public class ImportaDadosController : BaseController<ImportaDadosController>
    {

        private IImportDataAppService _importDataAppService;

        public ImportaDadosController(IDomainNotificationContext<DomainNotification> domainNotification, IImportDataAppService importDataAppService, ILogger<ImportaDadosController> logger) : base(domainNotification, logger)
        {
            _importDataAppService = importDataAppService;
        }


        [HttpPost]
        [Route("importacao")]
        public async Task<IActionResult> ExecuteImport()
        {
            _logger.LogInformation(2, $"Executando processo de importação de dados");
            await  _importDataAppService.ExecutarImportacaoDeDados();
            return ResponseWithAllNotifications("Processo de importação realizado com sucesso");

        }
    }
}