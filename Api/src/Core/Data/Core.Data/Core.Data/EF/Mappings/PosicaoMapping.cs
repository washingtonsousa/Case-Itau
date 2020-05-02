using Core.Domain.Entities.Concrete.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data.EF.Mappings
{
    public class PosicaoMapping : IEntityTypeConfiguration<Posicao>
    {
        public void Configure(EntityTypeBuilder<Posicao> builder)
        {

            builder.ToTable("tb_posicao");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("id_posicao").IsRequired();
            builder.Property(t => t.Pontos).HasColumnName("vl_pontos").IsRequired();
            builder.Property(t => t.Jogos).HasColumnName("vl_jogos").IsRequired();
            builder.Property(t => t.Vitorias).HasColumnName("vl_vitorias").IsRequired();
            builder.Property(t => t.Empates).HasColumnName("vl_empates").IsRequired();
            builder.Property(t => t.Derrotas).HasColumnName("vl_derrotas").IsRequired();
            builder.Property(t => t.GolsPro).HasColumnName("vl_golspro").IsRequired();
            builder.Property(t => t.GolsContra).HasColumnName("vl_golscontra").IsRequired();
            builder.Property(t => t.PosicaoValue).HasColumnName("vl_posicao").IsRequired();
            builder.Property(t => t.IdTime).HasColumnName("id_time").IsRequired();
            builder.Property(t => t.IdCampeonato).HasColumnName("id_campeonato").IsRequired();
            builder.HasOne(e => e.Campeonato).WithMany(e => e.Posicoes).HasForeignKey(e => e.IdCampeonato);
            builder.HasOne(e => e.Time).WithMany(e => e.Posicoes).HasForeignKey(e => e.IdTime);


        }
    }
}
