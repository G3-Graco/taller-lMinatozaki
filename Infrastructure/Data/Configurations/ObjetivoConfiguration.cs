using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class ObjetivoConfiguration : IEntityTypeConfiguration<Objetivo>
    {
        public void Configure(EntityTypeBuilder<Objetivo> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.descripcion).IsRequired().HasMaxLength(255);
            builder.Property(x => x.misionId).IsRequired();
            builder.Property(x => x.valorObjetivo).IsRequired();
            builder.Property(x => x.valorActual).IsRequired();
            builder.Property(x => x.completado);

            builder.ToTable("Objetivo");
        }
    }

}
