using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gufi_webApi.Interfaces;
using gufi_webApi.Repositories;
using gufi_webApi.Domains;

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
    }
}
