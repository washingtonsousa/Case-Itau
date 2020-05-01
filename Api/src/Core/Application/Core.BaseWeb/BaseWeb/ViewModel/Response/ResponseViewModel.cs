using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BaseWeb.ViewModel.Response
{
  public class ResponseViewModel
  {

    public string Key { get; set; }
    public string Value { get; set; }
    public object _result { get; set; }

    public ResponseViewModel DefaultMessage(string Message = "", object result = null)
    {

      Key = "Message";
      Value = Message;
      _result = result;

      return this;
    }

  }
}
