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
    public class PersonajeMisionConfiguration : IEntityTypeConfiguration<PersonajeMision>
    {
        public void Configure(EntityTypeBuilder<PersonajeMision> builder)
        {
            builder.HasKey(pm => new { pm.PersonajeId, pm.MisionId });
            builder.Property(pm => pm.Estado).HasMaxLength(255);
            builder.Property(pm => pm.Progreso);
            builder.HasOne(pm => pm.Personaje).WithMany(p => p.PersonajeMisiones).HasForeignKey(pm => pm.PersonajeId);
            builder.HasOne(pm => pm.Mision).WithMany(p => p.PersonajeMisiones).HasForeignKey(pm => pm.MisionId);
            builder.ToTable("PersoanjeMision");

        }
    }
}
