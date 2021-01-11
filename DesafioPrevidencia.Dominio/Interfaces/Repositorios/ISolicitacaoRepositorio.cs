using DesafioPrevidencia.Dominio.Entidades;
using System.Collections.Generic;

namespace DesafioPrevidencia.Dominio.Interfaces.Repositorios
{
    public interface ISolicitacaoRepositorio : IRepositorioBase<Solicitacao>
    {
        IEnumerable<Solicitacao> BuscarPoIdUsuario(int idUsuario);
        Solicitacao BuscarPorProtocolo(string protocolo);
    }
}
