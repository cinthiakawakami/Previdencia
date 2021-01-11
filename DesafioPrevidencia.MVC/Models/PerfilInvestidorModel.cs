using System.ComponentModel.DataAnnotations;

namespace DesafioPrevidencia.MVC.Models
{
    public class PerfilInvestidorModel
    {
        [Key]
        public int PerfilInvestidorId { get; set; }
        public string Nome { get; set; }
    }
}