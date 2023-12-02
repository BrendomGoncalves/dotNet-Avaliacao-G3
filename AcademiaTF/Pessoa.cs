using System.Text.RegularExpressions;

namespace AcademiaTF;

public class Pessoa
{
    // Atributos
    private string? _nome;
    private DateTime _nascimento;
    private string? _cpf;

    // Propriedades
    public string? Nome
    {
        get => _nome;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Nome não pode ser nulo");
            _nome = value;
        }
    }

    public DateTime Nascimento
    {
        get => _nascimento;
        set
        {
            if (value > DateTime.Now) throw new Exception("Data de nascimento inválida");
            _nascimento = value;
        }
    }

    public string? Cpf
    {
        get => _cpf;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 11) throw new Exception("Cpf não pode ser nulo");
            _cpf = value;
        }
    }

    // Métodos
    public static bool validaData(string data)
    {
        const string padrao = @"\d{2}/\d{2}/\d{4}";
        if (Regex.IsMatch(data, padrao)) return true;
        return false;
    }

    public static bool validaCpf(string cpf)
    {
        if (Regex.IsMatch(cpf, @"^\d+$") && cpf.Length == 11)
        {
            return true;
        }
        return false;
    }
    public static bool validaCref(string cref)
    {
        const string padrao = @"\d{6}-\d{1}/[A-Z]{2}";
        if (Regex.IsMatch(cref, padrao))
        {
            return true;
        }
        return false;
    }
}