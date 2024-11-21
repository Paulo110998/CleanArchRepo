using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    // Testando a criação da categoria com validação de estado
    [Fact(DisplayName ="Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "category Name");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    // Testando a criação da categoria com Id inválido
    [Fact(DisplayName ="Create Category With Negative Id Value.")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value."); 
    }

    // Testing a create category with one characteres
    [Fact(DisplayName ="Create Category With Short Name Value")]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characteres.");

    }

    // Testando a criação de categoria sem o valor do nome
    [Fact(DisplayName ="Create Category With Missing Name Value")]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    // Teste com valor nulo
    [Fact(DisplayName = "Create Category With Null Name Value")]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

}

