using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioPrevidencia.MVC.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Preencha o campo Senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Mínimo de 6 caracteres")]
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas digitadas não não iguais.")]
        public string ConfirmarSenha { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public int? CarteiraId { get; set; }
        public virtual CarteiraModel Carteira { get; set; }
    }
}