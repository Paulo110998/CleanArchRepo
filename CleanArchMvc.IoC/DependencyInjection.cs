using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Data.Context;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
               
        // Adicionado referência ao serviço do Identity
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        // Configurando Cookie do Aplicativo
        services.ConfigureApplicationCookie(options =>
        options.AccessDeniedPath = "/Account/Login");
        
        // Serviços de Autenticação e Role
        services.AddScoped<IAuthenticate, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

       
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
