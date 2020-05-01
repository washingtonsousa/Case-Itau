using Microsoft.Extensions.DependencyInjection;

namespace Core.Shared.Kernel.Abstractions
{
  public interface IModule
  {
    void InjectAll(IServiceCollection services);
  }
}
