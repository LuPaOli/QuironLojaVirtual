using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int produtosPorPagina = 3;

        public ActionResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();
            var produtos = _repositorio.Produtos //Recupera todos os produtos
                .OrderBy(p => p.Descricao) //Ordenação por Descrição
                .Skip((pagina - 1) * produtosPorPagina)//Inibe os registros iniciais conforme pagina
                .Take(produtosPorPagina);
            return View(produtos);
        }
	}
}