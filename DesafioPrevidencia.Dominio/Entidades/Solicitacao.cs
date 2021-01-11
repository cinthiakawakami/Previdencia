using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPrevidencia.Dominio.Entidades
{
    public class Solicitacao
    {
        [Key]
        public int SolicitacaoId { get; set; }
        [Required]
        public DateTime DataSolicitacao { get; set; }
        public int CarteiraId { get; set; }
        [ForeignKey("CarteiraId")]
        public virtual Carteira Carteira { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Protocolo { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
