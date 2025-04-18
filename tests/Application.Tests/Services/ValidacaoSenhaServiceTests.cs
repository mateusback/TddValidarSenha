﻿using Application.Services;

namespace Application.Tests.Services;

public class ValidacaoSenhaServiceTests
{
    private readonly ValidacaoSenhaService _validacaoSenhaService = new();

    [Fact(DisplayName = "Deve retornar senha invalida caso tenha menos de 8 caracteres")]
    public void DeveRetornarErroCasoSenhaPequena()
    {
        // Arrange
        var senha = "1234567";
        
        // Act
        var resultado = _validacaoSenhaService.Validar(senha);
        
        // Assert
        Assert.Contains("A senha deve ter pelo menos 8 caracteres.", resultado);
    }

    [Fact(DisplayName = "Deve retornar senha invalida caso não tenha letras maiusculas")]
    public void DeveRetornarFalseCasoNaoTenhaLetraMaiuscula()
    {
        // Arrange
        var senha = "senha123";
        
        // Act
        var resultado = _validacaoSenhaService.Validar(senha);
        
        // Assert
        Assert.Contains("A senha deve conter pelo menos uma letra maiúscula.", resultado);
    }

    [Fact(DisplayName = "Deve retornar senha invalida caso não tenha letras minusculas")]
    public void DeveRetornarFalseCasoNaoTenhaLetraMinuscula()
    {
        // Arrange
        var senha = "SENHA123";
        
        // Act
        var resultado = _validacaoSenhaService.Validar(senha);
        
        // Assert
        Assert.Contains("A senha deve conter pelo menos uma letra minúscula.", resultado);
    }

    [Fact(DisplayName = "Deve retornar senha invalida caso não tenha numeros")]
    public void DeveRetornarFalseCasoNaoTenhaNumeros()
    {
        // Arrange
        var senha = "senhaSemNumero";
        
        // Act
        var resultado = _validacaoSenhaService.Validar(senha);
        
        // Assert
        Assert.Contains("A senha deve conter pelo menos um número.", resultado);
    }

    [Fact(DisplayName = "Deve retornar senha invalida caso não tenha caracteres especiais")]
    public void DeveRetornarFalseCasoNaoTenhaCaracterEspecial()
    {
        // Arrange
        var senha = "senhaInvalidaDeNovo123";
        
        // Act
        var resultado = _validacaoSenhaService.Validar(senha);
        
        // Assert
        Assert.Contains("A senha deve conter pelo menos um caractere especial.", resultado);
    }

    [Fact(DisplayName = "Deve retornar senha invalida caso tenha espaços em branco")]
    public void DeveRetornarFalseCasoTenhaEspacosEmBranco()
    {
        // Arrange
        var senha = "Senha com espaco1";
        
        // Act
        var resultado = _validacaoSenhaService.Validar(senha);
        
        // Assert
        Assert.Contains("A senha não deve conter espaços.", resultado);
    }
    
    [Theory (DisplayName = "Deve retornar senha valida caso tenha todos os requisitos")]
    [InlineData("Senha123!")]
    [InlineData("Senha@123")]
    [InlineData("Senha#123")]
    [InlineData("Senha$123")]
    [InlineData("Senha%123")]
    [InlineData("Senha^123")]
    [InlineData("Senha&123")]
    [InlineData("Senha*123")]
    [InlineData("Senha(123)")]
    [InlineData("Senha)123!")]
    public void DeveRetornarTrueCasoTenhaTodosOsRequisitos(string senha)
    {
        // Act
        var resultado = _validacaoSenhaService.Validar(senha);
        
        // Assert
        Assert.Empty(resultado);
    }
    
    [Theory(DisplayName = "Deve retornar senha invalida caso falhe em algum requisito")]
    [InlineData("Senha123")]
    [InlineData("senha123!")]
    [InlineData("SENHA123!")]
    [InlineData("Senha!")]
    [InlineData("Senha 123!")]
    [InlineData("Senha@")]
    [InlineData("Senha#")]
    [InlineData("Senha$")]
    [InlineData("Senha%")]
    [InlineData("Se nha^")]
    [InlineData("Senha &")]
    public void DeveRetornarFalseCasoFalheEmAlgumRequisito(string senha)
    {
        // Act
        var resultado = _validacaoSenhaService.Validar(senha);
        
        // Assert
        Assert.NotEmpty(resultado);
    }
    
}