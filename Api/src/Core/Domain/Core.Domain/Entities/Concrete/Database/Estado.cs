using System.Collections.Generic;

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

       public void AddTimes(IList<Time> times)
       {
            Times = times;
       }

    }
}
