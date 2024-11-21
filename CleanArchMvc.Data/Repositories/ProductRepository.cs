using CleanArchMvc.Data.Context;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private ApplicationDbContext _productContext;

    public ProductRepository(ApplicationDbContext productContext)
    {
        _productContext = productContext;
    }

    // CREATE
    public async Task<Product> Create(Product product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;       
    }

    // Buscando a categoria do produto (busca o id do produto e o id da categoria relacionada)
    //public async Task<Product> GetProductCategoryAsync(int? id)
    //{
    //    return await _productContext.Products.Include(c => c.Category)
    //        .SingleOrDefaultAsync(p => p.Id == id);
    //}

    // GET (ID)
    public async Task<Product> GetProductIdAsync(int? id)
    {
        return await _productContext.Products.Include(c => c.Category)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    // GET
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productContext.Products.ToListAsync();       
    }

    // DELETE
    public async Task<Product> Remove(Product product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    // UPDATE
    public async Task<Product> Update(Product product)
    {
        _productContext.Update(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}
