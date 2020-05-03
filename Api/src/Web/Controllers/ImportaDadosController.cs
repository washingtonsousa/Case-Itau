using System.Threading.Tasks;
using Application.Interfaces;
using Core.BaseWeb.Controllers.Abstractions;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Itau.Case.Brasileirao.Web.Web.Controllers
{
    [Route("v1/api")]
    public class ImportaDadosController : BaseController
    {

        private IImportDataAppService _importDataAppService;

        public ImportaDadosController(IDomainNotificationContext<DomainNotification> domainNotification, IImportDataAppService importDataAppService) : base(domainNotification)
        {
            _importDataAppService = importDataAppService;
        }


        [HttpPost]
        [Route("importacao")]
        public async Task<IActionResult> ExecuteImport()
        {

            await  _importDataAppService.ExecutarImportacaoDeDados();
            return ResponseWithAllNotifications("Processo de importação realizado com sucesso");

        }
    }
}