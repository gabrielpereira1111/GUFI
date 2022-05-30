using gufi_webApi.Domains;

namespace gufi_webApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
    }
}
