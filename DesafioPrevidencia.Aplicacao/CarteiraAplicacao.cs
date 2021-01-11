using DesafioPrevidencia.Aplicacao.Interfaces;
using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace DesafioPrevidencia.Aplicacao
{
    public class CarteiraAplicacao : AplicacaoBase<Carteira>, ICarteiraAplicacao
    {
        private readonly ICarteiraServico _carteiraServico;        

        public CarteiraAplicacao(ICarteiraServico carteiraServico)
            : base(carteiraServico)
        {
            _carteiraServico = carteiraServico;            
        }

        public IEnumerable<Carteira> BuscarPorIdPerfilInvestidor(int idPerfilInvestidor, int carteiraId)
        {
            return _carteiraServico.BuscarPorIdPerfilInvestidor(idPerfilInvestidor, carteiraId);
        }

        public IEnumerable<Carteira> BuscarPorUsuario(Usuario usuario, int carteiraId)
        {
            return _carteiraServico.BuscarPorUsuario(usuario, carteiraId);
        }

    }
}
