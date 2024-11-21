using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Data.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Definindo a chave primária
        builder.HasKey(id => id.Id);

        // Definindo a propriedade nome como nvarchar 100 e NotNull com IsRequired
        builder.Property(n => n.Name).HasMaxLength(100).IsRequired();

        // Definindo a propriedade nome como nvarchar 150 e NotNull com IsRequired
        builder.Property(d => d.Description).HasMaxLength(135).IsRequired();

        // Definindo a propriedade com a precisão de 10 com 2 casas decimais
        builder.Property(p => p.Price).HasPrecision(10, 2).IsRequired();

        // Definindo a propriedade imagem como nvarchar 200 e deixando Null 
        builder.Property(img => img.Image).HasMaxLength(200);

        // Relacionamento de 1 para muitos (uma categoria possui muitos produtos)
        builder.HasOne(c => c.Category).WithMany(p => p.Products)
            .HasForeignKey(id => id.CategoryId); // Chave primária da categoria na table produtos
    }
}



