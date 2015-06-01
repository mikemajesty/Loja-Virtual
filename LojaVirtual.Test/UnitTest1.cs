using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using LojaVirtual.Web.Models;
using System.Web.Mvc;
using LojaVirtual.Web.HtmlHelpers;
using LojaVirtual.Web.Controllers;
namespace LojaVirtual.Test
{
    [TestClass]
    public class UnitTestLojaVirtual
    {
        [TestMethod]
        public void TestarPaginacaoComRetorno()
        {
            VitrineController c = new VitrineController();
            //c.ListaProdutos();
        }



        [TestMethod]
        public void Take()
        {
            int[] numeros = {5,4,1,3,9,8,6,7,2,0};
            var resultado = from num in numeros.Take(5) select num;
            int[] teste = {5,4,1,3,9 };
            CollectionAssert.AreEqual(resultado.ToArray(),teste);
        }
        [TestMethod]
        public void Skip()
        {
            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var resultado = from num in numeros.Take(5).Skip(2) select num;
            int[] teste = { 1, 3, 9 };
            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }
         [TestMethod]
        public void TestarSePaginacaoEstaFuncionando()
        {
            HtmlHelper html = null;
            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItemsPorPagina = 10,
                ItemsTotal = 28
            };
            Func<int, string> paginaUrl = i => "Pagina" + i;
            //Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);
            //Assert
            Assert.AreEqual(

                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()

                );
        }
    }
}
