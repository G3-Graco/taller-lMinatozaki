using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EquipoConfiguration: IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.cascoId).IsRequired(); 
            builder.Property(x => x.armaduraId).IsRequired(); 
            builder.Property(x => x.arma1Id).IsRequired(); 
            builder.Property(x => x.arma2Id).IsRequired(); 
            builder.Property(x => x.guanteletesId).IsRequired(); 
            builder.Property(x => x.grebasId).IsRequired();
            builder.HasOne(p => p.casco).WithMany().HasForeignKey(p => p.cascoId);
            builder.HasOne(p => p.armadura).WithMany().HasForeignKey(p => p.armaduraId);
            builder.HasOne(p => p.arma1).WithMany().HasForeignKey(p => p.arma1Id);
            builder.HasOne(p => p.arma2).WithMany().HasForeignKey(p => p.arma2Id);
            builder.HasOne(p => p.guanteletes).WithMany().HasForeignKey(p => p.guanteletesId);
            builder.HasOne(p => p.grebas).WithMany().HasForeignKey(p => p.grebasId);

            builder.ToTable("Equipo");
        }
    }
}