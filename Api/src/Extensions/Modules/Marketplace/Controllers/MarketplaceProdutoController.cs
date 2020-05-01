using Core.BaseWeb.Controllers.Abstractions;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using Marketplace.Application;
using Microsoft.AspNetCore.Mvc;

namespace Marletplace.Controllers
{
  public class MarketplaceProdutoController : BaseController
  {

    private MarketplaceVitrineAppService _marketplaceVitrineAppService;
    public MarketplaceProdutoController(IDomainNotificationHandler<DomainNotification> domainNotification, MarketplaceVitrineAppService marketplaceVitrineAppService) : base(domainNotification)
    {
      _marketplaceVitrineAppService = marketplaceVitrineAppService;
    }

    [HttpGet]
    public IActionResult GetProdutos()
    {
      _marketplaceVitrineAppService.GetVitrines();
      return Ok();
    }


  }
}
