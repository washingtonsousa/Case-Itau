using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared.Kernel.Interfaces
{
    public interface IHandler<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}
