using LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutosRespositorio banco;

        public ActionResult Index()
        {
            banco = new ProdutosRespositorio();
            var produtos = banco.Produtos.Take(3);
            return View(produtos);
        }

    }
}
