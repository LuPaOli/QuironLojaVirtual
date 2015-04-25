using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.Infraestrutura
{
    public class CarrinhoModelBinder:IModelBinder
    {
        private const string SessionKey = "Carrinho";

        //IModelBinder define o metodo BindModel

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //Obter carrinho da Sessão
            Carrinho carrinho = null;

            if (controllerContext.HttpContext.Session != null)
            {
                carrinho = (Carrinho) controllerContext.HttpContext.Session[SessionKey];
            }

            //Criar o carrinho caso não tenha sessão

            if (carrinho == null)
            {
                carrinho = new Carrinho();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
            }

            //retornr carrinho

            return carrinho;

        }
    }
}