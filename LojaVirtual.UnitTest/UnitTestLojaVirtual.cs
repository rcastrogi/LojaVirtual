using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Mvc;
using LojaVirtual.Web.Models;
using LojaVirtual.Web.HtmlHelpers;
using LojaVirtual.Dominio.Entidades;

namespace LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestLojaVirtual
    {
        [TestMethod]
        public void Take()
        {
            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var resultado = from num in numeros.Take(5) select num;

            int[] teste = { 5, 4, 1, 3, 9 };

            CollectionAssert.AreEqual(resultado.ToArray(), teste);


        }


        [TestMethod]
        public void Skip()
        {

            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var resultado = from num in numeros.Take(5).Skip(2) select num;

            int[] teste = { 1, 3, 9 };

            CollectionAssert.AreEqual(resultado.ToArray(), teste);


        }

        [TestMethod]
        public void TestarSePaginacaofunciona()
        {
            //Arrange
            HtmlHelper html = null;

            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //Assert
            Assert.AreEqual(

                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
                );
        }

        [TestMethod]
        public void TestarInclusaoProduto()
        {

            //Arrange
            Produto produto = new Produto
            {
                ProdutoId = 1,
                Nome = "Bola",
                Categoria = "Futebol",
                Preco = (decimal)14.5,
                Descricao = "Bola de couro para se jogar futebol."
            };


            //Act
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto, 1);

            ItemCarrinho[] item = carrinho.ListaCarrinho.ToArray();

            //Assert
            Assert.AreEqual(item.Length,1);
            Assert.AreEqual(item[0].Produto, produto);
        }

        [TestMethod]
        public void TestarAdicaoMesmoProduto()
        {
            //Arrange
            Produto produto = new Produto
            {
                ProdutoId = 1,
                Nome = "Bola",
                Categoria = "Futebol",
                Preco = (decimal)14.5,
                Descricao = "Bola de couro para se jogar futebol."
            };


            //Act
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto, 1);
            carrinho.AdicionarItem(produto, 1);

            //Assert
            var resultado = carrinho.ListaCarrinho;
            Assert.AreEqual(resultado.FirstOrDefault().Quantidade, 2);
        }



    }


}
