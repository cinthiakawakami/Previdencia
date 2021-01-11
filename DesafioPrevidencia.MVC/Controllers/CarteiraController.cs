using AutoMapper;
using DesafioPrevidencia.Aplicacao.Interfaces;
using DesafioPrevidencia.MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DesafioPrevidencia.MVC.Controllers
{
    public class CarteiraController : Controller
    {
        private readonly ICarteiraAplicacao _carteiraApp;
        private readonly IUsuarioAplicacao _usuarioApp;
        private readonly IRespostasFormularioAplicacao _respostasFormularioApp;
        private IMapper _mapper;

        public CarteiraController(ICarteiraAplicacao carteiraApp, IUsuarioAplicacao usuarioApp, IRespostasFormularioAplicacao respostasFormularioApp, IMapper mapper)
        {
            _carteiraApp = carteiraApp;
            _usuarioApp = usuarioApp;
            _respostasFormularioApp = respostasFormularioApp;
            _mapper = mapper;
        }

        // GET: Carteira
        public ActionResult Index()
        {
            var usuario = _usuarioApp.ObterUsuarioPeloEmail(HttpContext.User.Identity.Name);
            if (usuario != null)
            {
                ViewBag.Logado = "S";
                if (usuario.Carteira != null)
                {
                    var carteiraModel = _mapper.Map<CarteiraModel>(usuario.Carteira);
                    return View(carteiraModel);
                }
                else
                {
                    var carteiraModel = new CarteiraModel();
                    ViewBag.Mensagem = "Você não possui nenhuma carteira selecionada";
                    var respostasFormulariodom = _respostasFormularioApp.BuscarPoIdUsuario(usuario.UsuarioId);
                    if (respostasFormulariodom != null)
                        ViewBag.Formulario = "Respondido";
                    else
                        ViewBag.Formulario = "Não respondido";
                    return View(carteiraModel);
                }
            }
            else
            {
                ViewBag.Mensagem = "Você precisa estar logado para ver esta opção.";
                ViewBag.Logado = "N";
                return View(new CarteiraModel());
            }
        }

        public ActionResult Escolher(int CarteiraId)
        {
            var usuario = _usuarioApp.ObterUsuarioPeloEmail(HttpContext.User.Identity.Name);
            var carteiraDominio = _carteiraApp.BuscarPorUsuario(usuario, CarteiraId);
            if (carteiraDominio != null)
            {
                var carteiraModel = _mapper.Map<IEnumerable<CarteiraModel>>(carteiraDominio);
                return View(carteiraModel);
            }
            else
            {
                var carteiraModel = _mapper.Map<IEnumerable<CarteiraModel>>(_carteiraApp.GetAll());
                ViewBag.Message = "Erro";
                return View(carteiraModel);
            }
        }

    }
}
