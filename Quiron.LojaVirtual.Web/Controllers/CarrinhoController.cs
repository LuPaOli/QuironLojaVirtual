using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Views;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {

        private ProdutosRepositorio _repositorio;

        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            //Criação do repositório de dados
            _repositorio = new ProdutosRepositorio();

            //Recupera primeiro produto do repositório e verifica se ele existe...
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            //Verifica se o produto a ser verificado não é nulo...
            if (produto != null)
            {
                ObterCarrinho().AdicionarItem(produto,1);
            }
            return RedirectToAction("Index", new {returnUrl});

        }

        private Carrinho ObterCarrinho()
        {
            //A classe de obter carrinhos é uma sessão, onde se armazenará os itens dos carrinhos...
            Carrinho carrinho = (Carrinho) Session["Carrinho"];

            if (carrinho != null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }

            return carrinho;
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            //Criação do repositório de dados
            _repositorio = new ProdutosRepositorio();

            //Recupera primeiro produto do repositório e verifica se ele existe...
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            //Verifica se o produto a ser verificado não é nulo...
            if (produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }
            return RedirectToAction("Index", new { returnUrl });

        }

        public ViewResult Index(string returnurl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnurl
            });
        }
    }
}