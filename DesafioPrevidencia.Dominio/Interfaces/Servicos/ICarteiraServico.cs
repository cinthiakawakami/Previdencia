using DesafioPrevidencia.Dominio.Entidades;
using System.Collections.Generic;

namespace DesafioPrevidencia.Dominio.Interfaces.Servicos
{
    public interface ICarteiraServico : IServicoBase<Carteira>
    {
        IEnumerable<Carteira> BuscarPorIdPerfilInvestidor(int idPerfilInvestidor, int carteiraId);
        IEnumerable<Carteira> BuscarPorIdUsuario(int idUsuario, int carteiraId);
        IEnumerable<Carteira> BuscarPorUsuario(Usuario usuario, int carteiraId);
    }
}
