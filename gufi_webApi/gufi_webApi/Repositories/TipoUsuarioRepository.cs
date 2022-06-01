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
            throw new NotImplementedException();
        }

        public TipoUsuario GetById(int id)
        {
            TipoUsuario usuarioBuscado = ctx.TipoUsuarios.First(p => p.IdTipoUsuario == id);
            if (usuarioBuscado != null)
            {
                return usuarioBuscado;
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
