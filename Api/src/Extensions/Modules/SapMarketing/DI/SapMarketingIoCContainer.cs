using SapMarketing.Application;
using Microsoft.Extensions.DependencyInjection;
using Core.Domain.ActionHooks;
using Core.Domain.Interfaces.ActionHooks;

namespace Modules.SapMarketing.DI
{
  public static class SapMarketingIoCContainer 
  {
    public static void Inject(IServiceCollection services)
    {
      services.AddTransient<IClienteAoLogar, SapMarketingAppService>();
      services.AddTransient<IClienteAoCadastrar, SapMarketingAppService>();
    }
  }
}
