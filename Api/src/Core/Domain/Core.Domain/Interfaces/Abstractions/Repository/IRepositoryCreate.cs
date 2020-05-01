using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Repository.Interfaces
{
  public interface IRepositoryCreate<T> where T : new()
  {

    Task Add(T item);

    Task Add(IList<T> item);

  }
}
