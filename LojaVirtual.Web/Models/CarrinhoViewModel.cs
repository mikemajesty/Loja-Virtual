using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaVirtual.Dominio.Entidades;
namespace LojaVirtual.Web.Models
{
    public class CarrinhoViewModel
    {
        private Carrinho carrinho;

        public Carrinho Carrinho
        {
            get { return carrinho; }
            set { carrinho = value; }
        }
        private string returnUrl;

	    public string ReturnUrl
	    {
		    get { return returnUrl;}
		    set { returnUrl = value;}
	    }
	
    }
}