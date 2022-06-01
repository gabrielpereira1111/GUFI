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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuario> ReadAll()
        {
            return ctx.TipoUsuarios
                .Include(t => t.Usuarios)
                .Select(t => new TipoUsuario
                {
                    TituloTipoUsuario = t.TituloTipoUsuario,
                    Usuarios = new List<Usuario>()
                })
                .ToList();
        }

        public void Update(TipoUsuario tipoUsuario, int idTipoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
