using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category : EntityBase
{
    public string? Name { get; private set; }

    // Construtor 1
    public Category(string name)
    {
        ValidateDomain(name);     
    }

    // Construtor 2 
    public Category(int id, string name)
    {
        DomainExceptionValidation.when(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name);
    }

    public void Update(string name)
    {
        ValidateDomain(name);
    }

    public ICollection<Product>? Products { get;  set; }

    
    // Método de validação
    private void ValidateDomain(string name)
    {
        DomainExceptionValidation
            .when(string.IsNullOrEmpty(name),"Invalid name. Name is required");

        DomainExceptionValidation.when(name.Length < 3, "Invalid name, too short, minimum 3 characteres.");

        // Se não ocorrer excessões, o valor será atribuido.
        Name = name;
    }
}
