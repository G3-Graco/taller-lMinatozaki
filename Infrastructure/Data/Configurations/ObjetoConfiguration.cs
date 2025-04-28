using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ObjetoConfiguration: IEntityTypeConfiguration<Objeto>
    {
        public void Configure(EntityTypeBuilder<Objeto> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.nombre).IsRequired().HasMaxLength(255); 
            builder.Property(x => x.descripcion).IsRequired().HasMaxLength(255); 
            builder.Property(x => x.tipoObjetoId).IsRequired(); 
            builder.Property(x => x.estadisticas).IsRequired();
            builder.HasOne(one => one.tipoObjeto).WithMany().HasForeignKey(k => k.tipoObjetoId);
            builder.ToTable("Objeto");
        }
    }
}