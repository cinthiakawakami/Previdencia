using AutoMapper;
using DesafioPrevidencia.Aplicacao.Interfaces;
using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.MVC.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DesafioPrevidencia.MVC.Controllers
{
    public class SolicitacaoController : Controller
    {
        private readonly ISolicitacaoAplicacao _solicitacaoApp;
        private readonly ICarteiraAplicacao _carteiraApp;
        private readonly IUsuarioAplicacao _usuarioApp;
        private IMapper _mapper;

        public SolicitacaoController(ISolicitacaoAplicacao solicitacaoApp, ICarteiraAplicacao carteiraApp, IUsuarioAplicacao usuarioApp, IMapper mapper)
        {
            _solicitacaoApp = solicitacaoApp;
            _carteiraApp = carteiraApp;
            _usuarioApp = usuarioApp;
            _mapper = mapper;
        }

        // GET: Solicitacao
        public ActionResult Index()
        {
            var emailUsuario = HttpContext.User.Identity.Name;
            if (!string.IsNullOrEmpty(emailUsuario))
            {
                var solicitacaoDominio = _solicitacaoApp.BuscarPoIdUsuario(_usuarioApp.ObterUsuarioPeloEmail(emailUsuario).UsuarioId);
                return View(_mapper.Map<IEnumerable<SolicitacaoModel>>(solicitacaoDominio));
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Protocolo)
        {
            return RedirectToAction("ResultadoPesquisa", new { Protocolo });
        }

        // GET: Carteira/Details/5
        public ActionResult Escolher()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Escolher(int Selecionada)
        {
            try
            {
                var usuario = _usuarioApp.ObterUsuarioPeloEmail(HttpContext.User.Identity.Name);
                var solicitacaoDominio = _solicitacaoApp.MontarSolicitacao(Selecionada, usuario.UsuarioId);
                if (solicitacaoDominio != null)
                {
                    _solicitacaoApp.Add(solicitacaoDominio);
                    return View(_mapper.Map<SolicitacaoModel>(solicitacaoDominio));
                }
                else
                {
                    ViewBag.Pendente = "Há uma solicitação ainda em aberto, não é possível realizar outra.";
                    return View();
                }

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult ResultadoPesquisa()
        {
            return View(new List<SolicitacaoModel>());
        }

        // GET: Solicitacao/Create
        public ActionResult Pesquisa()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResultadoPesquisa(string Protocolo)
        {
            var solicitacaoDominio = _solicitacaoApp.BuscarPorProtocolo(Protocolo);
            if (solicitacaoDominio != null)
                return RedirectToAction("Resultado", new { solicitacaoDominio.SolicitacaoId });
            else
                return View();
        }

        public ActionResult Resultado(int solicitacaoId)
        {

            if (solicitacaoId == 0)
            {
                var solicitacaoDominio = _solicitacaoApp.BuscarPoIdUsuario(_usuarioApp.ObterUsuarioPeloEmail(HttpContext.User.Identity.Name).UsuarioId);
                return View(_mapper.Map<IEnumerable<SolicitacaoModel>>(solicitacaoDominio));
            }
            else
            {
                List<Solicitacao> resultado = new List<Solicitacao>();
                resultado.Add(_solicitacaoApp.GetById(solicitacaoId));
                return View("ResultadoPesquisa", _mapper.Map<IEnumerable<SolicitacaoModel>>(resultado));
            }

        }

    }
}
