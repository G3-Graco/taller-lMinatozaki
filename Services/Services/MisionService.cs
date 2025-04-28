using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Core.Responses;
using Services.Validators;

namespace Services.Services
{
    public class MisionService : IMisionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MisionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Mision> Create(Mision newMision)
        {
            MisionValidators validator = new MisionValidators();
            var validationResult = await validator.ValidateAsync(newMision);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage);
            }

            // configurar objetivos

            await _unitOfWork.MisionRepository.AddAsync(newMision);
            await _unitOfWork.CommitAsync();

            return newMision;
        }

        public async Task Delete(int misionId)
        {
            var mision = await _unitOfWork.MisionRepository.GetByIdAsync(misionId);
            if (mision == null)
            {
                throw new Exception("La misión no existe");
            }

            _unitOfWork.MisionRepository.Remove(mision);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Mision>> GetAll()
        {
            return await _unitOfWork.MisionRepository.GetAllAsync();
        }

        public async Task<Mision> GetById(int id)
        {
            var mision = await _unitOfWork.MisionRepository.GetByIdAsync(id);
            if (mision == null)
            {
                throw new Exception("La misión no existe");
            }

            return mision;
        }

        public async Task<Mision> Update(int misionId, Mision updatedMision)
        {
            var mision = await _unitOfWork.MisionRepository.GetByIdAsync(misionId);
            if (mision == null)
            {
                throw new Exception("La misión no existe");
            }

            mision.nombre = updatedMision.nombre;
            mision.objetivos = updatedMision.objetivos;
            mision.recompensas = updatedMision.recompensas;

            await _unitOfWork.CommitAsync();
            return mision;
        }

        public async Task<Mision> AceptarMision(int misionId)
        {
            var mision = await _unitOfWork.MisionRepository.GetByIdAsync(misionId);
            if (mision == null)
            {
                throw new Exception("La misión no existe");
            }

            //if (mision.estado != 'P') // P: pendiente, C: en curso y F: finalizada
            //{
            //    throw new Exception("La misión ya está en curso o completada");
            //}

            //mision.estado = 'C';
            await _unitOfWork.CommitAsync();

            return mision;
        }

        public async Task<Mision> IndicarProgresoMision(int misionId, string nuevoObjetivo)
        {
            var mision = await _unitOfWork.MisionRepository.GetByIdAsync(misionId);
            if (mision == null)
            {
                throw new Exception("La misión no existe");
            }

            //if (mision.estado != 'C')
            //{
            //    throw new Exception("La misión no está en curso");
            //}

            //if (!mision.objetivos.Contains(nuevoObjetivo))
            //{
            //    mision.objetivos.Add(nuevoObjetivo);
            //}

            await _unitOfWork.CommitAsync();
            return mision;
        }

        public async Task<Mision> CompletarMision(int misionId)
        {
            var mision = await _unitOfWork.MisionRepository.GetByIdAsync(misionId);
            if (mision == null)
            {
                throw new Exception("La misión no existe");
            }

            //if (mision.estado != 'C')
            //{
            //    throw new Exception("La misión no está en curso");
            //}

            //mision.estado = 'F';
            await _unitOfWork.CommitAsync();

            return mision;
        }
    }
}