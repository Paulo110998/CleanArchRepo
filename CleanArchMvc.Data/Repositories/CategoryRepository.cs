using CleanArchMvc.Data.Context;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private ApplicationDbContext _categoryContext;

    public CategoryRepository(
        ApplicationDbContext context)
    {
        _categoryContext = context;        
    }

    // CREATE
    public async Task<Category> Create(Category category)
    {
        _categoryContext.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    // GET
    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _categoryContext.Categories.ToListAsync();
    }

    // GET(ID)
    public async Task<Category> GetCategoryId(int? id)
    {
       return await _categoryContext.Categories.FindAsync(id);
    }

    // UPDATE
    public async Task<Category> Update(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    // DELETE
    public async Task<Category> Remove(Category category)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

   
}
