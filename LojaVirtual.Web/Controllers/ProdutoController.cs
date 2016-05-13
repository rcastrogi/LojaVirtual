using LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class ProdutoController : Controller
    {

        private ProdutoRepositorio _repositorio;
        // GET: Produto
        public ActionResult Index()
        {
            _repositorio = new ProdutoRepositorio();
            var produtos = _repositorio.Produto.Take(10);
            return View(produtos);
        }
    }
}