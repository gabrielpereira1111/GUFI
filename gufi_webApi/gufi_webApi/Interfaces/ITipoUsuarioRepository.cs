using gufi_webApi.Domains;

namespace gufi_webApi.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Create(TipoUsuario tipoUsuario);
        List<TipoUsuario> ReadAll();
        TipoUsuario GetById(int id);
        void Update(TipoUsuario tipoUsuario, int idTipoUsuario);
        void Delete(int id);

    }
}
