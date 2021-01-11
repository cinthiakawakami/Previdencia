using DesafioPrevidencia.Aplicacao.Interfaces;
using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Servicos;

namespace DesafioPrevidencia.Aplicacao
{
    public class UsuarioAplicacao : AplicacaoBase<Usuario>, IUsuarioAplicacao
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioAplicacao(IUsuarioServico usuarioServico)
            : base(usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }
        public Usuario ObterUsuarioPeloEmail(string email)
        {
            return _usuarioServico.ObterUsuarioPeloEmail(email);
        }
    }
}
