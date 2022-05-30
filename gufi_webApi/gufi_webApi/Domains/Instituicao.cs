using System;
using System.Collections.Generic;

namespace gufi_webApi.Domains
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdInstituicao { get; set; }
        public string Cnpj { get; set; } = null!;
        public string NomeFantasia { get; set; } = null!;
        public string Endereco { get; set; } = null!;

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
