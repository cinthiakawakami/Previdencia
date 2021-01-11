using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioPrevidencia.MVC.Models
{
    public class SolicitacaoModel
    {
        [Key]
        public int SolicitacaoId { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public int CarteiraId { get; set; }
        public virtual CarteiraModel Carteira { get; set; }
        public int UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
        public string Tipo { get; set; }
        public string Protocolo { get; set; }
        public string Status { get; set; }
    }
}