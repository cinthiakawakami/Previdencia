using DesafioPrevidencia.Dominio.Entidades;

namespace DesafioPrevidencia.Dominio.Interfaces.Servicos
{
    public interface IRespostasFormularioServico : IServicoBase<RespostasFormulario>
    {
        RespostasFormulario BuscarPoIdUsuario(int idUsuario);
        RespostasFormulario MontarPerfilRespostasFormulario(RespostasFormulario respostasFormulario);
    }
}
