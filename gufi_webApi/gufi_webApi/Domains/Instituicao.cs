using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gufi_webApi.Domains
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdInstituicao { get; set; }
        [Required(ErrorMessage = "Informe o CNPJ da instituição")]
        public string Cnpj { get; set; } = null!;
        [Required(ErrorMessage = "Informe o nome fantasia da instituição")]
        public string NomeFantasia { get; set; } = null!;
        [Required(ErrorMessage = "Informe o endereço da instituição")]
        public string Endereco { get; set; } = null!;

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
