using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Domain.Entities.Concrete.Database
{
    public class Posicao
    {
        /// <summary>
        /// Instancia um novo objeto do tipo posicao obedecendo as especificações de parametros obrigatórias, porém já adicionando novos objetos de time e campeonato para o Entity Framework
        /// </summary>
        /// <param name="time"></param>
        /// <param name="brasileirao"></param>
        /// <param name="pontos"></param>
        /// <param name="jogos"></param>
        /// <param name="vitorias"></param>
        /// <param name="empates"></param>
        /// <param name="derrotas"></param>
        /// <param name="golsPro"></param>
        /// <param name="golsContra"></param>
        /// <param name="posicaoValue"></param>
        public Posicao(Time time, 
            Campeonato brasileirao, 
            int pontos, 
            int jogos, 
            int vitorias, 
            int empates, 
            int derrotas, 
            int golsPro, 
            int golsContra, 
            int posicaoValue)
        {
            Time = time;
            Campeonato = brasileirao;
            Pontos = pontos;
            Jogos = jogos;
            Vitorias = vitorias;
            Empates = empates;
            Derrotas = derrotas;
            GolsPro = golsPro;
            GolsContra = golsContra;
            PosicaoValue = posicaoValue;
        }

        /// <summary>
        /// Instancia um novo objeto do tipo posicao obedecendo as especificações de parametros obrigatórias
        /// </summary>
        /// <param name="time"></param>
        /// <param name="brasileirao"></param>
        /// <param name="pontos"></param>
        /// <param name="jogos"></param>
        /// <param name="vitorias"></param>
        /// <param name="empates"></param>
        /// <param name="derrotas"></param>
        /// <param name="golsPro"></param>
        /// <param name="golsContra"></param>
        /// <param name="posicaoValue"></param>
        public Posicao(int idTime, int idCampeonato, int pontos, int jogos, int vitorias, int empates, int derrotas, int golsPro, int golsContra, int posicaoValue)
        {
            Pontos = pontos;
            Jogos = jogos;
            Vitorias = vitorias;
            Empates = empates;
            Derrotas = derrotas;
            GolsPro = golsPro;
            GolsContra = golsContra;
            PosicaoValue = posicaoValue;
            IdTime = idTime;
            IdCampeonato = idCampeonato;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        public Time Time { get; set; }
        public Campeonato Campeonato { get; set;}
        public int Pontos { get; set; }
        public int Jogos { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsPro { get; set; }
        public int GolsContra { get; set; }
        public int PosicaoValue { get; set; }
        public int IdTime { get; set; }
        public int IdCampeonato { get; set; }
    }
}
