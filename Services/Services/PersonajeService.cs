using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Core.Responses;
using Services.Validators;
using Core.DTO;

namespace Services.Services
{
    public class PersonajeService : IPersonajeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonajeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        

        public async Task<Personaje> Create(PersonajeDTO newPersonajeData)
        {
            PersonajeDTOValidators validator = new();

            // Al momento de crear un personaje tenemos que crear los atributos de cada uno de sus tipos.
            // previamente haberlos creado a nivel de base de datos ya que no haremos un servicio especifico para ello.
            // 1 salud, 2 energia 3, fuerza, 4 agilidad, 5 inteligencia, 6 defensa
            
            var validationResult = await validator.ValidateAsync(newPersonajeData);

            Personaje newPersonaje = new Personaje();
            newPersonaje.nombre = newPersonajeData.nombre;


            if (validationResult.IsValid)
            {

                newPersonaje.tipo = await _unitOfWork.TipoPersonajeRepository.GetByIdAsync(newPersonajeData.tipoId ?? 0);
                newPersonaje.tipoId = newPersonajeData.tipoId;
                if(newPersonaje.tipo == null )
                    throw new ArgumentException("El tipo de personaje no existe");

                var lstUbicaciones = (await _unitOfWork.UbicacionRepository.GetAllAsync()).ToList();
                Random random = new Random();
                newPersonaje.ubicacion = lstUbicaciones[random.Next(1,lstUbicaciones.Count)];
                newPersonaje.ubicacionId = newPersonaje.ubicacion.id;

                //Estadistica estadistica = new Estadistica();
                newPersonaje.salud.tipoEstadisticaId = 1;
                newPersonaje.salud.valor = newPersonajeData.salud;
                //await _unitOfWork.EstadisticaRepository.AddAsync(estadistica);
                //newPersonaje.saludId = estadistica.id;
                //estadistica.id = 0; // asingamos a cero para que el entity no confunda y en lugar de crear modifique.
                newPersonaje.energia.tipoEstadisticaId = 2;
                newPersonaje.energia.valor = newPersonajeData.energia;
                //await _unitOfWork.EstadisticaRepository.AddAsync(estadistica);
                //newPersonaje.energiaId = estadistica.id;
                //estadistica.id = 0;
                newPersonaje.fuerza.tipoEstadisticaId = 3;
                newPersonaje.fuerza.valor = newPersonajeData.fuerza;
                //await _unitOfWork.EstadisticaRepository.AddAsync(estadistica);
                //newPersonaje.fuerzaId = estadistica.id;
                //estadistica.id = 0;
                newPersonaje.agilidad.tipoEstadisticaId = 4;
                newPersonaje.agilidad.valor = newPersonajeData.agilidad;
                //await _unitOfWork.EstadisticaRepository.AddAsync(estadistica);
                //newPersonaje.agilidadId = estadistica.id;
                //estadistica.id = 0;
                newPersonaje.inteligencia.tipoEstadisticaId = 5;
                newPersonaje.inteligencia.valor = newPersonajeData.inteligencia;
                //await _unitOfWork.EstadisticaRepository.AddAsync(estadistica);
                //newPersonaje.inteligenciaId = estadistica.id;
                //estadistica.id = 0;
                newPersonaje.defensa.tipoEstadisticaId = 6;
                newPersonaje.defensa.valor = newPersonajeData.defensa;
                //await _unitOfWork.EstadisticaRepository.AddAsync(estadistica);
                //newPersonaje.defensaId = estadistica.id;

                // hacemos lo mismo para equipo 
                Equipo equipo = new Equipo();
                ////Creamos 1ero las ranuras 
                ////RAnura casco (1)
                ////Ranura ranura = new Ranura();
                //equipo.casco.tipoObjetoId = 1; // solo el tipo de obnjeto, no hay que asignar ningun objeto base
                ////await _unitOfWork.RanuraRepository.AddAsync(ranura);
                ////equipo.cascoId = ranura.id;
                ////ranura.id = 0;
                //equipo.armadura.tipoObjetoId = 2;
                //await _unitOfWork.RanuraRepository.AddAsync(ranura);
                //equipo.armaduraId = ranura.id;
                //ranura.id = 0;
                //ranura.tipoObjetoId = 3;
                //await _unitOfWork.RanuraRepository.AddAsync(ranura);
                //equipo.arma1Id = ranura.id;
                //ranura.id = 0;
                //ranura.tipoObjetoId = 3;
                //await _unitOfWork.RanuraRepository.AddAsync(ranura);
                //equipo.arma2Id = ranura.id;
                //ranura.id = 0;
                //ranura.tipoObjetoId = 4;
                //await _unitOfWork.RanuraRepository.AddAsync(ranura);
                //equipo.guanteletesId = ranura.id;
                //ranura.id = 0;
                //ranura.tipoObjetoId = 5;
                //await _unitOfWork.RanuraRepository.AddAsync(ranura);
                //equipo.grebasId = ranura.id;
                //await _unitOfWork.EquipoRepository.AddAsync(equipo);
                //newPersonaje.equipoId = equipo.id;
                //Creamos 1ero las ranuras 
                //RAnura casco (1)
                //Ranura ranura = new Ranura();
                equipo.casco.tipoObjetoId = 1; // solo el tipo de obnjeto, no hay que asignar ningun objeto base
                equipo.armadura.tipoObjetoId = 2;
                equipo.arma1.tipoObjetoId = 3;
                equipo.arma2.tipoObjetoId = 3;
                equipo.guanteletes.tipoObjetoId = 4;
                equipo.grebas.tipoObjetoId = 5;
                newPersonaje.equipo = equipo;

                //listo personaje...

                await _unitOfWork.PersonajeRepository.AddAsync(newPersonaje);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage.ToString());
            }

            return newPersonaje;
        }

        public async Task Delete(int PersonajeId)
        {
            Personaje Personaje = await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeId);
            if(Personaje != null)
            {
                _unitOfWork.PersonajeRepository.Remove(Personaje);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new Exception("El personaje no existe");
            }
        }

        public async Task<IEnumerable<Personaje>> GetAll()
        {
            return await _unitOfWork.PersonajeRepository.GetAllAsync();
        }

        public async Task<Personaje> GetById(int id)
        {
            return await _unitOfWork.PersonajeRepository.GetByIdAsync(id);
        }

        //private Personaje ValidarPersonaje(int id)
        //{
        //    Personaje PersonajeToBeUpdated = await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeToBeUpdatedId);

        //    if (PersonajeToBeUpdated == null)
        //        throw new ArgumentException("Invalid Personaje ID while updating");
        //    else
        //        return PersonajeToBeUpdated;
        //}

        public async Task<Personaje> Update(int PersonajeToBeUpdatedId, Personaje newPersonajeValues)
        {
            PersonajeActualizarValidators PersonajeValidator = new();
            
            var validationResult = await PersonajeValidator.ValidateAsync(newPersonajeValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Personaje PersonajeToBeUpdated = await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeToBeUpdatedId);

            if (PersonajeToBeUpdated == null)
                throw new ArgumentException("Invalid Personaje ID while updating");

            //PersonajeToBeUpdated.tipoId = newPersonajeValues.tipoId;
            PersonajeToBeUpdated.nombre = newPersonajeValues.nombre;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeToBeUpdatedId);
        }

        public async Task<Personaje> LevelUp(int PersonajeToBeUpdatedId)
        {
            PersonajeValidators PersonajeValidator = new();
            Personaje PersonajeToBeUpdated = await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeToBeUpdatedId);
            if (PersonajeToBeUpdated == null)
                throw new ArgumentException("Invalid Personaje ID while updating");

            PersonajeToBeUpdated.experiencia = 0;
            PersonajeToBeUpdated.nivel += 1;
            PersonajeToBeUpdated.salud = await _unitOfWork.EstadisticaRepository.GetByIdAsync(PersonajeToBeUpdated.saludId);
            PersonajeToBeUpdated.salud.valor += PersonajeToBeUpdated.nivel * (new Random().Next(1, 5) + 50);
            PersonajeToBeUpdated.energia = await _unitOfWork.EstadisticaRepository.GetByIdAsync(PersonajeToBeUpdated.energiaId);
            PersonajeToBeUpdated.energia.valor += PersonajeToBeUpdated.nivel * 50;
            PersonajeToBeUpdated.inteligencia = await _unitOfWork.EstadisticaRepository.GetByIdAsync(PersonajeToBeUpdated.inteligenciaId);
            PersonajeToBeUpdated.inteligencia.valor += new Random().Next(1,5);
            PersonajeToBeUpdated.agilidad = await _unitOfWork.EstadisticaRepository.GetByIdAsync(PersonajeToBeUpdated.agilidadId);
            PersonajeToBeUpdated.agilidad.valor += new Random().Next(1,5);
            PersonajeToBeUpdated.fuerza = await _unitOfWork.EstadisticaRepository.GetByIdAsync(PersonajeToBeUpdated.fuerzaId);
            PersonajeToBeUpdated.fuerza.valor += new Random().Next(1,5);
            PersonajeToBeUpdated.defensa = await _unitOfWork.EstadisticaRepository.GetByIdAsync(PersonajeToBeUpdated.defensaId);
            PersonajeToBeUpdated.defensa.valor += new Random().Next(1, 5);

            var validationResult = await PersonajeValidator.ValidateAsync(PersonajeToBeUpdated);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeToBeUpdatedId);
        }

        public async Task<AtaqueResponse> Atacar(int idEnemigo, int idPersonaje){

            EnemigoService _servicioEnemigo = new EnemigoService(_unitOfWork);

            AtaqueResponse response = new AtaqueResponse();
            // buscar info enemico 
            var enemigo = await _unitOfWork.EnemigoRepository.GetByIdAsync(idEnemigo);
            var personaje = await _unitOfWork.PersonajeRepository.GetByIdAsync(idPersonaje);

            personaje.fuerza = await _unitOfWork.EstadisticaRepository.GetByIdAsync(personaje.fuerzaId);
            personaje.salud = await _unitOfWork.EstadisticaRepository.GetByIdAsync(personaje.saludId);
            personaje.defensa = await _unitOfWork.EstadisticaRepository.GetByIdAsync(personaje.defensaId);
            if(Math.Abs(enemigo.nivelAmenaza - personaje.nivel) <= 5){
                int puntosDañoEnemigo = 0;
                int puntosDaño = (int)(
                                    (20 + personaje.fuerza.valor) * 1.5)
                                    - (int)(10 + enemigo.defensa * 1.75);
                enemigo.salud -=  puntosDaño;

                if(enemigo.salud > 0) {
                    puntosDañoEnemigo = (int)(
                                     (20 + enemigo.fuerza) * 1.5)
                                      - (int)(10 + personaje.defensa.valor * 1.75);
                    personaje.salud.valor -= puntosDañoEnemigo;

                }else{
                    personaje.experiencia += (enemigo.nivelAmenaza * 2);

                    if(personaje.nivel * 10 < personaje.experiencia){
                        await LevelUp(personaje.id);
                    }
                }
                response.personaje = personaje;
                response.enemigo = enemigo;
                response.mensaje = $"{personaje.nombre} atacó e inflingio {puntosDaño} a {enemigo.nombre} y sufrio un contraataque de {puntosDañoEnemigo}";
                await _unitOfWork.CommitAsync();
            }
            else{
                response.mensaje = "No es posible atacar al enemigo ";
            }


            return response;
        }

        public async Task<Personaje> AprenderHabilidad(int personajeToBeUpdatedId, int idHabilidad)
        {
            Personaje PersonajeToBeUpdated = await _unitOfWork.PersonajeRepository.GetByIdAsync(personajeToBeUpdatedId);
            Habilidad habilidad = await _unitOfWork.HabilidadRepository.GetByIdAsync(idHabilidad);
            if (PersonajeToBeUpdated == null)
                throw new ArgumentException("Invalid Personaje ID while updating");


            if (PersonajeToBeUpdated.habilidades.Where(Hab => Hab.id == idHabilidad).ToList().Count > 0)
                throw new ArgumentException("No se puede aprender la misma habilidad dos veces");


            PersonajeToBeUpdated.habilidades.Add(habilidad); //

            await _unitOfWork.CommitAsync();
            return PersonajeToBeUpdated;

        }

        public Task<Personaje> Create(Personaje newEntidad)
        {
            throw new NotImplementedException();
        }
    }
}
