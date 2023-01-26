﻿using Microsoft.AspNetCore.Mvc;
using NerdStoreDDD.Catalogo.Application.Services;

namespace NerdStoreDDD.WebApp.MVC.Controllers.Admin;

public class VitrineController : Controller
{
    private readonly IProdutoAppService _produtoAppService;

    public VitrineController(IProdutoAppService produtoAppService)
    {
        _produtoAppService = produtoAppService;
    }

    [HttpGet]
    [Route("")]
    [Route("vitrine")]
    public async Task<IActionResult> Index()
    {
        return View(await _produtoAppService.ObterTodos());
    }

    [HttpGet]
    [Route("produto-detalhe/{id}")]
    public async Task<IActionResult> ProdutoDetalhe(Guid id)
    {
        return View(await _produtoAppService.ObterPorId(id));
    }
}
