using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class HabilidadConfiguration : IEntityTypeConfiguration<Habilidad>
    {
        public void Configure(EntityTypeBuilder<Habilidad> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.nombre).IsRequired().HasMaxLength(255); 
            builder.Property(x => x.ataqueBase).IsRequired(); 
            builder.Property(x => x.nivelRequerido).IsRequired(); 
            builder.Property(x => x.costoMana).IsRequired(); 
            builder.Property(x => x.costoEnergia).IsRequired(); 
            builder.Property(x => x.costoSalud).IsRequired(); 
            builder.Property(x => x.tiempoEnfriamiento).IsRequired(); 

            builder.HasMany(h=> h.personajes).WithMany(per => per.habilidades);


            builder.ToTable("Habilidad");
        }
    }
}