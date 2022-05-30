using gufi_webApi.Domains;
using gufi_webApi.Interfaces;
using gufi_webApi.Repositories;
using gufi_webApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace gufi_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository? _usuarioRepository { get; set; }
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel login, int idade)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);
                if (usuarioBuscado != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                        new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario),
                        new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                        new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                        new Claim("Role", usuarioBuscado.IdTipoUsuario.ToString())
                    };

                    // Define a chave de segurança. Transforma cada caractere da chave em bytes
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-segura-gufi"));
                    // Criptografa a chave definida acima
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var myToken = new JwtSecurityToken(
                            issuer : "gufi_webApi",
                            audience : "gufi_webApi",
                            claims : claims,
                            expires : DateTime.Now.AddMinutes(30),
                            signingCredentials : creds
                        );

                    return Ok(
                            new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(myToken)
                            }
                        );
                }
                return NotFound("E-mail e/ou senha não encontrados");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
