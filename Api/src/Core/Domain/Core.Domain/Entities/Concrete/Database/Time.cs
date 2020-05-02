using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Domain.Entities.Concrete.Database
{
    public class Time
    {

        public Time(string nome, int idEstado)
        {
            Nome = nome;
            IdEstado = idEstado;
        }

        public Time(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        [Key]
        [Required]
        public int Id { get; set; }
        public Estado Estado { get; private set; }
        public int IdEstado { get; private set; }
        public IList<Posicao> Posicoes { get; private set; }

        public void AddPosicoes(IList<Posicao> posicoes)
        {
            Posicoes = posicoes;
        }

    }
}
