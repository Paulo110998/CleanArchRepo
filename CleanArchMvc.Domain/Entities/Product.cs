using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Product : EntityBase
{
    public string? Name { get; private set; }

    public string? Description { get; private set; }

    public decimal Price { get; private set; }

    public int Stock { get; private set; }

    public string? Image { get; private set; }

    // Construtor 1
    public Product(string name, string description, 
        decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    // Construtor 2
    public Product(int id, string name, string description, 
        decimal price, int stock, string image)
    {
        DomainExceptionValidation.when(id < 0, "Invalid Id value");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
        
    }

    public void Update(string name, string description,
      decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;

    }

    private void ValidateDomain(string name, string description, 
        decimal price, int stock, string image)
    {
        // Validation of Name
        DomainExceptionValidation
            .when(string.IsNullOrEmpty(name), "Invalid name. Name is required");

        DomainExceptionValidation.when(name.Length < 3, "Invalid name, too short, minimum 3 characteres");

        // Validation of Description
        DomainExceptionValidation
            .when(string.IsNullOrEmpty(description), "Invalid description. Description is required");

        DomainExceptionValidation.when(description.Length < 3, "Invalid description. Description is required");

        // Validation of Price
        DomainExceptionValidation.when(price < 0, "Invalid price value");

        // Validation of Stock
        DomainExceptionValidation.when(stock < 0, "Invalid stock value");

        // Validation of Image
        DomainExceptionValidation.when(image?.Length > 250, "Invalid image name, too long, maximum 250 characters");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;

    }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
