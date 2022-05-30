using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gufi_webApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "Informe o nome do tipo de usuário")]
        public string TituloTipoUsuario { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
