using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {

        private readonly List<ItemCarrinho> _itensCarrinho = new List<ItemCarrinho>();
        //Adicionar
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itensCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                _itensCarrinho.Add(new ItemCarrinho
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
        //remover
        public void RemoverItem(Produto produto)
        {
            _itensCarrinho.RemoveAll(p => p.Produto.ProdutoId == produto.ProdutoId);
        }

        //Ober valor Total
        public decimal ObterValorTotal()
        {
            return _itensCarrinho.Sum(p => p.Produto.Preco * p.Quantidade);
        }

        //Limpar
        public void LimparCarrinho()
        {
            _itensCarrinho.Clear();

        }

        //Itens
        public IEnumerable<ItemCarrinho> ListaCarrinho
        {
            get { return _itensCarrinho; }
        }


    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
