using Core.Shared.Kernel.Enum;
using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared.Kernel.Interfaces
{
    public interface IAssertionConcern
    {
        bool IsSatisfiedBy(params DomainNotification[] validations);


        DomainNotification AssertLength(string stringValue, int minimum, int maximum, string message, string key = "AssertArgumentLength");


        DomainNotification AssertListLength<T>(IEnumerable<T> list, int minimum, string message, string key = "AssertArgumentLength", RankNotification rank = RankNotification.Low);

        DomainNotification AssertMatches(string pattern, string stringValue, string message, string key = "AssertArgumentLength");


        DomainNotification AssertNotEmpty(string stringValue, string message, string key = "AssertArgumentNotEmpty");


        DomainNotification AssertNotNull(object object1, string message, string key = "AssertArgumentNotNull", RankNotification rank = RankNotification.Low);


        DomainNotification AssertTrue(bool boolValue, string message, string key = "AssertArgumentTrue", RankNotification rank = RankNotification.Low);


        DomainNotification AssertFalse(bool boolValue, string message, string key = "AssertArgumentTrue", RankNotification rank = RankNotification.Low);


        DomainNotification AssertGenericException(string message, string key = "AssertArgumentGenericException");
 
    }
}
