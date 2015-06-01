using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaVirtual.Dominio.Entidades;
namespace LojaVirtual.Web.Models
{
    public class ProdutosViewModel
    {
        private IEnumerable<Produto> produtos;

        public IEnumerable<Produto> Produtos
        {
            get { return produtos; }
            set { produtos = value; }
        }
        private Paginacao paginacao;

        public Paginacao Paginacao
        {
            get { return paginacao; }
            set { paginacao = value; }
        }
        private string categoriaAtual;

        public string CategoriaAtual
        {
            get { return categoriaAtual; }
            set { categoriaAtual = value; }
        }
        
        
    }
}