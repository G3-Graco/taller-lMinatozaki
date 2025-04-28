using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Core.Responses;
using Services.Validators;

namespace Services.Services
{
    public class UbicacionService : IUbicacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UbicacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Ubicacion> Create(Ubicacion newUbicacion)
        {
            UbicacionValidators validator = new UbicacionValidators();
            var validationResult = await validator.ValidateAsync(newUbicacion);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage);
            }

            await _unitOfWork.UbicacionRepository.AddAsync(newUbicacion);
            await _unitOfWork.CommitAsync();

            return newUbicacion;
        }

        public async Task Delete(int ubicacionId)
        {
            var ubicacion = await _unitOfWork.UbicacionRepository.GetByIdAsync(ubicacionId);
            if (ubicacion == null)
            {
                throw new Exception("La ubicación no existe");
            }

            var personaje = await _unitOfWork.PersonajeRepository.GetByIdUbicacionAsync(ubicacionId);

            if (personaje != null)
                throw new Exception("Ubicacion no puede ser eliminada, hay persoanjes en ella ");

            _unitOfWork.UbicacionRepository.Remove(ubicacion);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Ubicacion>> GetAll()
        {
            return await _unitOfWork.UbicacionRepository.GetAllAsync();
        }

        public async Task<Ubicacion> GetById(int id)
        {
            var ubicacion = await _unitOfWork.UbicacionRepository.GetByIdAsync(id);
            if (ubicacion == null)
            {
                throw new Exception("La ubicación no existe");
            }

            return ubicacion;
        }

        public async Task<Ubicacion> Update(int ubicacionId, Ubicacion updatedUbicacion)
        {
            var ubicacion = await _unitOfWork.UbicacionRepository.GetByIdAsync(ubicacionId);
            if (ubicacion == null)
            {
                throw new Exception("La ubicación no existe");
            }

            ubicacion.nombre = updatedUbicacion.nombre;
            ubicacion.descripcion = updatedUbicacion.descripcion;
            ubicacion.clima = updatedUbicacion.clima;

            await _unitOfWork.CommitAsync();
            return ubicacion;
        }

        public async Task<string> Moverse(int personajeId, int nuevaUbicacionId)
        {
            var ubicacion = await _unitOfWork.UbicacionRepository.GetByIdAsync(nuevaUbicacionId);
            if (ubicacion == null)
            {
                throw new Exception("La ubicación no existe :/");
            }

            

            var personaje = await _unitOfWork.PersonajeRepository.GetByIdAsync(personajeId);
            if (personaje == null)
            {
                throw new Exception("El personaje no existe");
            }

            if (ubicacion.id == personaje.ubicacionId)
                throw new Exception("El personaje ya se encuentra en esta ubicación");


            var enemigos = await _unitOfWork.EnemigoRepository.GetAllAsync();
            var enemigosFiltrados = enemigos.Where(e => e.nivelAmenaza >= personaje.nivel).ToList();

            if (enemigosFiltrados.Count == 0)
            {
                throw new Exception("No hay enemigos disponibles con el nivel de amenaza adecuado !!");
            }

            Random random = new Random();
            var enemigoEncontrado = enemigosFiltrados[random.Next(enemigosFiltrados.Count)];

            return $"El personaje '{personaje.nombre}' se ha movido a la ubicación '{ubicacion.nombre}' con un clima '{ubicacion.clima}'. Se encontró con el enemigo '{enemigoEncontrado.nombre}' de nivel de amenaza {enemigoEncontrado.nivelAmenaza}!";
        }
    }
}