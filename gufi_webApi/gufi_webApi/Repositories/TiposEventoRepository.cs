using gufi_webApi.Context;
using gufi_webApi.Domains;
using gufi_webApi.Interfaces;

namespace gufi_webApi.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        GufiContext ctx = new GufiContext();
        public void Create(TipoEvento tipoEvento)
        {
            ctx.TipoEventos.Add(tipoEvento);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            TipoEvento tipoEvento = GetById(id);
            ctx.Remove(tipoEvento);
            ctx.SaveChanges();
        }

        public void Delete(string nomeTipoEvento)
        {
            TipoEvento tipoEventoBuscado = ctx.TipoEventos.First(p => p.TituloTipoEvento == nomeTipoEvento);
            ctx.Remove(tipoEventoBuscado);
            ctx.SaveChanges();
        }

        public TipoEvento GetById(int id)
        {
            TipoEvento tipoEvento = ctx.TipoEventos.First(p => p.IdTipoEvento == id);
            if(tipoEvento != null)
            {
                return tipoEvento;
            }
            return null;
        }

        public List<TipoEvento> ReadAll()
        {
            return ctx.TipoEventos.ToList();
        }

        public void Update(TipoEvento tipoEvento, int id)
        {
            throw new NotImplementedException();
        }
    }
}
