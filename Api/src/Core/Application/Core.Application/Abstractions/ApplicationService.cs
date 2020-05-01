using AutoMapper;
using Core.Domain.Interfaces;
using Core.Domain.Repository.Interfaces;
using Core.Shared.Kernel.Abstractions;
using System;

namespace Core.Application.Abstractions
{
  public abstract class ApplicationService : Notifiable
  {

    protected IMapper _mapper;
    protected IUnityOfWork _unityOfWork;

    public ApplicationService(IMapper mapper, IUnityOfWork unityOfWork)
    {
      _mapper = mapper;
      _unityOfWork = unityOfWork;
    }

    public ApplicationService()
    {
    }

  }
}
