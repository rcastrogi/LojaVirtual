using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Dominio.Repositorio;
using LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {

        private ProdutoRepositorio _repositorio;
        public int ProdutosPorPagina = 8; 


        // GET: Vitrine
        public ViewResult ListaProdutos(int pagina = 1)
        {

            _repositorio = new ProdutoRepositorio();

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = _repositorio.Produto
                .OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _repositorio.Produto.Count()
                }
            };

            return View(model);
        }
    }
}