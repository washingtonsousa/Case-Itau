using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Domain.Entities.Concrete.Database
{
    public class Brasileirao
    {
        public Brasileirao(int ano)
        {
            Ano = ano;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        public int Ano { get; set; }

    }
}
