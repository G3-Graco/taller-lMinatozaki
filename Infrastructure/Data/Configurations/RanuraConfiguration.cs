using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class RanuraConfiguration : IEntityTypeConfiguration<Ranura>
    {
        public void Configure(EntityTypeBuilder<Ranura> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.tipoObjetoId).IsRequired();
            builder.Property(x => x.objetoId);
            builder.HasOne(one => one.tipoObjeto).WithMany().HasForeignKey(k => k.tipoObjetoId);
            builder.HasOne(one => one.objeto).WithMany().HasForeignKey(k => k.objetoId);
            builder.ToTable("Ranura");
        }
    }
}
