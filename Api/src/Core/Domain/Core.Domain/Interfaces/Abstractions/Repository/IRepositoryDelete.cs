using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Repository.Interfaces
{
  public interface IRepositoryDelete<T> where T : new()
  {

    void Remove(T item);

    void Remove(IList<T> item);

  }
}
