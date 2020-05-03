using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Domain.Entities.Concrete.Database
{
    public class Estado
    {
       public Estado(string uF)
       {
            UF = uF;
       }

       public string UF { get; private set; }
       public int Id { get; private set; } 

       public IList<Time> Times { get; private set; } 

       public void SetTimes(IList<Time> times)
       {
            Times = times;
       }


    }
}
