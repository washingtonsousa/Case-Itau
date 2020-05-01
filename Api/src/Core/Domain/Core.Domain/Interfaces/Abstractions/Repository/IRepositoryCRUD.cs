
namespace Core.Domain.Repository.Interfaces
{
  public interface IRepositoryCRUD<T>: IRepositoryCreate<T>, IRepositoryUpdate<T>, IRepositoryRead<T>, IRepositoryDelete<T> where T : new()
  {
  }
}
