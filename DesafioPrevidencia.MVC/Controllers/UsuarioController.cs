using AutoMapper;
using DesafioPrevidencia.Aplicacao.Interfaces;
using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.MVC.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DesafioPrevidencia.MVC.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioAplicacao _usuarioApp;
        private readonly IRespostasFormularioAplicacao _respostasFormularioApp;
        private IMapper _mapper;

        public UsuarioController(IUsuarioAplicacao usuarioApp, IRespostasFormularioAplicacao respostasFormularioApp, IMapper mapper)
        {
            _usuarioApp = usuarioApp;
            _respostasFormularioApp = respostasFormularioApp;
            _mapper = mapper;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            var usuario = _usuarioApp.ObterUsuarioPeloEmail(HttpContext.User.Identity.Name);
            if (usuario.Carteira == null)
            {
                ViewBag.Carteira = "Não há carteira associada a este usuario";
            }
            var respostasFormulario = _respostasFormularioApp.BuscarPoIdUsuario(usuario.UsuarioId);
            if (respostasFormulario == null)
            {
                ViewBag.PerfilInvesidor = "Sem Perfil, favor responder o formulário";
            }
            else
                ViewBag.PerfilInvesidor = respostasFormulario.PerfilInvestidor.Nome;

            var usuarioViewModel = _mapper.Map<UsuarioModel>(usuario);
            return View(usuarioViewModel);
        }

        //Registration Action
        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            return View();
        }
        //Registration POST action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarUsuario(UsuarioModel usuarioModel)
        {
            bool status = false;
            string mensagem = "";

            if (ModelState.IsValid)
            {
                #region Verificar se email já existe
                var jahExiste = EmailExistente(usuarioModel.Email);
                if (jahExiste)
                {
                    ModelState.AddModelError("EmailExiste", "E-mail já cadastrado.");
                    return View(usuarioModel);
                }
                #endregion

                #region  Hash da senha 
                usuarioModel.Senha = Crypto.Hash(usuarioModel.Senha);
                usuarioModel.ConfirmarSenha = Crypto.Hash(usuarioModel.ConfirmarSenha);
                usuarioModel.DataCadastro = DateTime.Now;
                #endregion

                #region Salvar usuário no BD
                try
                {
                    var usuarioDominio = _mapper.Map<Usuario>(usuarioModel);
                    _usuarioApp.Add(usuarioDominio);
                    mensagem = "Usuário criado com sucesso.";
                    status = true;
                }
                catch { }

                #endregion
            }
            else
            {
                mensagem = "Requisição Inválida.";
            }

            ViewBag.Message = mensagem;
            ViewBag.Status = status;
            return View(usuarioModel);
        }

        //Login 
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = string.Empty;
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioLoginModel login, string ReturnUrl = "")
        {
            string mensagem = "";
            var v = _usuarioApp.ObterUsuarioPeloEmail(login.Email);
            if (v != null)
            {

                if (string.Compare(Crypto.Hash(login.Senha), v.Senha) == 0)
                {
                    int timeout = login.ManterConectado ? 525600 : 20; // 525600 min = 1 year
                    var ticket = new FormsAuthenticationTicket(login.Email, login.ManterConectado, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);


                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    mensagem = "Credenciais inválidas.";
                }
            }
            else
            {
                mensagem = "Credenciais inválidas.";
            }

            ViewBag.Message = mensagem;
            return View();
        }

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [NonAction]
        public bool EmailExistente(string email)
        {
            var v = _usuarioApp.ObterUsuarioPeloEmail(email);
            return v != null;
        }

    }
}
