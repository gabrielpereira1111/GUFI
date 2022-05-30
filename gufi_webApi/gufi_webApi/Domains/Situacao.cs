using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gufi_webApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdSituacao { get; set; }
        [Required(ErrorMessage = "Informe a descrição da situação")]
        public string? Descricao { get; set; }

        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
