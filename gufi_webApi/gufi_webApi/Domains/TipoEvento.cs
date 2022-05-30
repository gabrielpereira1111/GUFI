using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gufi_webApi.Domains
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdTipoEvento { get; set; }
        [Required(ErrorMessage = "Informe o título do tipo do evento")]
        public string? TituloTipoEvento { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
