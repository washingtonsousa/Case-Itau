using Core.BaseWeb.ViewModel.Response;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Core.BaseWeb.Controllers.Abstractions
{
    public abstract class BaseController<T> : Controller
    {

        private IDomainNotificationContext<DomainNotification> _domainNotification;

        public ILogger<T> _logger { get; }

        public BaseController(IDomainNotificationContext<DomainNotification> domainNotification, ILogger<T> logger)
        {
            _domainNotification = domainNotification;
            _logger = logger;
        }

        protected IActionResult ResponseWithFirstNotification<T>(T args, string Message = "") where T : new()
        {

            var response = new ResponseViewModel();

            if (_domainNotification.HasNotifications())
            {
                response.DefaultMessage(_domainNotification.GetFirstNotification());

                _logger.LogInformation(400, $"Uma consulta gerou a notificação {_domainNotification.GetFirstNotification()}");

                return BadRequest(response);
            }


            response.DefaultMessage(Message, args);

            _logger.LogInformation(200, $"Uma consulta gerou retoro bem sucedido com resposta serializada suja mensagem retorno gerada é > {Message}");

            return Ok(response);

        }


        protected IActionResult ResponseWithAllNotifications(string Message, object result = null)
        {

            var response = new ResponseViewModel();
            response._result = result;
            response.DefaultMessage(Message, result);

            if (_domainNotification.HasNotifications())
            {
                _logger.LogInformation(400, $"Uma consulta gerou as notificações {JsonConvert.SerializeObject(_domainNotification.Notify())}");
                return BadRequest(_domainNotification.Notify());
            }

            _logger.LogInformation(200, $"Uma consulta gerou retorno bem sucedido com resposta serializada suja mensagem retorno gerada é  {Message}");


            return Ok(response);

        }
    }
}
