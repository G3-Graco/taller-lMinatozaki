using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IPersonajeRepository : IBaseRepository<Personaje>
    {
        // Task<IEnumerable<Character>> GetAllAbilitysAsync();
        // Task<IEnumerable<Character>> GetAllEquipoAsync();
         ValueTask<Personaje> GetByIdUbicacionAsync(int id);
        
    }
}