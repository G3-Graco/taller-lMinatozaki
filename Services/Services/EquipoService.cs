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
    public class EquipoService : IEquipoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EquipoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Equipo> Create(Equipo newEquipo)
        {
            EquipoValidators validator = new EquipoValidators();
            var validationResult = await validator.ValidateAsync(newEquipo);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage);
            }

            await _unitOfWork.EquipoRepository.AddAsync(newEquipo);
            await _unitOfWork.CommitAsync();

            return newEquipo;
        }

        public async Task Delete(int equipoId)
        {
            var equipo = await _unitOfWork.EquipoRepository.GetByIdAsync(equipoId);
            if (equipo == null)
            {
                throw new Exception("El equipo no existe");
            }

            _unitOfWork.EquipoRepository.Remove(equipo);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Equipo>> GetAll()
        {
            return await _unitOfWork.EquipoRepository.GetAllAsync();
        }

        public async Task<Equipo> GetById(int id)
        {
            var equipo = await _unitOfWork.EquipoRepository.GetByIdAsync(id);
            if (equipo == null)
            {
                throw new Exception("El equipo no existe");
            }

            return equipo;
        }

        public async Task<Equipo> Update(int equipoId, Equipo updatedEquipo)
        {
            var equipo = await _unitOfWork.EquipoRepository.GetByIdAsync(equipoId);
            if (equipo == null)
            {
                throw new Exception("El equipo no existe");
            }

            EquipoValidators validator = new EquipoValidators();
            var validationResult = await validator.ValidateAsync(updatedEquipo);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage);
            }

            equipo.casco = updatedEquipo.casco;
            equipo.armadura = updatedEquipo.armadura;
            equipo.arma1 = updatedEquipo.arma1;
            equipo.arma2 = updatedEquipo.arma2;
            equipo.guanteletes = updatedEquipo.guanteletes;
            equipo.grebas = updatedEquipo.grebas;

            await _unitOfWork.CommitAsync();

            return equipo;
        }

        public async Task<Equipo> Equipar(int equipoId, int objetoId)
        {
            var equipo = await _unitOfWork.EquipoRepository.GetByIdAsync(equipoId);
            var objeto = await _unitOfWork.ObjetoRepository.GetByIdAsync(objetoId);
            if (equipo == null)
            {
                throw new Exception("El equipo no existe");
            }
            if (objeto == null)
            {
                throw new Exception("El objeto no existe");
            }

            switch (objeto.tipoObjetoId)
            {
                case 1:
                    equipo.casco = await _unitOfWork.RanuraRepository.GetByIdAsync(equipo.cascoId);
                    equipo.casco.objetoId = objeto.id;
                    break;
                case 2:
                    equipo.armadura = await _unitOfWork.RanuraRepository.GetByIdAsync(equipo.cascoId);
                    equipo.armadura.objetoId = objeto.id;
                    break;
                case 3:
                    equipo.arma1 = await _unitOfWork.RanuraRepository.GetByIdAsync(equipo.cascoId);
                    equipo.arma1.objetoId = objeto.id;
                    break;
                case 4:
                    equipo.guanteletes = await _unitOfWork.RanuraRepository.GetByIdAsync(equipo.cascoId);
                    equipo.guanteletes.objetoId = objeto.id;
                    break;
                case 5:
                    equipo.grebas = await _unitOfWork.RanuraRepository.GetByIdAsync(equipo.cascoId);
                    equipo.grebas.objetoId = objeto.id;
                    break;
                default:
                    throw new ArgumentException("Tipo de objeto invalido. Los tipos validos son: casco, armadura, arma1, arma2, guanteletes, grebas");
            }

            await _unitOfWork.CommitAsync();
            return equipo;
        }

        public async Task<Equipo> Desequipar(int equipoId, int ranuraId)
        {
            var equipo = await _unitOfWork.EquipoRepository.GetByIdAsync(equipoId);
            var ranura = await _unitOfWork.RanuraRepository.GetByIdAsync(ranuraId);
            if (equipo == null)
            {
                throw new Exception("El equipo no existe");
            }
            if (ranura == null)
            {
                throw new Exception("El objeto no existe");
            }

            ranura.objetoId = 0;

            await _unitOfWork.CommitAsync();
            return equipo;
        }
    }
}