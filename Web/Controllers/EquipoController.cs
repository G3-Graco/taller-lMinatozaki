using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IEquipoService _equipoService;

        public EquipoController(IEquipoService equipoService)
        {
            _equipoService = equipoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> Get()
        {
            var equipos = await _equipoService.GetAll();
            return Ok(equipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipo>> GetById(int id)
        {
            try
            {
                var equipo = await _equipoService.GetById(id);
                return Ok(equipo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Equipo>> Post([FromBody] Equipo equipo)
        {
            try
            {
                var createdEquipo = await _equipoService.Create(equipo);
                return CreatedAtAction(nameof(GetById), new { id = createdEquipo.id }, createdEquipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Equipo>> Update(int id, [FromBody] Equipo equipo)
        {
            try
            {
                var updatedEquipo = await _equipoService.Update(id, equipo);
                return Ok(updatedEquipo);
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
                await _equipoService.Delete(id);
                return Ok("Equipo eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/equipar")]
        public async Task<ActionResult<Equipo>> Equipar(int id, [FromQuery] int objeto)
        {
            try
            {
                var equipoActualizado = await _equipoService.Equipar(id, objeto);
                return Ok(equipoActualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/desequipar")]
        public async Task<ActionResult<Equipo>> Desequipar(int id, [FromQuery] int ranura)
        {
            try
            {
                var equipoActualizado = await _equipoService.Desequipar(id, ranura);
                return Ok(equipoActualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}