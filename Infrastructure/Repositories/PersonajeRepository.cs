using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PersonajeRepository : BaseRepository<Personaje>, IPersonajeRepository
    {
        public PersonajeRepository(AppDbContext context) : base(context){}

        public override async Task<IEnumerable<Personaje>> GetAllAsync()
        {
            return await base.dbSet.Include(x => x.agilidad).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.defensa).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.energia).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.fuerza).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.inteligencia).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.tipo)
                                    .Include(x => x.salud).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.ubicacion)
                                    .Include(x => x.equipo).Include(x => x.PersonajeMisiones).ToListAsync();
        }

        public override async ValueTask<Personaje> GetByIdAsync(int id)
        {
            return await base.dbSet.Include(x => x.agilidad).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.defensa).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.energia).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.fuerza).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.inteligencia).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.tipo)
                                    .Include(x => x.ubicacion)
                                    .Include(x => x.salud).ThenInclude(es => es.tipoEstadistica)
                                    .Include(x => x.equipo).ThenInclude(e => e.arma1).ThenInclude(objeto => objeto.objeto)
                                    .Include(x => x.equipo).ThenInclude(e => e.arma2).ThenInclude(objeto => objeto.objeto)
                                    .Include(x => x.equipo).ThenInclude(e => e.casco).ThenInclude(objeto => objeto.objeto)
                                    .Include(x => x.equipo).ThenInclude(e => e.armadura).ThenInclude(objeto => objeto.objeto)
                                    .Include(x => x.equipo).ThenInclude(e => e.guanteletes).ThenInclude(objeto => objeto.objeto)
                                    .Include(x => x.equipo).ThenInclude(e => e.grebas).ThenInclude(objeto => objeto.objeto)

                                    .Include(x => x.PersonajeMisiones).FirstAsync(x => x.id == id);
        }


        public async ValueTask<Personaje> GetByIdUbicacionAsync(int id)
        {
            return await base.dbSet.FirstAsync(personaje => personaje.ubicacionId == id);
        }

    }
}