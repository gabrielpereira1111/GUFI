using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gufi_webApi.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdEvento { get; set; }
        [Required(ErrorMessage = "Informe o tipo de evento!")]
        public int? IdTipoEvento { get; set; }
        [Required(ErrorMessage = "Informe a instituição responsável pelo evento!")]
        public int? IdInstituicao { get; set; }
        [Required(ErrorMessage = "Informe o nome do evento!")]
        public string NomeEvento { get; set; } = null!;
        [Required(ErrorMessage = "Informe a descrição do evento!")]
        public string Descricao { get; set; } = null!;
        [Required(ErrorMessage = "Informe a data do evento!")]
        [DataType(DataType.DateTime)]
        public DateTime DataEvento { get; set; }
        [Required(ErrorMessage = "Informe se o evento é público ou privado!")]
        public bool? AcessoLivre { get; set; }

        public virtual Instituicao? IdInstituicaoNavigation { get; set; }
        public virtual TipoEvento? IdTipoEventoNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
