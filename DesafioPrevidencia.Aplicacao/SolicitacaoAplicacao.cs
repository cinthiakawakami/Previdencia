using DesafioPrevidencia.Aplicacao.Interfaces;
using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace DesafioPrevidencia.Aplicacao
{
    public class SolicitacaoAplicacao : AplicacaoBase<Solicitacao>, ISolicitacaoAplicacao
    {
        private readonly ISolicitacaoServico _solicitacaoServico;

        public SolicitacaoAplicacao(ISolicitacaoServico solicitacaoServico)
            : base(solicitacaoServico)
        {
            _solicitacaoServico = solicitacaoServico;
        }
        public IEnumerable<Solicitacao> BuscarPoIdUsuario(int idUsuario)
        {
            return _solicitacaoServico.BuscarPoIdUsuario(idUsuario);
        }
        public Solicitacao MontarSolicitacao(int carteiraId, int usuarioId)
        {
            return _solicitacaoServico.MontarSolicitacao(carteiraId, usuarioId);
        }
        public Solicitacao BuscarPorProtocolo(string protocolo)
        {
            return _solicitacaoServico.BuscarPorProtocolo(protocolo);
        }
    }
}
