using gufi_webApi.Context;
using gufi_webApi.Domains;
using gufi_webApi.Interfaces;

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
            throw new NotImplementedException();
        }

        public void Update(TipoUsuario tipoUsuario, int idTipoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
