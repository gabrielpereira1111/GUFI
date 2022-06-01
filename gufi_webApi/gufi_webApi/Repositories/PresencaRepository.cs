using gufi_webApi.Context;
using gufi_webApi.Domains;
using gufi_webApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gufi_webApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();
        public void AtualizarPresencas(int idPresenca, string situacao)
        {
            Presenca presencaBuscada = ctx.Presencas.First(p => p.IdPresenca == idPresenca);

            switch (situacao)
            {
                case "1":
                    presencaBuscada.IdSituacao = 1;
                    break;
                case "2":
                    presencaBuscada.IdSituacao = 2;
                    break;
                case "3":
                    presencaBuscada.IdSituacao = 3;
                    break;
                default:
                    break;
            }

            ctx.Presencas.Update(presencaBuscada);
            ctx.SaveChanges();
        }

        public void Inscrever(Presenca presenca)
        {
            ctx.Presencas.Add(presenca);
            ctx.SaveChanges();
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
