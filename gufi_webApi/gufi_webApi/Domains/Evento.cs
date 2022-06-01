using System;
using System.Collections.Generic;

namespace gufi_webApi.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdEvento { get; set; }
        public int? IdTipoEvento { get; set; }
        public int? IdInstituicao { get; set; }
        public string NomeEvento { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public DateTime DataEvento { get; set; }
        public bool? AcessoLivre { get; set; }

        public virtual Instituicao? IdInstituicaoNavigation { get; set; }
        public virtual TipoEvento? IdTipoEventoNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
