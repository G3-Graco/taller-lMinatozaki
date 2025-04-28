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
    public class EstadisticaConfiguration : IEntityTypeConfiguration<Estadistica>
    {
        public void Configure(EntityTypeBuilder<Estadistica> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.tipoEstadisticaId).IsRequired();
            builder.HasOne(p => p.tipoEstadistica).WithMany().HasForeignKey(p => p.tipoEstadisticaId);
            builder.ToTable("Estadistica");
        }
    }
}
