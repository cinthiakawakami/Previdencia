using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPrevidencia.Dominio.Entidades
{
    public class RespostasFormulario
    {
        [Key]
        public int RespostasFormularioId { get; set; }
        [Required]
        public int RespostaPrazoAplicacao { get; set; }
        [Required]
        public int RespostaPossibilidadePerda { get; set; }
        [Required]
        public int RespostaResgate { get; set; }
        [Required]
        public int RespostaObjetivos { get; set; }
        [Required]
        public int RespostaRenda { get; set; }
        [Required]
        public DateTime DataResposta { get; set; }
        public int PerfilInvestidorId { get; set; }
        [ForeignKey("PerfilInvestidorId")]
        public virtual PerfilInvestidor PerfilInvestidor { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }
}
