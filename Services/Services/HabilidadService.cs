using Core.Entities;
using Core.Interfaces.Services;
using Core.Interfaces;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class HabilidadService : IHabilidadService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HabilidadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Habilidad> Create(Habilidad newHabilidad)
        {
            HabilidadValidators validator = new();

            var validationResult = await validator.ValidateAsync(newHabilidad);
            if (validationResult.IsValid)
            {
                //newHabilidad.tipo = await _unitOfWork.TipoHabilidadRepository.GetByIdAsync(newHabilidad.tipoId);

                await _unitOfWork.HabilidadRepository.AddAsync(newHabilidad);
                await _unitOfWork.CommitAsync();
            }
            else
            {

                throw new ArgumentException(validationResult.Errors[0].ErrorMessage.ToString());
            }

            return newHabilidad;
        }

        public async Task Delete(int HabilidadId)
        {
            Habilidad Habilidad = await _unitOfWork.HabilidadRepository.GetByIdAsync(HabilidadId);
            _unitOfWork.HabilidadRepository.Remove(Habilidad);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Habilidad>> GetAll()
        {
            return await _unitOfWork.HabilidadRepository.GetAllAsync();
        }

        public async Task<Habilidad> GetById(int id)
        {
            return await _unitOfWork.HabilidadRepository.GetByIdAsync(id);
        }

        public async Task<Habilidad> Update(int HabilidadToBeUpdatedId, Habilidad newHabilidadValues)
        {
            HabilidadValidators HabilidadValidator = new();

            var validationResult = await HabilidadValidator.ValidateAsync(newHabilidadValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Habilidad HabilidadToBeUpdated = await _unitOfWork.HabilidadRepository.GetByIdAsync(HabilidadToBeUpdatedId);

            if (HabilidadToBeUpdated == null)
                throw new ArgumentException("Invalid Habilidad ID while updating");


            HabilidadToBeUpdated.nombre = newHabilidadValues.nombre;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.HabilidadRepository.GetByIdAsync(HabilidadToBeUpdatedId);
        }

    }
}
