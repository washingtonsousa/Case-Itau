using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Domain.Entities.Concrete.Database
{
    public class Posicao
    {
        public Posicao(Time time, Brasileirao brasileirao)
        {
            Time = time;
            Brasileirao = brasileirao;
        }

        [Key]
        [Required]
        public int Id { get; set; }

        public Time Time { get; set; }
        public Brasileirao Brasileirao { get; set;}

    }
}
