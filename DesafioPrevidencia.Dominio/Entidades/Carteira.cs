using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPrevidencia.Dominio.Entidades
{
    public class Carteira
    {
        [Key]
        public int CarteiraId { get; set; }
        [Required]
        public string Composicao { get; set; }
        [Required]
        public string Rentabilidade { get; set; }
        [Required]
        public string Descricao { get; set; }
        public int PerfilInvestidorId { get; set; }
        [ForeignKey("PerfilInvestidorId")]
        public virtual PerfilInvestidor PerfilInvestidor { get; set; }
    }
}
