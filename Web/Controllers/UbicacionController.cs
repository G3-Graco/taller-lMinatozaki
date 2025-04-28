using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Entities;
using Core.Interfaces.Services;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionService _ubicacionService;

        public UbicacionController(IUbicacionService ubicacionService)
        {
            _ubicacionService = ubicacionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> Get()
        {
            var ubicaciones = await _ubicacionService.GetAll();
            return Ok(ubicaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> GetById(int id)
        {
            try
            {
                var ubicacion = await _ubicacionService.GetById(id);
                return Ok(ubicacion);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Ubicacion>> Post([FromBody] Ubicacion ubicacion)
        {
            try
            {
                var createdUbicacion = await _ubicacionService.Create(ubicacion);
                return CreatedAtAction(nameof(GetById), new { id = createdUbicacion.id }, createdUbicacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ubicacion>> Update(int id, [FromBody] Ubicacion ubicacion)
        {
            try
            {
                var updatedUbicacion = await _ubicacionService.Update(id, ubicacion);
                return Ok(updatedUbicacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _ubicacionService.Delete(id);
                return Ok("Ubicación eliminada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/moverse")]
        public async Task<ActionResult<string>> Moverse(int id, [FromQuery] int personajeId)
        {
            try
            {
                var resultado = await _ubicacionService.Moverse(personajeId, id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}