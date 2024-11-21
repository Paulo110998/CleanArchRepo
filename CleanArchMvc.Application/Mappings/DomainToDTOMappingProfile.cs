using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}


/*
 
O método ReverseMap() no AutoMapper cria um mapeamento bidirecional 
entre duas classes. No exemplo, ele permite converter de Category para 
CategoryDTO e vice-versa, sem precisar definir dois mapeamentos separados.
Isso facilita a leitura e escrita de dados ao trabalhar com entidades e seus 
respectivos DTOs, simplificando o código e garantindo consistência nos mapeamentos.

*/