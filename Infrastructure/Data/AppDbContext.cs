using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Personaje> Characters { get; set; }
        public DbSet<Mision> Misions { get; set; }
        public DbSet<Objeto> Objetos { get; set; }
        public DbSet<Enemigo> enemies { get; set; }
        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<Habilidad> Habilidads { get; set; }
        public DbSet<Ubicacion> Ubicacions { get; set; }
        public DbSet<TipoPersonaje> TipoPersonajes { get; set; }
        public DbSet<TipoEstadistica> TipoEstadisticas { get; set; }
        public DbSet<TipoObjeto> TipoObjetos { get; set; }
        public DbSet<Estadistica> Estadisticas { get; set; }
        public DbSet<Ranura> Ranuras { get; set; }
        public DbSet<Objetivo> Objetivo { get; set; }
        public DbSet<PersonajeMision> PersonajeMisiones { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonajeConfiguration());
            modelBuilder.ApplyConfiguration(new MisionConfiguration());
            modelBuilder.ApplyConfiguration(new ObjetoConfiguration());
            modelBuilder.ApplyConfiguration(new EnemigoConfiguration());
            modelBuilder.ApplyConfiguration(new EquipoConfiguration());
            modelBuilder.ApplyConfiguration(new UbicacionConfiguration());
            modelBuilder.ApplyConfiguration(new TipoPersonajeConfiguration());
            modelBuilder.ApplyConfiguration(new TipoEstadisticaConfiguration());
            modelBuilder.ApplyConfiguration(new TipoObjetoConfiguration());
            modelBuilder.ApplyConfiguration(new EstadisticaConfiguration());
            modelBuilder.ApplyConfiguration(new RanuraConfiguration());
            modelBuilder.ApplyConfiguration(new PersonajeMisionConfiguration());
            modelBuilder.ApplyConfiguration(new ObjetivoConfiguration());
        }


    }
}
