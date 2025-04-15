namespace Application.Services;

public class ValidacaoSenhaService
{
    public IReadOnlyList<string> Validar(string senha)
    {
        var validacoes = new List<string>();
        
        if (senha.Length < 8)
            validacoes.Add("A senha deve ter pelo menos 8 caracteres.");
        
        if (!senha.Any(char.IsUpper))
            validacoes.Add("A senha deve conter pelo menos uma letra maiúscula.");
        
        if (!senha.Any(char.IsLower))
            validacoes.Add("A senha deve conter pelo menos uma letra minúscula.");
        
        if (!senha.Any(char.IsDigit))
            validacoes.Add("A senha deve conter pelo menos um número.");
        
        if (!senha.Any(char.IsSymbol) && !senha.Any(char.IsPunctuation))
            validacoes.Add("A senha deve conter pelo menos um caractere especial.");
        
        if (senha.Contains(' '))
            validacoes.Add("A senha não deve conter espaços.");
        
        return validacoes;
    }
}