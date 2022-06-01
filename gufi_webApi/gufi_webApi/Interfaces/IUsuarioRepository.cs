using gufi_webApi.Domains;

namespace gufi_webApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        void CadastrarBD(IFormFile arquivo, int idUsuario);
        void CadastrarDir(IFormFile arquivo, int idUsuario);
        string ConsultarBD(int idUsuario);
        string ConsularDir(int idUsuario);
    }
}
