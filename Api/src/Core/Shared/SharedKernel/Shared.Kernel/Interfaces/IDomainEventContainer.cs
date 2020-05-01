using Core.Shared.Kernel.Events;
using System;

namespace Core.Shared.Kernel.Interfaces
{
  public interface IDomainEventContainer
  {
    void Raise<T>(T args) where T : IDomainEvent;

    void Notify<T>(T args) where T : IDomainEvent;


  }
}
