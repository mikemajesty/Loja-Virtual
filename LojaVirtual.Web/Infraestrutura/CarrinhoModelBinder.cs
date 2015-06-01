using LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace LojaVirtual.Web.Infraestrutura
{
    public class CarrinhoModelBinder : System.Web.Mvc.IModelBinder
    {
        private const string SessionKey = "Carrinho";
        //ImodelBinder interface define o metodo bindmodel

        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {

            Carrinho carrinho = null;

            if (controllerContext.HttpContext.Session != null)
            {
                carrinho = (Carrinho)controllerContext.HttpContext.Session[SessionKey];
            }
            //crio o carrinho se não tenho a sessão
            if (carrinho == null)
            {
                carrinho = new Carrinho();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
            }
            return carrinho;
        }
    }
}