using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Data.Context;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchMvc.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Adicionando referência da classe de contexto
        services.AddDbContext<ApplicationDbContext>(options =>
        // Provedor de banco de dados e conexão
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        // MigrationAssembly -> Define o lugar onde as migrações estão mantidas.

        // Adicionando referência do repositório category
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        // Adicionando referência do repositório product
        services.AddScoped<IProductRepository, ProductRepository>();

        // Adicionando o Service de Product e Category
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();

        // Adicionando o service AutoMapper
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        // Adicionando o service de MediatR 
        var myhandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
        services.AddMediatR(myhandlers);

        return services;
    }
}
