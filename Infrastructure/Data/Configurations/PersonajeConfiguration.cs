using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class PersonajeConfiguration : IEntityTypeConfiguration<Personaje>
    {
        public void Configure(EntityTypeBuilder<Personaje> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.nombre).IsRequired().HasMaxLength(255);
            builder.Property(x => x.saludId).IsRequired();
            builder.Property(x => x.energiaId).IsRequired();
            builder.Property(x => x.fuerzaId).IsRequired();
            builder.Property(x => x.inteligenciaId).IsRequired();
            builder.Property(x => x.agilidadId).IsRequired();
            builder.Property(x => x.nivel).IsRequired();
            //builder.Property(x => x.idTipoPersonaje).IsRequired();
            //builder.Property(x => x.equipo).IsRequired();
            builder.Property(x => x.experiencia).IsRequired();
            builder.HasMany(p => p.habilidades).WithMany(habilidad => habilidad.personajes);
            builder.HasOne(p => p.tipo).WithMany().HasForeignKey(p => p.tipoId);
            builder.HasOne(p => p.ubicacion).WithMany().HasForeignKey(p => p.ubicacionId);
            builder.HasOne(p => p.equipo).WithMany().HasForeignKey(p => p.equipoId);
            builder.ToTable("Personaje");
        }
    }
}