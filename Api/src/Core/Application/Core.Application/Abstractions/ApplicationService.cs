using AutoMapper;
using Core.Domain.Interfaces;
using Core.Domain.Repository.Interfaces;
using Core.Shared.Kernel.Abstractions;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using System;

namespace Application.Abstractions
{
    public abstract class ApplicationService 
    {

        protected IUnityOfWork _unityOfWork { get; }

        protected IAssertionConcern _assertionConcern { get; }

        public ApplicationService(IUnityOfWork unityOfWork, IAssertionConcern assertionConcern)
        {
            _unityOfWork = unityOfWork;
            _assertionConcern = assertionConcern;
        }


    }
}
