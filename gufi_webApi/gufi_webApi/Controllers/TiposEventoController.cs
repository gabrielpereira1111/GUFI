using gufi_webApi.Domains;
using gufi_webApi.Interfaces;
using gufi_webApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gufi_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposEventoController : ControllerBase
    {
        private ITiposEventoRepository _tiposEventosRepository { get; set; } = null!;
        public TiposEventoController()
        {
            _tiposEventosRepository = new TiposEventoRepository();
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            try
            {
                return Ok(_tiposEventosRepository.ReadAll());
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
                TipoEvento tipoEventoBuscado = _tiposEventosRepository.GetById(id);
                return Ok(tipoEventoBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("deletarporid/{id}")]
        public IActionResult DeleteId(int id)
        {
            try
            {
                _tiposEventosRepository.Delete(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("deletarpornome/{nomeTipoEvento}")]
        public IActionResult DeleteNome(string nomeTipoEvento)
        {
            try
            {
                _tiposEventosRepository.Delete(nomeTipoEvento);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                _tiposEventosRepository.Create(tipoEvento);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
