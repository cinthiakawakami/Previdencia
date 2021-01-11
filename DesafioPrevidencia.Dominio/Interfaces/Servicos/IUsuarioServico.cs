using DesafioPrevidencia.Dominio.Entidades;

namespace DesafioPrevidencia.Dominio.Interfaces.Servicos
{
    public interface IUsuarioServico : IServicoBase<Usuario>
    {
        Usuario ObterUsuarioPeloEmail(string email);
    }
}
