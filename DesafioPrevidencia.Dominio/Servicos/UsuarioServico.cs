using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Repositorios;
using DesafioPrevidencia.Dominio.Interfaces.Servicos;

namespace DesafioPrevidencia.Dominio.Servicos
{
    public class UsuarioServico : ServicoBase<Usuario>, IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
            : base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public Usuario ObterUsuarioPeloEmail(string email)
        {
            return _usuarioRepositorio.ObterUsuarioPeloEmail(email);
        }
    }
}
