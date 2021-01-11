using DesafioPrevidencia.Dominio.Entidades;
using System.Collections.Generic;

namespace DesafioPrevidencia.Aplicacao.Interfaces
{
    public interface ICarteiraAplicacao : IAplicacaoBase<Carteira>
    {
        IEnumerable<Carteira> BuscarPorIdPerfilInvestidor(int idPerfilInvestidor, int carteiraId);
        IEnumerable<Carteira> BuscarPorUsuario(Usuario usuario, int carteiraId);
    }
}
