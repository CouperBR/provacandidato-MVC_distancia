using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaCandidato.Data.Entidade
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Required]
        [Column("nome")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Column("data_nascimento")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }

        [Column("codigo_cidade")]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        public bool Ativo { get; set; }

        [ForeignKey("CidadeId")]
        [Display(Name = "Cidade")]
        public virtual Cidade Cidade { get; set; }

        [Display(Name = "Observações")]
        [InverseProperty("Cliente")]
        public virtual ICollection<ClienteObservacao> ClienteObservacoes { get; set; }

    }
}