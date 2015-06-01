using LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private ProdutosRespositorio banco;
       

        public PartialViewResult Menu(string categoria = null)
        {
            ViewBag.CategoriaSelecionada = categoria;
            banco = new ProdutosRespositorio();
            IEnumerable<string> categorias = banco.Produtos.Select(c => c.Categoria).Distinct().OrderBy(c => c);
            return PartialView(categorias);
        }

    }
}
