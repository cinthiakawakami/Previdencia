using DesafioPrevidencia.Dominio.Entidades;
using System.Collections.Generic;

namespace DesafioPrevidencia.Dominio.Interfaces.Servicos
{
    public interface ISolicitacaoServico : IServicoBase<Solicitacao>
    {
        IEnumerable<Solicitacao> BuscarPoIdUsuario(int idUsuario);
        Solicitacao MontarSolicitacao(int carteiraId, int usuarioId);
        Solicitacao BuscarPorProtocolo(string protocolo);
    }
}
