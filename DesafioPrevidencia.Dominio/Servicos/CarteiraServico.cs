using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Repositorios;
using DesafioPrevidencia.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace DesafioPrevidencia.Dominio.Servicos
{
    public class CarteiraServico : ServicoBase<Carteira>, ICarteiraServico
    {
        private readonly ICarteiraRepositorio _carteiraRepositorio;
        private readonly IRespostasFormularioRepositorio _respostasFormularioRepositorio;

        public CarteiraServico(ICarteiraRepositorio carteiraRepositorio, IRespostasFormularioRepositorio respostasFormularioRepositorio)
            : base(carteiraRepositorio)
        {
            _carteiraRepositorio = carteiraRepositorio;
            _respostasFormularioRepositorio = respostasFormularioRepositorio;
        }

        public IEnumerable<Carteira> BuscarPorIdPerfilInvestidor(int idPerfilInvestidor, int carteiraId)
        {
            return _carteiraRepositorio.BuscarPorIdPerfilInvestidor(idPerfilInvestidor, carteiraId);
        }

        public IEnumerable<Carteira> BuscarPorIdUsuario(int idUsuario, int carteiraId)
        {
            var usuario = _respostasFormularioRepositorio.BuscarPoIdUsuario(idUsuario);
            return _carteiraRepositorio.BuscarPorIdPerfilInvestidor(usuario.PerfilInvestidorId, carteiraId);
        }

        public IEnumerable<Carteira> BuscarPorUsuario(Usuario usuario, int carteiraId)
        {
            var respostasUsuario = _respostasFormularioRepositorio.BuscarPoIdUsuario(usuario.UsuarioId);
            if (respostasUsuario != null)
            {
                //if (carteiraId > 0)
                //{
                //    var carteiraAtual = _carteiraServico.GetById(carteiraId);
                IEnumerable<Carteira> listaCarteiras = _carteiraRepositorio.BuscarPorIdPerfilInvestidor(respostasUsuario.PerfilInvestidorId, carteiraId);
                return _carteiraRepositorio.BuscarPorIdPerfilInvestidor(respostasUsuario.PerfilInvestidorId, carteiraId);
                //}
            }
            else
                return null;
        }
    }

}
