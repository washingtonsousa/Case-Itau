using Core.Domain.Repository.Interfaces;
using Core.Data.EF.Context;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Helpers;
using Microsoft.Extensions.Logging;

namespace Core.Data.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private DatabaseContext _context;
        public IDomainNotificationContext<DomainNotification> _domainNotificationContext { get; private set; }
        public ILogger<UnityOfWork> _logger { get; }

        public UnityOfWork(ILogger<UnityOfWork> logger, DatabaseContext context, IDomainNotificationContext<DomainNotification> domainNotificationContext)
        {
            _context = context;
            _domainNotificationContext = domainNotificationContext;
            _logger = logger;
        }

        public bool Commit(bool mandatory = true)
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (mandatory)
                    _domainNotificationContext.AddNotification(ex.AsNotification());

                _logger.LogWarning(0, ex, "Ocorreu erro de operação de Dados");
            }
            return false;
        }

        public async Task<bool> CommitAsync(bool mandatory = true)
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (mandatory)
                    _domainNotificationContext.AddNotification(ex.AsNotification());

                _logger.LogWarning(0, ex, "Ocorreu erro de operação de Dados");
            }
            return false;
        }

        /// <summary>
        /// Executa uma migration atualizando no banco de dados
        /// </summary>
        /// <param name="mandatory">Parametro indica se processo é mandatório, se marcado como verdadeito adiciona uma notificação ao contexto de domínio</param>
        /// <returns></returns>
        public bool Migrate(bool mandatory = true)
        {

            try
            {
                _context.Database.Migrate();
                return true;
            }
            catch (Exception ex)
            {
                if (mandatory)
                    _domainNotificationContext.AddNotification(ex.AsNotification());

                _logger.LogWarning(0, ex, "Ocorreu erro de migração de Base de Dados");
            }
            return false;
        }

        public async Task<bool> MigrateAsync(bool mandatory = true)
        {

            try
            {
                await _context.Database.MigrateAsync();
                return true;
            }
            catch (Exception ex)
            {
                if(mandatory)
                _domainNotificationContext.AddNotification(ex.AsNotification());

                _logger.LogWarning(0, ex, "Ocorreu erro de migração de Base de Dados");
            }

            return false;
        }
    }
}
