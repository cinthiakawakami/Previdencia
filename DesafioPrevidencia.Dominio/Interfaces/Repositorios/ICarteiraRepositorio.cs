using DesafioPrevidencia.Dominio.Entidades;
using System.Collections.Generic;

namespace DesafioPrevidencia.Dominio.Interfaces.Repositorios
{
    public interface ICarteiraRepositorio : IRepositorioBase<Carteira>
    {
        IEnumerable<Carteira> BuscarPorIdPerfilInvestidor(int idPerfilInvestidor, int carteiraId);
    }
}
