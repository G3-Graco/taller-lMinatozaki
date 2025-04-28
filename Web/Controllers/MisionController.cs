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
    public class MisionController : ControllerBase
    {
        private readonly IMisionService _misionService;

        public MisionController(IMisionService misionService)
        {
            _misionService = misionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mision>>> Get()
        {
            var misiones = await _misionService.GetAll();
            return Ok(misiones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mision>> GetById(int id)
        {
            try
            {
                var mision = await _misionService.GetById(id);
                return Ok(mision);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Mision>> Post([FromBody] Mision mision)
        {
            try
            {
                var createdMision = await _misionService.Create(mision);
                return CreatedAtAction(nameof(GetById), new { id = createdMision.id }, createdMision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Mision>> Update(int id, [FromBody] Mision mision)
        {
            try
            {
                var updatedMision = await _misionService.Update(id, mision);
                return Ok(updatedMision);
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
                await _misionService.Delete(id);
                return Ok("Misión eliminada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/aceptar")]
        public async Task<ActionResult<Mision>> AceptarMision(int id)
        {
            try
            {
                var mision = await _misionService.AceptarMision(id);
                return Ok(mision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/progreso")]
        public async Task<ActionResult<Mision>> IndicarProgreso(int id, [FromQuery] string objetivo)
        {
            try
            {
                var mision = await _misionService.IndicarProgresoMision(id, objetivo);
                return Ok(mision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/completar")]
        public async Task<ActionResult<Mision>> CompletarMision(int id)
        {
            try
            {
                var mision = await _misionService.CompletarMision(id);
                return Ok(mision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}