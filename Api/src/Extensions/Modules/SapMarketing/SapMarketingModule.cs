using Modules.SapMarketing.DI;
using Microsoft.Extensions.DependencyInjection;
using Core.Domain.Entities;

namespace SapMarketing
{
  public class SapMarketingModule : ApplicationModule
  {
    public SapMarketingModule() 
    {
    }

    protected override void Install()
    {
      Name = "Sap Marketing Integração";
      Description = "Módulo de Marketing Originalmente designado pela Clamed";
    }

    public override void InjectAll(IServiceCollection services)
    {
      SapMarketingIoCContainer.Inject(services);
    }
  }
}
