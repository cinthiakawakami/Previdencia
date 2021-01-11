using DesafioPrevidencia.Dominio.Entidades;

namespace DesafioPrevidencia.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Usuario ObterUsuarioPeloEmail(string email);
    }
}
