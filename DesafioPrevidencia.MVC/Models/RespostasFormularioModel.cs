using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioPrevidencia.MVC.Models
{
    public class RespostasFormularioModel
    {
        [Key]
        public int RespostasFormularioId { get; set; }

        [Required(ErrorMessage = "Preencha ao menos alguma resposta.")]
        [DisplayName("Qual o prazo que poderá deixar o valor aplicado?")]
        public int RespostaPrazoAplicacao { get; set; }

        [Required(ErrorMessage = "Preencha ao menos alguma resposta.")]
        [DisplayName("Como você reagiria a eventuais perdas na sua aplicação?")]
        public int RespostaPossibilidadePerda { get; set; }

        [Required(ErrorMessage = "Preencha ao menos alguma resposta.")]
        [DisplayName("Qual a previsão de resgate em anos?")]
        public int RespostaResgate { get; set; }

        [DisplayName("Qual o seu objetivo com a aplicação?")]
        [Required(ErrorMessage = "Preencha ao menos alguma resposta.")]
        public int RespostaObjetivos { get; set; }

        [Required(ErrorMessage = "Preencha ao menos alguma resposta.")]
        [DisplayName("Qual valor será aplicado?")]
        public int RespostaRenda { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataResposta { get; set; }
        public int PerfilInvestidorId { get; set; }

        public virtual PerfilInvestidorModel PerfilInvestidor { get; set; }
        public int UsuarioId { get; set; }

        public virtual UsuarioModel Usuario { get; set; }
    }
}