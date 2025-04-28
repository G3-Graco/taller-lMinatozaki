using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using Core.Entities;
using Core.Interfaces.Services;
using Core.Responses;

namespace Core.Services
{
    public interface IPersonajeService : IBaseService<Personaje>
    {
        Task<Personaje> Create(PersonajeDTO newPersonajeData);

        Task<Personaje> LevelUp(int personajeToBeUpdatedId);
        Task<AtaqueResponse> Atacar(int idEnemigo, int idPersonaje);
        Task<Personaje> AprenderHabilidad(int personajeToBeUpdatedId, int idHabilidad);

        
    }
}