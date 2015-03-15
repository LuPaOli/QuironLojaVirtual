using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.HtmlHelpers
{
    public static class PaginacaoHelpers
    {
        //Criação de um método Estático
        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {
            //Cosntrutora de string para HTML
            StringBuilder resultado = new StringBuilder();

            //Para cada página da paginação, faça
            for (int i = 1; i < paginacao.TotalPagina; i++)
            {
                //Construtora de TAG começa com um 'a' para os links automáticos
                TagBuilder tag = new TagBuilder("a");
                //Mescla na construtora de TAG os atributos 'HREF' e em seguida a página em questão
                tag.MergeAttribute("href", paginaUrl(i));
                //insere a referência qual a página em que está a navegação
                tag.InnerHtml = i.ToString();
                //Caso a página em que o usuário esteja é a selecionada, o botão da página fica destacado
                if (i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                //Concatena toda a TAG
                resultado.Append(tag);               
            }
            return MvcHtmlString.Create(resultado.ToString());

        }
    }
}