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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; } = null!;
        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.ReadAll());
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
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.GetById(id);
                if (tipoUsuarioBuscado != null)
                {
                    return Ok(tipoUsuarioBuscado);
                }
                return NotFound("Tipo de usuário não encontrado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
