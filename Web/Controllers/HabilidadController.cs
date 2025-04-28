using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadController : ControllerBase
    {
        private IHabilidadService _servicio;
        public HabilidadController(IHabilidadService habilidadService)
        {
            _servicio = habilidadService;
        }

        /// <summary>
        /// Obtener todas las habilidades configuradas
        /// </summary>
        /// <returns>Lista de actividades</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habilidad>>> Get()
        {

            var Personajes = await _servicio.GetAll();

            return Ok(Personajes);
        }


        // POST api/<PersonajeController>
        /// <summary>
        /// Método para crear una habilidad nueva
        /// </summary>
        /// <param name="personaje">Instacia de la clase habilidad</param>
        /// <returns>Objeto Habilidad</returns>
        /// <remarks>
        /// Ejemplo de un JSON request
        /// {
        ///     "id": 0,
        ///     "nombre": "string"
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Habilidad>> Post([FromBody] Habilidad personaje)
        {
            try
            {
                var createdPersonaje =
                    await _servicio.Create(personaje);

                return Ok(createdPersonaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Habilidad>>> Delete(int id)
        {

            try
            {
                await _servicio.Delete(id);
                return Ok("Habilidad eliminado");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Habilidad>> Update(int id, string algo, [FromBody] Habilidad personaje)
        {
            try
            {
                await _servicio.Update(id, personaje);
                return Ok("Habilidad Actualizado!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

    }
}
