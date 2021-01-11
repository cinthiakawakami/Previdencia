using System.ComponentModel.DataAnnotations;

namespace DesafioPrevidencia.MVC.Models
{
    public class CarteiraModel
    {
        [Key]
        public int CarteiraId { get; set; }
        public string Composicao { get; set; }
        public string Rentabilidade { get; set; }
        public string Descricao { get; set; }
        public int PerfilInvestidorId { get; set; }
        public virtual PerfilInvestidorModel PerfilInvestidor { get; set; }
    }
}