using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EnemigoConfiguration : IEntityTypeConfiguration<Enemigo>
    {
       public void Configure(EntityTypeBuilder<Enemigo> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.nombre).IsRequired().HasMaxLength(255); 
            builder.Property(x => x.salud).IsRequired();
            builder.Property(x => x.energia).IsRequired();
            builder.Property(x => x.fuerza).IsRequired();
            builder.Property(x => x.defensa).IsRequired();
            builder.Property(x => x.inteligencia).IsRequired();
            builder.Property(x => x.agilidad).IsRequired();
            //builder.Property(x => x.habilidades).IsRequired(); 
            //builder.Property(x => x.recompensas).IsRequired();
            builder.Property(x => x.nivelAmenaza).IsRequired(); 
            builder.ToTable("Enemigo");
        }
    }
}