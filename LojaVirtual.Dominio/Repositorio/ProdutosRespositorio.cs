using LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRespositorio
    {
        private readonly EfDbContext Context = new EfDbContext();
        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        public IEnumerable<Produto> Produtos
        {
            get { return Context.Produtos; }
        }
 
        public int Salvar(Produto produto)
        {
            if (produto.ProdutoId != 0)
            {
                Produto prod = Context.Produtos.Find(produto.ProdutoId);
                if (prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Preco = produto.Preco;
                    prod.Descricao = produto.Descricao;
                    prod.Categoria = produto.Categoria;
                    prod.Imagem = produto.Imagem;
                    prod.ImagemMimeType = produto.ImagemMimeType;
                }
            }
            else 
            {
                Context.Produtos.Add(produto);
            }

            return Context.SaveChanges();
        }
        public Produto Excluir(int ProdutoId)
        {
            Produto prod = Context.Produtos.Find(ProdutoId);
            if (prod != null)
            {
                Context.Produtos.Remove(prod);
                //Context.SaveChanges();
            }
            return prod;
        }

    }
}
