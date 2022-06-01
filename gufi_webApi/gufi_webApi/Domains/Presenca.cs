using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gufi_webApi.Domains
{
    public partial class Presenca
    {
        public int IdPresenca { get; set; }
        [Required(ErrorMessage = "Informe o usuário!")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Informe o evento!")]
        public int IdEvento { get; set; }
        [Required(ErrorMessage = "Informe a situação!")]
        public int IdSituacao { get; set; } = 3;

        public virtual Evento? IdEventoNavigation { get; set; }
        public virtual Situacao? IdSituacaoNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
