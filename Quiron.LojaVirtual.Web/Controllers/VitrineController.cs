using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        
        private ProdutosRepositorio _repositorio;
        public int produtosPorPagina = 5;

        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            //Populando a estrutura ProdutosViewModel
            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = _repositorio.Produtos //Recupera todos os produtos
                .Where(p => categoria == null || p.Categoria == categoria)    //Filtro por Categoria
                    .OrderBy(p => p.Descricao) //Ordenação por Descrição
                    .Skip((pagina - 1)*produtosPorPagina) //Inibe os registros iniciais conforme pagina
                    .Take(produtosPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = produtosPorPagina,
                    ItensTotal = categoria == null ? _repositorio.Produtos.Count() : _repositorio.Produtos.Count() / produtosPorPagina
                }

                ,

                CategoriaAtual = categoria
                
            };
            return View(model);
        }
    }
}