using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private ProdutosRespositorio banco;

        public ActionResult Index()
        {
             banco = new ProdutosRespositorio();

             var produtos = banco.Produtos;
            return View(produtos);
        }
        [HttpGet]
        public ViewResult Alterar(int ProdutoId)
        {
            banco = new ProdutosRespositorio();
            Produto prod = banco.Produtos.FirstOrDefault(p => p.ProdutoId == ProdutoId);
            return View(prod);
        }
        [HttpPost]
        public ActionResult Alterar(Produto produto, HttpPostedFileBase image = null)
        {
            banco = new ProdutosRespositorio();
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    produto.ImagemMimeType = image.ContentType;
                    produto.Imagem = new byte[image.ContentLength];
                    image.InputStream.Read(produto.Imagem,0,image.ContentLength);
                }
                banco.Salvar(produto);
                TempData["Menssagem"] = string.Format("{0} Foi salvo com sucesso!",produto.Nome);
               return  RedirectToAction("Index");
            }
            return View(produto);
        }
        public ViewResult NovoProduto()
        {
            TempData["Inserir"] = "Gravar Um Novo Produto";
            return View("Alterar", new Produto());
        }
        /*public ActionResult Excluir(int produtoId)
        {
            banco = new ProdutosRespositorio();
            Produto prod = banco.Excluir(produtoId);
            if (prod != null)
            {
                TempData["Menssagem"] = string.Format("{0}: Produto Exlcuido Com Sucesso!",prod.Nome);
            }
            return RedirectToAction("Index");
        }*/

        public JsonResult Excluir(int produtoId)
       {
           string Menssagem = string.Empty;
           banco = new ProdutosRespositorio();
           Produto prod = banco.Excluir(produtoId);
           if (prod != null)
           {
               Menssagem = string.Format("{0}: Produto Exlcuido Com Sucesso!", prod.Nome);
           }
           return Json(Menssagem,JsonRequestBehavior.AllowGet);
       }
        public FileContentResult ObterImagem(int produtoId)
        {
            banco = new ProdutosRespositorio();
            Produto prod = banco.Produtos.FirstOrDefault(
                p => p.ProdutoId == produtoId);
            if (prod != null)
            {
                return File(prod.Imagem, prod.ImagemMimeType);
            }
            return null;
        }
      
    }
}
