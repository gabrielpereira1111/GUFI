using gufi_webApi.Context;
using gufi_webApi.Domains;
using gufi_webApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gufi_webApi.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        GufiContext ctx = new GufiContext();
        public void Create(Evento evento)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Evento eventoBuscado = GetById(id);
            ctx.Eventos.Remove(eventoBuscado);
            ctx.SaveChanges();
        }

        public Evento GetById(int id)
        {
            return ctx.Eventos
                .Include(p => p.IdInstituicaoNavigation)
                .Include(p => p.IdTipoEventoNavigation)
                .Select(p => new Evento
                {
                    IdEvento = p.IdEvento,
                    IdTipoEvento = p.IdTipoEvento,
                    IdTipoEventoNavigation = new TipoEvento
                    {
                        IdTipoEvento = p.IdTipoEventoNavigation.IdTipoEvento,
                        TituloTipoEvento = p.IdTipoEventoNavigation.TituloTipoEvento
                    },
                    IdInstituicao = p.IdInstituicao,
                    IdInstituicaoNavigation = new Instituicao
                    {
                        IdInstituicao = p.IdInstituicaoNavigation.IdInstituicao,
                        Cnpj = p.IdInstituicaoNavigation.Cnpj,
                        NomeFantasia = p.IdInstituicaoNavigation.NomeFantasia,
                        Endereco = p.IdInstituicaoNavigation.Endereco
                    },
                    NomeEvento = p.NomeEvento,
                    Descricao = p.Descricao,
                    DataEvento = p.DataEvento,
                    AcessoLivre = p.AcessoLivre
                })
                .First(e => e.IdEvento == id);
        }

        public List<Evento> ReadAll()
        {
            return ctx.Eventos
                .Include(p => p.IdInstituicaoNavigation)
                .Include(p => p.IdTipoEventoNavigation)
                .Select(p => new Evento
                {
                    IdEvento = p.IdEvento,
                    IdTipoEvento = p.IdTipoEvento,
                    IdTipoEventoNavigation = new TipoEvento
                    {
                        IdTipoEvento = p.IdTipoEventoNavigation.IdTipoEvento,
                        TituloTipoEvento = p.IdTipoEventoNavigation.TituloTipoEvento
                    },
                    IdInstituicao = p.IdInstituicao,
                    IdInstituicaoNavigation = new Instituicao
                    {
                        IdInstituicao = p.IdInstituicaoNavigation.IdInstituicao,
                        Cnpj = p.IdInstituicaoNavigation.Cnpj,
                        NomeFantasia = p.IdInstituicaoNavigation.NomeFantasia,
                        Endereco = p.IdInstituicaoNavigation.Endereco
                    },
                    NomeEvento = p.NomeEvento,
                    Descricao = p.Descricao,
                    DataEvento = p.DataEvento,
                    AcessoLivre = p.AcessoLivre
                })
                .ToList();
        }

        public void Update(Evento evento, int id)
        {
            throw new NotImplementedException();
        }
    }
}
