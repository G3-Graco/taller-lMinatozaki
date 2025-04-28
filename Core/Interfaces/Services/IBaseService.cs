using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IBaseService<Entidad> where Entidad : class
    {
        
        Task<Entidad> GetById(int id);
        Task<IEnumerable<Entidad>> GetAll();
        Task<Entidad> Create(Entidad newEntidad);
        Task<Entidad> Update(int entidadToBeUpdatedId, Entidad newEntidadValues);
        Task Delete(int entidadId);
    }
}