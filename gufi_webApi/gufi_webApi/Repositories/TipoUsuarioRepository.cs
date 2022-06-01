using gufi_webApi.Context;
using gufi_webApi.Domains;
using gufi_webApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gufi_webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        GufiContext ctx = new GufiContext();

        public void Create(TipoUsuario tipoUsuario)
        {
            ctx.TipoUsuarios.Add(tipoUsuario);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            TipoUsuario tipoUsuarioBuscado = GetById(id);
            ctx.Remove(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public TipoUsuario GetById(int id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.First(p => p.IdTipoUsuario == id);
            if (tipoUsuarioBuscado != null)
            {
                return tipoUsuarioBuscado;
            }
            return null;
        }

        public List<TipoUsuario> ReadAll()
        {
            return ctx.TipoUsuarios
                .Include(t => t.Usuarios)
                .Select(t => new TipoUsuario
                {
                    IdTipoUsuario = t.IdTipoUsuario,
                    TituloTipoUsuario = t.TituloTipoUsuario
                })
                .ToList();
        }

        public void Update(TipoUsuario tipoUsuario, int idTipoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
