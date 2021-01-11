using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPrevidencia.Dominio.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        public int? CarteiraId { get; set; }
        [ForeignKey("CarteiraId")]
        public virtual Carteira Carteira { get; set; }

    }
}
