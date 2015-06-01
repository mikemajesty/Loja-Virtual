using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Dominio.Repositorio;
using LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRespositorio banco;

        public RedirectToRouteResult Adicionar(Carrinho carrinho,int produtoId,string returnUrl)
        {

            banco = new ProdutosRespositorio();

            Produto produto = banco.Produtos.FirstOrDefault(p=>p.ProdutoId == produtoId);
            if (produto != null)
            {
                ObterCarrinho().AdicionarItem(produto,1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho)Session["Carrinho"];
            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }
            return carrinho;
        }
        public RedirectToRouteResult Remover(Carrinho carrinho,int produtoId,string returnUrl)
        {
            banco = new ProdutosRespositorio();
            Produto produto = banco.Produtos.FirstOrDefault(p=>p.ProdutoId == produtoId);
            if (produtoId != 0)
            {
                ObterCarrinho().RemevorItem(produto);
            }
            return RedirectToAction("Index", new  {returnUrl });
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                 Carrinho = ObterCarrinho(),
                 ReturnUrl = returnUrl

            });
        }

        public PartialViewResult Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
   
        }
        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }
        [HttpPost]
        public ViewResult FecharPedido(Pedido pedido)
        {
            Carrinho carrinho = ObterCarrinho();
            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = true/*bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")*/
            };
            EmailPedido emailPedido = new EmailPedido(email);

            if (! carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError( "erroModel","Não foi possivel concluir o pedido, seu carrinho esta vazio!");
            }
            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }
        }
        public ViewResult PedidoConcluido()
        {
            return View();
        }
    }
}
