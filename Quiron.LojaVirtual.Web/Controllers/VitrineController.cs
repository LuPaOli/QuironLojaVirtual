using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        
        private ProdutosRepositorio _repositorio;
        public int produtosPorPagina = 8;

        public ViewResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = _repositorio.Produtos //Recupera todos os produtos
                    .OrderBy(p => p.Descricao) //Ordenação por Descrição
                    .Skip((pagina - 1)*produtosPorPagina) //Inibe os registros iniciais conforme pagina
                    .Take(produtosPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = produtosPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()
                }
                
            };
            return View(model);
        }
    }
}