using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaCandidato.Data.Entidade
{
    [Table("ClienteObservacao")]
    public class ClienteObservacao
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Required]
        [Column("observacao")]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
