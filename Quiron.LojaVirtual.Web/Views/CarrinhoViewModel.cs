using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.Views
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }

        public string ReturnUrl { get; set; }
    }
}