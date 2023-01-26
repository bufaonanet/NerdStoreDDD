using NerdStoreDDD.Catalogo.Application.Services;
using NerdStoreDDD.Catalogo.Data.Repositories;
using NerdStoreDDD.Catalogo.Data;
using NerdStoreDDD.Catalogo.Domain;
using NerdStoreDDD.Core.Bus;
using MediatR;
using NerdStoreDDD.Catalogo.Domain.Events;

namespace NerdStoreDDD.WebApp.MVC.Setup;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Mediator
        services.AddScoped<IMediatrHandler, MediatrHandler>();

        // Catalogo
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoAppService, ProdutoAppService>();
        services.AddScoped<IEstoqueService, EstoqueService>();
        
        services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
    }
}
