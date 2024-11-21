using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{  
    // NÃO LANÇA EXCEÇÃO 
    [Fact(DisplayName = "Create Product With Valid State")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description",
            9.99m, 99, "Product image");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    // LANÇA EXCEÇÃO COM A MENSAGEM
    [Fact(DisplayName = "Create Product With Negative Id Value.")]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description",
            9.99m, 99, "Product image");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    // LANÇA EXCEÇÃO COM MENSAGEM (Mensagem muito curta)
    [Fact(DisplayName = "Create Product With Short Name Value.")]
    public void CreateProduct_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Pr", "Product Description",
            9.99m, 99, "Product image");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characteres");
    }

    // LANÇA EXCEÇÃO COM A MENSAGEM
    [Fact(DisplayName ="Create a Product With Long Image Name")]
    public void CreateProduct_LongImageName_DomainExceptionLongImageName()
    {
        Action action = () => new Product(1, "Product Name", "Product Description",
            9.99m, 99, "Product image tooooooooooooooooooo loooooooooong00000000000000000jjjjjjjjjjjjjjjjjjjjjjkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk");

        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid image name, too long, maximum 250 characters");
    }

    // NÃO LANÇA EXCEÇÃO (A imagem pode ser nula, de acordo com a entidade)
    [Fact(DisplayName ="Create a Product With Null Image Name")]
    public void CreateProduct_WithNullImageName_NoDomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description",
            9.99m, 99, null);
        action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }


    // NÃO LANÇA EXCEÇÃO (Imagem pode ser nula ou vazia na entidade)
    [Fact(DisplayName ="Create a Product With Empty Image Name ")]
    public void CreateProduct_WithEmptyImageName_NoDomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description",
            9.99m, 99, "");
        action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    // NÃO LANÇA EXCEÇÃO DE ERRO COM IMAGEM NULL (POIS PERMITE VALORES NULL)
    [Fact]
    public void CreateProduct_WithNullImageName_NoNullReferenceException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
        action.Should().NotThrow<NullReferenceException>();
    }


    // LANÇA EXCEÇÃO COM MENSAGEM (Valor do stock é inválido)
    [Theory]
    [InlineData(-5)]
    public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
    {
        Action action = () => new Product(1, "Product Name", "Product Description",
            9.99m, value, "Product image");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }

    // passando o valor do parâmetro em [InlineData(-5)]

    /*
     No Xunit, [Theory] é um atributo que permite a criação de testes parametrizados, 
    permitindo executar o mesmo teste com diferentes conjuntos de dados. [InlineData] é 
    utilizado em conjunto com [Theory] para fornecer os dados de entrada diretamente no 
    código do teste. Cada conjunto de dados especificado por [InlineData] resulta em uma 
    execução separada do teste com esses valores. Isso facilita a criação de testes mais 
    abrangentes e variados sem duplicar o código do teste.
     */


}
