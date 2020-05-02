using Core.BaseWeb.ViewModel.Response;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.BaseWeb.Controllers.Abstractions
{
  public abstract class BaseController : Controller
  {

    private IDomainNotificationContext<DomainNotification> _domainNotification;


    public BaseController(IDomainNotificationContext<DomainNotification> domainNotification)
    {
      _domainNotification = domainNotification;
    }


    protected IActionResult ResponseWithFirstNotification()
    {

      if(_domainNotification.HasNotifications())
      {
        return BadRequest(_domainNotification.GetFirstNotification());
      }

      return Ok();

    }


    protected IActionResult ResponseWithFirstNotification<T>(T args, string Message = "")  where T : new()
    {

      var response = new ResponseViewModel();

      if (_domainNotification.HasNotifications())
      {
        response.DefaultMessage(_domainNotification.GetFirstNotification());

        return BadRequest(response); 
      }

      
      response.DefaultMessage(Message, args);

      return Ok(response);

    }


    protected IActionResult ResponseWithAllNotifications()
    {

      if (_domainNotification.HasNotifications())
      {
        return BadRequest(_domainNotification.Notify());
      }

      return Ok();

    }

  }
}
