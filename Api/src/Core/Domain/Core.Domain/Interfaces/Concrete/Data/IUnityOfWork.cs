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
        /// <param name="mandatory">Parametro indica se processo é mandatório, se marcado como verdadeito adiciona uma notificação ao contexto de domínio</param>
        /// <returns></returns>
        bool Migrate(bool mandatory = true);


        /// <summary>
        /// Executa uma migration atualizando o banco de dados de forma assíncrona
        /// </summary>
        /// <param name="mandatory">Parametro indica se processo é mandatório, se marcado como verdadeito adiciona uma notificação ao contexto de domínio</param>
        /// <returns></returns>
        Task<bool> MigrateAsync(bool mandatory = true);


    }
}
