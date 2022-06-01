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
                .Select(p => new Presenca{ 
                    IdPresenca = p.IdPresenca,
                    IdUsuario = p.IdUsuario,
                    IdEvento = p.IdEvento,
                    IdSituacao = p.IdSituacao,
                    IdEventoNavigation = new Evento
                    {
                        IdEvento = p.IdEventoNavigation.IdEvento,
                        NomeEvento = p.IdEventoNavigation.NomeEvento,
                        Descricao = p.IdEventoNavigation.Descricao,
                        DataEvento = p.IdEventoNavigation.DataEvento,
                        AcessoLivre = p.IdEventoNavigation.AcessoLivre
                    },
                    IdSituacaoNavigation = new Situacao
                    {
                        IdSituacao = p.IdSituacaoNavigation.IdSituacao,
                        Descricao = p.IdSituacaoNavigation.Descricao
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                        NomeUsuario = p.IdUsuarioNavigation.NomeUsuario,
                        Email = p.IdUsuarioNavigation.Email,
                        IdTipoUsuario = p.IdUsuarioNavigation.IdTipoUsuario
                    }
                })
                .Where(p => p.IdUsuario == idUsuario)
                .ToList();
        }
    }
}
