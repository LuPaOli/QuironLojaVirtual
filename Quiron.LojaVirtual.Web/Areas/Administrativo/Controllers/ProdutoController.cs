﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        public ActionResult Index()
        {
            _repositorio = new ProdutosRepositorio();
            var produtos = _repositorio.Produtos;
            return View(produtos);
        }


        public ViewResult Alterar(int produtoid)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoid);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            //Verifica se todas as validações realizadas no modelo de dados são válidas para salvar o produto
            if (ModelState.IsValid)
            {
                _repositorio = new ProdutosRepositorio();
                _repositorio.Salvar(produto);
                TempData["Mensagem"] = string.Format("{0} foi salvo com sucesso!", produto.Nome);
                return RedirectToAction("Index");

            }

            return View(produto);
        }
    }
}