using Core.Domain.Entities.Concrete.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data.EF.Mappings
{
    class CampeonatoMapping : IEntityTypeConfiguration<Campeonato>
    {
        public void Configure(EntityTypeBuilder<Campeonato> builder)
        {
            builder.ToTable("tb_campeonato");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_brasileirao").IsRequired();
            builder.Property(t => t.Ano).HasColumnName("vl_ano");
            builder.HasIndex(t => t.Ano).IsUnique();
            builder.HasMany(e => e.Posicoes).WithOne(e => e.Campeonato).HasForeignKey(e => e.IdCampeonato);

        }
    }
}
