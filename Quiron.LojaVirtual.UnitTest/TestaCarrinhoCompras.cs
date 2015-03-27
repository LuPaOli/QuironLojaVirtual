using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TestaCarrinhoCompras
    {
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            //Arrange - Iniciar o teste populando variaveis iniciais
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            //Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1,3);
            carrinho.AdicionarItem(produto2,2);
            //Act
            ItemCarrinho[] itens = carrinho.itensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(itens.Length,2);
            Assert.AreEqual(itens[0].Produto.ProdutoId,1);
            Assert.AreEqual(itens[1].Produto.ProdutoId,2);
            
        }
    }
}
