using System;
using System.Collections.Generic;

namespace gufi_webApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdSituacao { get; set; }
        public string? Descricao { get; set; }

        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
