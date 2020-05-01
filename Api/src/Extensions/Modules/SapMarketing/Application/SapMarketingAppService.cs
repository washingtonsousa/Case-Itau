using Core.Domain.ActionHooks;
using Core.Domain.EF.Entities;
using Core.Domain.Interfaces.ActionHooks;

namespace SapMarketing.Application
{
  public class SapMarketingAppService : IClienteAoCadastrar, IClienteAoLogar
  {
    public void hookAoCadastrarExecute(Cliente model)
    {
      ///TODO
    }

    public void hookClienteAoLogar(Cliente cliente)
    {
     ///TODO
    }
  }
}
