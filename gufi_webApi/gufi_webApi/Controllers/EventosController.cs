using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gufi_webApi.Interfaces;
using gufi_webApi.Repositories;
using gufi_webApi.Domains;
using Microsoft.AspNetCore.Authorization;

namespace gufi_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private IEventoRepository _eventoRepository { get; set; } = null!;
        public EventosController()
        {
            _eventoRepository = new EventoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.ReadAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.GetById(id);
                if (eventoBuscado != null)
                {
                    return Ok(eventoBuscado);
                }
                return NotFound("Evento não encontrado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Evento eventos)
        {
            try
            {
                _eventoRepository.Create(eventos);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.GetById(id);
                if (eventoBuscado != null)
                {
                    _eventoRepository.Delete(id);
                    return NoContent();
                }
                return NotFound("Evento não encontrado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
