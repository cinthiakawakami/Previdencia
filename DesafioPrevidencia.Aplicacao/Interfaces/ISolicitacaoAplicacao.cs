using DesafioPrevidencia.Dominio.Entidades;
using System.Collections.Generic;

namespace DesafioPrevidencia.Aplicacao.Interfaces
{
    public interface ISolicitacaoAplicacao : IAplicacaoBase<Solicitacao>
    {
        IEnumerable<Solicitacao> BuscarPoIdUsuario(int idUsuario);
        Solicitacao MontarSolicitacao(int carteiraId, int usuarioId);
        Solicitacao BuscarPorProtocolo(string protocolo);
    }
}
