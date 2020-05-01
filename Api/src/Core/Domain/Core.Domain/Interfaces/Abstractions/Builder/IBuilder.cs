using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces
{
  public interface IBuilder<T> where T : new()
  {
    T Build();
  }
}
