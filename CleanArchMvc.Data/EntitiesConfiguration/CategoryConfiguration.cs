using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Data.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Definindo a chave primária
        builder.HasKey(id=> id.Id);

        // Definindo a propriedade nome como nvarchar 100 e NotNull com IsRequired
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

        // Ao migrar as tabelas podemos popular a tabela com dados, para que não fique vazia
        builder.HasData(
            new Category(1, "Material Escolar"),
            new Category(2, "Eletrônicos"),
            new Category(3, "Acessórios")
            );
    }
}
