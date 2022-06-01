using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gufi_webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Informe o tipo desse usuário!")]
        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "Informe o nome do usuário!")]
        public string NomeUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Informe o email do usuário!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Informe a senha do usuário!")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "A senha deve ter, no mínimo, 10 caracteres e, no máximo, 20 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = null!;

        public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
