using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Domain.Entities.Concrete.Database
{
    public class Time
    {
        public Time(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        [Key]
        [Required]
        public int Id { get; set; }
    }
}
