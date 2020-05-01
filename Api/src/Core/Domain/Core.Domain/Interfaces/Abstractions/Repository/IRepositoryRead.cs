using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Repository.Interfaces
{
  public interface IRepositoryRead<T> where T : new()
  {

    Task<T> Get(int Id);

    Task<IList<T>> Get();

    Task<T> GetFirstRecord();

  }
}
