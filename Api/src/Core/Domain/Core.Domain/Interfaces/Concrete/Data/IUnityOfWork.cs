using System.Threading.Tasks;

namespace Core.Domain.Repository.Interfaces
{
  public interface IUnityOfWork
  {

    void Commit();
    Task CommitAsync();

  }
}
