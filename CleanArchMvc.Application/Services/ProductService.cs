using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ProductService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        //  Criando objeto
        var productsQuery = new GetProductsQuery();
        
        // Verificando se o objeto é válido
        if (productsQuery == null)
            throw new Exception($"Entity could not be loaded.");

        // Define o resultado e envia o resultado
        var result = await _mediator.Send(productsQuery);
        
        //  Mapeando o Dto para exibir o resultado (IEnumerable para listar)
        return _mapper.Map<IEnumerable<ProductDTO>>(result);
    }

    public async Task<ProductDTO> GetById(int? id)
    {
        // Cria o objeto
        var productIdQuery = new GetProductByIdQuery(id.Value);
        
        // Verifica se  o resultado é valido
        if (productIdQuery == null)
            throw new Exception($"Entity could not be loaded.");

        // Define o resultado e envia o resultado
        var result = await _mediator.Send(productIdQuery);

        return _mapper.Map<ProductDTO>(result);        
    }

    // O método abaixo da enfâse em buscar o id da categoria,
    // ele vai ser igual o de cima basicamente (passível de mudança)
    //public async Task<ProductDTO> GetProductCategory(int? id)
    //{
    //    var productIdQuery = new GetProductByIdQuery(id.Value);
    //    if (productIdQuery == null)
    //        throw new Exception($"Entity could not be loaded.");

    //    var result = await _mediator.Send(productIdQuery);
    //    return _mapper.Map<ProductDTO>(result);
    //}

    public async Task Add(ProductDTO productDto)
    {
        var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
        await _mediator.Send(productCreateCommand);
    }

    public async Task Update(ProductDTO productDto)
    {
        var productUpdateCommand = _mapper.Map<ProductCreateCommand>(productDto);
        await _mediator.Send(productUpdateCommand);
    }

    public async Task Remove(int? id)
    {
        var productRemoveCommand = new ProductRemoveCommand(id.Value);

        if (productRemoveCommand == null)
            throw new Exception($"Entity could not be loaded.");

        await _mediator.Send(productRemoveCommand);
    }
}



/*
 
IMPLEMENTAÇÃO DA CLASSE PRODUCTSERVICE SEM O CRQS:

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IProductRepository productRepository)
    {
        _productRepository = productRepository ??
             throw new ArgumentNullException(nameof(productRepository));

        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsEntity = await _productRepository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
    }

    public async Task<ProductDTO> GetById(int? id)
    {
        var productEntity = await _productRepository.GetProductIdAsync(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task<ProductDTO> GetProductCategory(int? id)
    {
        var productEntity = await _productRepository.GetProductCategoryAsync(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task Add(ProductDTO productDto)
    {
        var productEntity = _mapper.Map<Product>(productDto);
        await _productRepository.Create(productEntity);
    }

    public async Task Update(ProductDTO productDto)
    {

        var productEntity = _mapper.Map<Product>(productDto);
        await _productRepository.Update(productEntity);
    }

    public async Task Remove(int? id)
    {
        var productEntity = _productRepository.GetProductIdAsync(id).Result;
        await _productRepository.Remove(productEntity);
    }
}
 

 
 */
