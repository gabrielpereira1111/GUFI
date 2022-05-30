using gufi_webApi.Context;
using gufi_webApi.Domains;
using gufi_webApi.Interfaces;

namespace gufi_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        GufiContext ctx = new GufiContext();
        public Usuario Login(string email, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
            
            if (usuarioBuscado != null)
            {
                return usuarioBuscado;
            }

            return null;
        }
    }
}
