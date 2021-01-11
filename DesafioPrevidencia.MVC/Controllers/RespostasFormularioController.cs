using AutoMapper;
using DesafioPrevidencia.Aplicacao.Interfaces;
using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.MVC.Models;
using System;
using System.Web.Mvc;

namespace DesafioPrevidencia.MVC.Controllers
{
    public class RespostasFormularioController : Controller
    {
        private readonly IRespostasFormularioAplicacao _respostasFormularioApp;
        private readonly IUsuarioAplicacao _usuarioApp;
        private IMapper _mapper;

        public RespostasFormularioController(IRespostasFormularioAplicacao respostasFormularioApp, IUsuarioAplicacao usuarioApp, IMapper mapper)
        {
            _respostasFormularioApp = respostasFormularioApp;
            _usuarioApp = usuarioApp;
            _mapper = mapper;
        }

        // GET: RespostasForumlario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RespostasForumlario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RespostasFormularioModel respostasFormularioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!UsuarioJaRespondeu())
                    {
                        var respostasDominio = _mapper.Map<RespostasFormulario>(respostasFormularioModel);
                        respostasDominio.UsuarioId = _usuarioApp.ObterUsuarioPeloEmail(HttpContext.User.Identity.Name).UsuarioId;

                        _respostasFormularioApp.Add(_respostasFormularioApp.MontarPerfilRespostasFormulario(respostasDominio));
                    }
                }

                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: RespostasForumlario/Edit/5
        public ActionResult Edit()
        {
            var emailUsuario = HttpContext.User.Identity.Name;
            if (!string.IsNullOrEmpty(emailUsuario))
            {
                var respostasFormulario = _respostasFormularioApp.BuscarPoIdUsuario(_usuarioApp.ObterUsuarioPeloEmail(emailUsuario).UsuarioId);

                if (respostasFormulario != null)
                {
                    return View(_mapper.Map<RespostasFormularioModel>(respostasFormulario));
                }
                else
                {
                    return RedirectToAction("Create");
                }
            }
            else
            {
                return View();
            }

        }

        // POST: RespostasForumlario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RespostasFormularioModel respostasFormularioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var respostasDominio = _mapper.Map<RespostasFormulario>(respostasFormularioModel);
                    _respostasFormularioApp.Update(_respostasFormularioApp.MontarPerfilRespostasFormulario(respostasDominio));
                }
                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public bool UsuarioJaRespondeu()
        {
            return _respostasFormularioApp.BuscarPoIdUsuario(_usuarioApp.ObterUsuarioPeloEmail(HttpContext.User.Identity.Name).UsuarioId) != null ? true : false;
        }
    }
}
