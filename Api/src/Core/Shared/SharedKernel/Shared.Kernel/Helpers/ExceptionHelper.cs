using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared.Kernel.Helpers
{
    public static class ExceptionHelper
    {
        public static DomainNotification AsNotification(this Exception ex)
        {
            return new DomainNotification("AssertException",
                     ex.InnerException != null ? ex.InnerException.Message : ex.Message);
        }
    }
}
