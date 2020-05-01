using AutoMapper;
using Core.Domain.Interfaces;
using Core.Domain.Repository.Interfaces;
using Core.Shared.Kernel.Abstractions;
using System;

namespace Core.Application.Abstractions
{
  public abstract class ApplicationService : Notifiable
  {

    protected IUnityOfWork _unityOfWork;

    public ApplicationService(IUnityOfWork unityOfWork)
    {
      _unityOfWork = unityOfWork;
    }


  }
}
