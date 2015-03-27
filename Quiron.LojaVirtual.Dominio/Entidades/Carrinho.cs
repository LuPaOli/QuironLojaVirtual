using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        public readonly List<ItemCarrinho> itensCarrinho = new List<ItemCarrinho>(); 

        //Adicionar Item no Carrinho
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = itensCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);//Pode ter ou não um item de carrinho;
            if (item == null)
            {
                itensCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }

        //Remover item do Carrinho
        public void RemoverItem(Produto produto)
        {
            itensCarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        }

        //Obter o valor total
        public decimal ValorTotal()
        {
            return itensCarrinho.Sum(l => l.Produto.Preco*l.Quantidade);
        }

        //Limpar carrinho
        public void LimparCarrinho()
        {
            itensCarrinho.Clear();
        }

        //Itens do Carrinho
        public IEnumerable<ItemCarrinho> RetornaItensCarrinho
        {
            get { return itensCarrinho; }
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
