﻿
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

        private Classificacao(int posicao, int ano, string time, 
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



        /// <summary>
        /// Cria um objeto de classificacao por meio de um arquivo de texto
        /// </summary>
        /// <param name="ano">Ano do campeonato</param>
        /// <param name="line">Linha com colunas separadas por ';'</param>
        /// <returns></returns>
        public static Classificacao CriarClassificacaoPorLinha(int ano, string line)
        {

                var columnsList = line.Split(Constants.DEFAULT_ETL_COLUMN_SEPARATOR).PrepararColunaTimeParaClassificacao();
                
                return new Classificacao(
                     int.Parse(columnsList[(int)ColumnClassificacaoIndex.POSICAO].Trim()),
                    ano,
                    columnsList[(int)ColumnClassificacaoIndex.TIME].Trim(),
                    columnsList[(int)ColumnClassificacaoIndex.ESTADO].Trim(),
                    int.Parse(columnsList[(int)ColumnClassificacaoIndex.PONTOS].Trim()),
                    int.Parse(columnsList[(int)ColumnClassificacaoIndex.JOGOS].Trim()),
                    int.Parse(columnsList[(int)ColumnClassificacaoIndex.VITORIAS].Trim()),
                    int.Parse(columnsList[(int)ColumnClassificacaoIndex.EMPATES].Trim()),
                    int.Parse(columnsList[(int)ColumnClassificacaoIndex.DERROTAS].Trim()),
                    int.Parse(columnsList[(int)ColumnClassificacaoIndex.GOLSPRO].Trim()),
                    int.Parse(columnsList[(int)ColumnClassificacaoIndex.GOLSCONTRA].Trim())
                    );

        
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
