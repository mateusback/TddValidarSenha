using System.Text.RegularExpressions;
using Application.Utils;

namespace Application.Services;

public class ValidacaoSenhaService
{
    private readonly Dictionary<string, string> _regras = new()
    {
        { "^.{8,}$", MensagemUtil.SenhaPequena },
        { ".*[A-Z].*", MensagemUtil.SenhaSemMaiuscula },
        { ".*[a-z].*", MensagemUtil.SenhaSemMinuscula },
        { @".*\d.*", MensagemUtil.SenhaSemNumero },
        { @".*[\W_].*", MensagemUtil.SenhaSemCaractereEspecial },
        { @"^\S*$", MensagemUtil.SenhaComEspacos }
    };
    
    public IReadOnlyList<string> Validar(string senha)
    {
        return (from regra in _regras where !Regex.IsMatch(senha, regra.Key) select regra.Value).ToList();
    }
}