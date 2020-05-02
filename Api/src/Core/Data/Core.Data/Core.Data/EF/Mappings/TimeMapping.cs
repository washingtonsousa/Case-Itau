using Core.Domain.Entities.Concrete.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data.EF.Mappings
{
    class TimeMapping : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {

            builder.ToTable("tb_time");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_time").IsRequired();
            builder.Property(t => t.Nome).HasColumnName("ds_nome").IsRequired();
            builder.Property(t => t.IdEstado).HasColumnName("id_estado").IsRequired();
            builder.HasOne(e => e.Estado).WithMany(e => e.Times).HasForeignKey(e => e.IdEstado);

        }
    }
}
