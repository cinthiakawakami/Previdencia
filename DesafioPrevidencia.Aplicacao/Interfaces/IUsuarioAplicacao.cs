using DesafioPrevidencia.Dominio.Entidades;

namespace DesafioPrevidencia.Aplicacao.Interfaces
{
    public interface IUsuarioAplicacao : IAplicacaoBase<Usuario>
    {
        Usuario ObterUsuarioPeloEmail(string email);
    }
}
