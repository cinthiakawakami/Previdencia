using System.ComponentModel.DataAnnotations;

namespace DesafioPrevidencia.MVC.Models
{
    public class UsuarioLoginModel
    {
        [Display(Name = "E-mail")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "E-mail é obrigatório.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Manter conectado")]
        public bool ManterConectado { get; set; }
    }
}