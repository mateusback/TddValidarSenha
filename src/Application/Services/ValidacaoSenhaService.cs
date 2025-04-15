using System.Text.RegularExpressions;

namespace Application.Services;

public class ValidacaoSenhaService
{
    private readonly Dictionary<string, string> _regras = new()
    {
        { "^.{8,}$", "A senha deve ter pelo menos 8 caracteres." },
        { ".*[A-Z].*", "A senha deve conter pelo menos uma letra maiúscula." },
        { ".*[a-z].*", "A senha deve conter pelo menos uma letra minúscula." },
        { @".*\d.*", "A senha deve conter pelo menos um número." },
        { @".*[\W_].*", "A senha deve conter pelo menos um caractere especial." },
        { @"^\S*$", "A senha não deve conter espaços." }
    };
    
    public IReadOnlyList<string> Validar(string senha)
    {
        return (from regra in _regras where !Regex.IsMatch(senha, regra.Key) select regra.Value).ToList();
    }
}