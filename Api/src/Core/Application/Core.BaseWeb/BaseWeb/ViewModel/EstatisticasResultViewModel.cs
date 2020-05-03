using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BaseWeb.ViewModel
{
    public class EstatisticasResultadosViewModel
    {
        public EstatisticasResultadosViewModel(int posicao, string nome, int totalPontuacao, int totalCampeonatos,
            int totalJogos, int totalVitorias, int totalEmpates, int totalDerrotas, 
            int totalGolsPros, int totalGolsContras)
        {
            Posicao = posicao;
            Nome = nome;
            Pontos = totalPontuacao;
            CampeonatosDisputados = totalCampeonatos;
            Jogos = totalJogos;
            Vitorias = totalVitorias;
            Empates = totalEmpates;
            Derrotas = totalDerrotas;
            GolsPro = totalGolsPros;
            GolsContra = totalGolsContras;
        }

        public int Posicao { get; private set; }
        public string Nome { get; private set; }
        public int Pontos {get; private set; }
        public int CampeonatosDisputados { get; private set; }
        public int Jogos { get; private set; }
        public int Vitorias { get; private set; }
        public int  Empates { get; private set; }
        public int  Derrotas { get; private set; }
        public int GolsPro { get; private set; }
        public int GolsContra { get; private set; }

        public int SaldoGols { get { 
            
            return GolsPro - GolsContra; ;

            } }

        public EstatisticasResultadosViewModel SetPosicaoAndReturnItSelf(int posicao)
        {
            Posicao = posicao;
            return this;
        }
    }
}
