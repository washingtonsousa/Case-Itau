using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities.Concrete.Database
{
    public class Campeonato
    {
        public Campeonato(int ano)
        {
            Ano = ano;
            Posicoes = new List<Posicao>();
        }

        [Key]
        [Required]
        public int Id { get; private set; }
        public int Ano { get; private set; }
        public IList<Posicao> Posicoes { get; private set; }

        public void AddPosicoes(IList<Posicao> posicoes)
        {
            Posicoes = posicoes;
        }

        public void AddPosicao(Posicao posicao)
        {
            Posicoes.Add(posicao);
        }
    }
}
