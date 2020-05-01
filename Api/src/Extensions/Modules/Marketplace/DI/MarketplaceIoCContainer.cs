using Core.Shared.Kernel.Interfaces;
using Marketplace.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.DI
{
  public class MarketplaceIoCContainer 
  {
    public void InjectAll(IServiceCollection services)
    {
      services.AddTransient<MarketplaceVitrineAppService, MarketplaceVitrineAppService>();
    }
  }
}
