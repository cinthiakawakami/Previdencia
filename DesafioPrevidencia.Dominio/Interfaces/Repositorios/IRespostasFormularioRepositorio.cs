using DesafioPrevidencia.Dominio.Entidades;

namespace DesafioPrevidencia.Dominio.Interfaces.Repositorios
{
    public interface IRespostasFormularioRepositorio : IRepositorioBase<RespostasFormulario>
    {
        RespostasFormulario BuscarPoIdUsuario(int idUsuario);
    }
}
