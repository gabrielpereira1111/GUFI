using gufi_webApi.Context;
using gufi_webApi.Domains;
using gufi_webApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gufi_webApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();
        public void AtualizarPresencao(int idPresenca, string situacao)
        {
            throw new NotImplementedException();
        }

        public void Inscrever(Presenca presenca)
        {
            throw new NotImplementedException();
        }

        public List<Presenca> ListarMinhas(int idUsuario)
        {
            return ctx.Presencas
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdSituacaoNavigation)
                .Include(p => p.IdEventoNavigation)
                .Where(p => p.IdUsuario == idUsuario)
                .ToList();
        }
    }
}
