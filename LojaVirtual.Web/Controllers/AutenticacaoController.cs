using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepositorio context;

        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View(new Administrador());
        }
        [HttpPost]
        public ActionResult Login(Administrador admin, string ReturnUrl)
        {
            context = new AdministradoresRepositorio();
            Administrador administrador;
            if (ModelState.IsValid)
            {
                if ((administrador = context.getAdmin(admin)) != null)
                {
                    if (!Equals(admin.Senha,administrador.Senha))
                    {
                         ModelState.AddModelError("erroSenha", "Senha Incorreta");
                        
                    }
                    else
                    {                       
                        FormsAuthentication.SetAuthCookie(admin.Login,false);
                        if (Url.IsLocalUrl(ReturnUrl)
                            && ReturnUrl.Length > 1
                            && ReturnUrl.StartsWith("/")
                            && !ReturnUrl.StartsWith("//")
                            && !ReturnUrl.StartsWith("/\\"))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Produto", new {area = "Administrativo" });
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("erroLogin", "Login: " + admin.Login + " Não Localizado");

                }
            }
            return View(new Administrador());

        }

    }
}
