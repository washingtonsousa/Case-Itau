using System.Threading.Tasks;

namespace Core.Domain.Repository.Interfaces
{
    public interface IUnityOfWork
    {

        bool Commit(bool mandatory = true);
        Task<bool> CommitAsync(bool mandatory = true);


        /// <summary>
        /// Executa uma migration atualizando o banco de dados
        /// </summary>
        /// <param name="mandatory">Parametro indica se processo � mandat�rio, se marcado como verdadeito adiciona uma notifica��o ao contexto de dom�nio</param>
        /// <returns></returns>
        bool Migrate(bool mandatory = true);


        /// <summary>
        /// Executa uma migration atualizando o banco de dados de forma ass�ncrona
        /// </summary>
        /// <param name="mandatory">Parametro indica se processo � mandat�rio, se marcado como verdadeito adiciona uma notifica��o ao contexto de dom�nio</param>
        /// <returns></returns>
        Task<bool> MigrateAsync(bool mandatory = true);


    }
}
