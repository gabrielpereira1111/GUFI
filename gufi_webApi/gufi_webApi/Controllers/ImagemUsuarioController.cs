using gufi_webApi.Interfaces;
using gufi_webApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace gufi_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagemUsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public ImagemUsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost("imagem/bd")]
        public IActionResult CadastrarBd(IFormFile file)
        {
            try
            {
                if (file.Length > 6000000)
                {
                    return BadRequest("Tamanho suportado da imagem excedido");
                }

                string extensao = file.FileName.Split('.').Last();

                if (extensao != "png")
                {
                    return BadRequest("Somente formato PNG aceito");
                }

                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(p => p.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.CadastrarBD(file, idUsuario);
                
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("consulta/bd")]
        public IActionResult ConsultaBD()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(p => p.Type == JwtRegisteredClaimNames.Jti).Value);
                string base64 = _usuarioRepository.ConsultarBD(idUsuario);
                return Ok(base64);

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
