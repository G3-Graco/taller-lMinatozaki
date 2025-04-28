using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MisionConfiguration : IEntityTypeConfiguration<Mision>
    {
       public void Configure(EntityTypeBuilder<Mision> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.nombre).IsRequired().HasMaxLength(255); 
            //builder.Property(x => x.objetivos).IsRequired(); 
            builder.Property(x => x.recompensas).IsRequired(); 
            builder.ToTable("Mision");
        }
        
    }
}