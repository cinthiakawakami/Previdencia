using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace DesafioPrevidencia.Data.Repositorios
{
    public class SolicitacaoRepositorio : RepositorioBase<Solicitacao>, ISolicitacaoRepositorio
    {
        public IEnumerable<Solicitacao> BuscarPoIdUsuario(int idUsuario)
        {
            return Db.Solicitacoes.Where(p => p.UsuarioId == idUsuario).ToList();
        }
        public Solicitacao BuscarPorProtocolo(string protocolo)
        {
            return Db.Solicitacoes.FirstOrDefault(f => f.Protocolo == protocolo);
        }
    }
}
