
using Core.Domain.Enums;
using Core.Domain.Helpers;
using Core.Shared.Data;
using Core.Shared.Kernel.Abstractions;
using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;

namespace Core.Domain.Entities.Concrete.Files
{
    public class Classificacao
    {

        public Classificacao(int posicao, int ano, string time, 
            string estado, int pontos, int jogos, int vitorias, int empates, int derrotas, int golsPro, int golsContra)
        {
            Ano = ano;
            Time = time;
            Estado = estado;
            Pontos = pontos;
            Jogos = jogos;
            Vitorias = vitorias;
            Empates = empates;
            Derrotas = derrotas;
            GolsPro = golsPro;
            GolsContra = golsContra;
            Posicao = posicao;
        }


        public int Ano { get; set; }
        public string Time  { get; set; }
        public string Estado { get; set; }
        public int Posicao { get; set; }
        public int Pontos { get; set; }
        public int Jogos { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsPro { get; set; }
        public int GolsContra { get; set; }
    }
}
