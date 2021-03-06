using gufi_webApi.Context;
using gufi_webApi.Domains;
using gufi_webApi.Interfaces;

namespace gufi_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        GufiContext ctx = new GufiContext();

        public void CadastrarBD(IFormFile arquivo, int idUsuario)
        {
            ImagemUsuario imagemUsuario = new ImagemUsuario();
            using (var memory = new MemoryStream())
            {
                arquivo.CopyTo(memory);
                imagemUsuario.Binario = memory.ToArray();
                imagemUsuario.NomeArquivo = arquivo.FileName;
                imagemUsuario.MimeType = arquivo.FileName.Split('.').Last();
                imagemUsuario.IdUsuario = idUsuario;
            }

            ImagemUsuario imagemExistente = ctx.ImagemUsuarios.FirstOrDefault(p => p.IdUsuario == idUsuario);
            
            if (imagemExistente != null)
            {
                imagemExistente.Binario = imagemUsuario.Binario;
                imagemExistente.NomeArquivo = imagemUsuario.NomeArquivo;
                imagemExistente.MimeType = imagemUsuario.MimeType;

                ctx.ImagemUsuarios.Update(imagemExistente);
            }
            else
            {
                ctx.ImagemUsuarios.Add(imagemUsuario);
            }

            ctx.SaveChanges();
        }

        public void CadastrarDir(IFormFile arquivo, int idUsuario)
        {
            string nomeArquivo = idUsuario.ToString() + ".png";

            using (var file = new FileStream(Path.Combine("Perfil", nomeArquivo), FileMode.Create))
            {
                arquivo.CopyTo(file);
            }
        }

        public string ConsularDir(int idUsuario)
        {
            string nomeArquivo = idUsuario.ToString() + ".png";
            string caminho = Path.Combine("Perfil", nomeArquivo);
            if (File.Exists(caminho))
            {
                byte[] bytes = File.ReadAllBytes(caminho);
                string base64 = Convert.ToBase64String(bytes);
                return base64;
            }

            return null;
        }

        public string ConsultarBD(int idUsuario)
        {
            ImagemUsuario imagemUsuario = ctx.ImagemUsuarios.FirstOrDefault(p => p.IdUsuario == idUsuario);

            if (imagemUsuario == null)
            {
                return null;
            }

            byte[] bytes = imagemUsuario.Binario;
            return Convert.ToBase64String(bytes);
        }

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
