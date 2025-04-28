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
    public class TipoObjetoConfiguration : IEntityTypeConfiguration<TipoObjeto>
    {
        public void Configure(EntityTypeBuilder<TipoObjeto> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.nombre).IsRequired().HasMaxLength(255);
            builder.ToTable("TipoObjeto");
        }
    }
}
