
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Repository.Interfaces
{
  public interface IRepositoryUpdate<T> where T : new()
  {

    void Update(T item);

    void Update(IList<T> item);

  }
}
