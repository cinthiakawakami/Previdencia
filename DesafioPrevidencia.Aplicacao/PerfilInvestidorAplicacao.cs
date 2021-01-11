using DesafioPrevidencia.Aplicacao.Interfaces;
using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Servicos;

namespace DesafioPrevidencia.Aplicacao
{
    public class PerfilInvestidorAplicacao : AplicacaoBase<PerfilInvestidor>, IPerfilInvestidorAplicacao
    {
        private readonly IPerfilInvestidorServico _perfilInvestidorServico;

        public PerfilInvestidorAplicacao(IPerfilInvestidorServico perfilInvestidorServico)
            : base(perfilInvestidorServico)
        {
            _perfilInvestidorServico = perfilInvestidorServico;
        }
    }
}
