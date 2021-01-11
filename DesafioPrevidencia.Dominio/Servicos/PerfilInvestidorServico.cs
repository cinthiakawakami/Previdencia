using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Repositorios;
using DesafioPrevidencia.Dominio.Interfaces.Servicos;

namespace DesafioPrevidencia.Dominio.Servicos
{
    public class PerfilInvestidorServico : ServicoBase<PerfilInvestidor>, IPerfilInvestidorServico
    {
        private readonly IPerfilInvestidorRepositorio _perfilInvestidorRepositorio;

        public PerfilInvestidorServico(IPerfilInvestidorRepositorio perfilInvestidorRepositorio)
            : base(perfilInvestidorRepositorio)
        {
            _perfilInvestidorRepositorio = perfilInvestidorRepositorio;
        }

    }
}
