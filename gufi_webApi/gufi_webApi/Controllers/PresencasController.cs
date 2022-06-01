using gufi_webApi.Domains;
using gufi_webApi.Interfaces;
using gufi_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace gufi_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencasController : ControllerBase, IHttpContextAccessor
    {
        private IPresencaRepository _presencaRepository { get; set; }
        HttpContext? IHttpContextAccessor.HttpContext { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PresencasController()
        {
            _presencaRepository = new PresencaRepository();
        }

        [Authorize(Roles = "2")]
        [HttpGet("minhaspresencas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(p => p.Type == JwtRegisteredClaimNames.Jti).Value);
                List<Presenca> listaPresenca = _presencaRepository.ListarMinhas(idUsuario);
                if (listaPresenca == null)
                {
                    return NotFound("Você não está inscrito em nenhum evento");
                }

                return Ok(listaPresenca);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPost("inscricao/{idEvento}")]
        public IActionResult Inscrever(int idEvento)
        {

            try
            {
                Presenca presenca = new Presenca()
                {
                    IdEvento = idEvento,
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(u => u.Type == JwtRegisteredClaimNames.Jti).Value),
                    IdSituacao = 3
                };

                _presencaRepository.Inscrever(presenca);

                return StatusCode(201);

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
