using AutoMapper;
using Core.Domain.Interfaces;
using Core.Domain.Repository.Interfaces;
using Core.Shared.Kernel.Abstractions;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using System;

namespace Core.Application.Abstractions
{
    public abstract class ApplicationService 
    {

        protected IUnityOfWork _unityOfWork;

        public ApplicationService(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }


    }
}
