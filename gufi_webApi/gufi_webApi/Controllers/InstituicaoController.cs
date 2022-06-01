using gufi_webApi.Domains;
using gufi_webApi.Interfaces;
using gufi_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gufi_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository { get; set; } = null!;
        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Create(instituicao);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
