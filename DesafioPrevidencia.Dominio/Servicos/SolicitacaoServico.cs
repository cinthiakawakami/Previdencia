using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Repositorios;
using DesafioPrevidencia.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioPrevidencia.Dominio.Servicos
{
    public class SolicitacaoServico : ServicoBase<Solicitacao>, ISolicitacaoServico
    {
        private readonly ISolicitacaoRepositorio _solicitacaoRepositorio;

        public SolicitacaoServico(ISolicitacaoRepositorio solicitacaoRepositorio)
            : base(solicitacaoRepositorio)
        {
            _solicitacaoRepositorio = solicitacaoRepositorio;

        }
        public IEnumerable<Solicitacao> BuscarPoIdUsuario(int idUsuario)
        {
            return _solicitacaoRepositorio.BuscarPoIdUsuario(idUsuario);
        }

        public Solicitacao MontarSolicitacao(int carteiraId, int usuarioId)
        {
            var soliciacaoDominioExistente = _solicitacaoRepositorio.BuscarPoIdUsuario(usuarioId);
            var soliciacaoDominio = new Solicitacao();
            soliciacaoDominio.UsuarioId = usuarioId;
            soliciacaoDominio.CarteiraId = carteiraId;
            //soliciacaoDominio.Carteira = _carteiraRepositorio.GetById(carteiraId);
            soliciacaoDominio.Status = "Pendente";//fazer o enum
            soliciacaoDominio.DataSolicitacao = DateTime.Now;
            soliciacaoDominio.Protocolo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + usuarioId.ToString();

            if (soliciacaoDominioExistente.Count() == 0)
                soliciacaoDominio.Tipo = "Inclusao";
            else if (soliciacaoDominioExistente.Count() == 1 && soliciacaoDominioExistente.First().Tipo == "Inclusao")
            {
                var status = soliciacaoDominioExistente.First().Status;
                if (status != "Aprovada" && status != "Concluida")
                {
                    return null;
                }
                else
                {
                    soliciacaoDominio.Tipo = "Alteracao";
                }
            }
            else
                soliciacaoDominio.Tipo = "Alteracao";

            return soliciacaoDominio;
        }
        public Solicitacao BuscarPorProtocolo(string protocolo)
        {
            return _solicitacaoRepositorio.BuscarPorProtocolo(protocolo);
        }

    }
}
