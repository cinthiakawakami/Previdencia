using System.ComponentModel.DataAnnotations;

namespace DesafioPrevidencia.Dominio.Entidades
{
    public class PerfilInvestidor
    {
        [Key]
        public int PerfilInvestidorId { get; set; }
        [Required]
        public string Nome { get; set; }
    }

}
