using DesafioPrevidencia.Aplicacao.Interfaces;
using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Servicos;

namespace DesafioPrevidencia.Aplicacao
{
    public class RespostasFormularioAplicacao : AplicacaoBase<RespostasFormulario>, IRespostasFormularioAplicacao
    {
        private readonly IRespostasFormularioServico _respostasFormularioServico;

        public RespostasFormularioAplicacao(IRespostasFormularioServico respostasFormularioServico)
            : base(respostasFormularioServico)
        {
            _respostasFormularioServico = respostasFormularioServico;
        }

        public RespostasFormulario BuscarPoIdUsuario(int idUsuario)
        {
            return _respostasFormularioServico.BuscarPoIdUsuario(idUsuario);
        }
        public RespostasFormulario MontarPerfilRespostasFormulario(RespostasFormulario respostasFormulario)
        {
            return _respostasFormularioServico.MontarPerfilRespostasFormulario(respostasFormulario);
        }
    }
}
