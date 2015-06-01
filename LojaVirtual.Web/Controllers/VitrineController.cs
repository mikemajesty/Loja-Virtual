using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Dominio.Repositorio;
using LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {


        ProdutosRespositorio banco = null;
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
          
            int ProdutosPorPagina = 3;
            banco = new ProdutosRespositorio();

            ProdutosViewModel model = new ProdutosViewModel
            {

                Produtos = banco.Produtos
                    .Where(p => categoria == null || p.Categoria == categoria)
                    .OrderBy(p => p.Descricao)
                    .Skip((pagina - 1) * ProdutosPorPagina)
                    .Take(ProdutosPorPagina),



                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItemsPorPagina = ProdutosPorPagina,
                    ItemsTotal = categoria == null ? banco.Produtos.Count() : banco.Produtos.Count(e => e.Categoria == categoria)
                },

                CategoriaAtual = categoria
            };


            return View(model);
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
