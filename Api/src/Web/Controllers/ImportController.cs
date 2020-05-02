using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Interfaces;
using Core.BaseWeb.Controllers.Abstractions;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Itau.Case.Brasileirao.Web.Web.Controllers
{

    public class ImportController : BaseController
    {

        private IImportDataAppService _importDataAppService;

        public ImportController(IDomainNotificationContext<DomainNotification> domainNotification, IImportDataAppService importDataAppService) : base(domainNotification)
        {
            _importDataAppService = importDataAppService;
        }


        [HttpPost]
        //[Route("api/data/import")]
        public IActionResult ExecuteImport()
        {

            _importDataAppService.ExecuteDataImport().GetAwaiter().GetResult();
            return ResponseWithAllNotifications();

        }
    }
}