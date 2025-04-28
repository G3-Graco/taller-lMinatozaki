using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Services.Validators;

namespace Services.Services
{
    public class EnemigoService : IEnemigoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EnemigoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

         public async Task<Enemigo> Create(Enemigo newEnemigo)
        {
            EnemigoValidators  validator = new();

            var validationResult = await validator.ValidateAsync(newEnemigo);
            if (validationResult.IsValid)
            {
                //newEnemigo.tipo = await _unitOfWork.TipoEnemigoRepository.GetByIdAsync(newEnemigo.tipoId);

                await _unitOfWork.EnemigoRepository.AddAsync(newEnemigo);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage.ToString());
            }

            return newEnemigo;
        }

        public async Task Delete(int EnemigoId)
        {
            Enemigo Enemigo = await _unitOfWork.EnemigoRepository.GetByIdAsync(EnemigoId);
            _unitOfWork.EnemigoRepository.Remove(Enemigo);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Enemigo>> GetAll()
        {
            return await _unitOfWork.EnemigoRepository.GetAllAsync();
        }

        public async Task<Enemigo> GetById(int id)
        {
            return await _unitOfWork.EnemigoRepository.GetByIdAsync(id);
        }

        public async Task<Enemigo> Update(int EnemigoToBeUpdatedId, Enemigo newEnemigoValues)
        {
            EnemigoValidators EnemigoValidator = new();
            
            var validationResult = await EnemigoValidator.ValidateAsync(newEnemigoValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Enemigo EnemigoToBeUpdated = await _unitOfWork.EnemigoRepository.GetByIdAsync(EnemigoToBeUpdatedId);

            if (EnemigoToBeUpdated == null)
                throw new ArgumentException("Invalid Enemigo ID while updating");

            
            EnemigoToBeUpdated.nombre = newEnemigoValues.nombre;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.EnemigoRepository.GetByIdAsync(EnemigoToBeUpdatedId);
        }

    }
}