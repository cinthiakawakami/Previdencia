using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace DesafioPrevidencia.Data.Repositorios
{
    public class CarteiraRepositorio : RepositorioBase<Carteira>, ICarteiraRepositorio
    {
        public IEnumerable<Carteira> BuscarPorIdPerfilInvestidor(int idPerfilInvestidor, int carteiraId)
        {
            return Db.Carteiras.Where(p => p.PerfilInvestidorId == idPerfilInvestidor).Where(t => t.CarteiraId != carteiraId).ToList();
        }
    }
}
