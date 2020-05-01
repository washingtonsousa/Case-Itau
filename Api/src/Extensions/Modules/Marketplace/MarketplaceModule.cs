using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Marketplace
{
  public class MarketplaceModule : ApplicationModule
  {
    protected override void Install()
    {
      Name = "Módulo de Marketplace";
      Description = "Módulo de Marketplace para a plataforma de ECommerce";
    }
  }
}
