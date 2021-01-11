using DesafioPrevidencia.Dominio.Entidades;

namespace DesafioPrevidencia.Aplicacao.Interfaces
{
    public interface IRespostasFormularioAplicacao : IAplicacaoBase<RespostasFormulario>
    {
        RespostasFormulario BuscarPoIdUsuario(int idUsuario);
        RespostasFormulario MontarPerfilRespostasFormulario(RespostasFormulario respostasFormulario);
    }
}
