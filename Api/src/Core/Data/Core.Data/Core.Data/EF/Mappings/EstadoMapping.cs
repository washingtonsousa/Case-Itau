using Core.Domain.Entities.Concrete.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data.EF.Mappings
{
    class EstadoMapping : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("tb_estado");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_estado").IsRequired();
            builder.Property(t => t.UF).HasColumnName("ds_uf");
            builder.HasIndex(t => t.UF).IsUnique();
            builder.HasMany(e => e.Times).WithOne(e => e.Estado).HasForeignKey(e => e.IdEstado);
        }
    }
}
