using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Domain.Entities.Concrete.Database
{
    public class Estado
    {
        public Estado(string uF)
        {
            UF = uF;
        }

        public string UF { get; set; }

       [Key]
       [Required]
       public int Id { get; set; } 

    }
}
