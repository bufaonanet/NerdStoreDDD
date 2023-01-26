using AutoMapper;
using NerdStoreDDD.Catalogo.Application.ViewModels;
using NerdStoreDDD.Catalogo.Domain;

namespace NerdStoreDDD.Catalogo.Application.Automapper;

public class DomainToViewModelProfile : Profile
{
    public DomainToViewModelProfile()
    {
        CreateMap<Produto, ProdutoViewModel>()
            .ForMember(d => d.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
            .ForMember(d => d.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
            .ForMember(d => d.Profundidade, o => o.MapFrom(s => s.Dimensoes.Profundidade));

        CreateMap<Categoria, CategoriaViewModel>();
    }
}