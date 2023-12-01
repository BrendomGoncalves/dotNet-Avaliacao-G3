namespace AcademiaTF;

public class Treinador : Pessoa
{
    // Construtores
    public Treinador() { }
    public Treinador(string nome, DateTime nascimento, string cpf, string cref)
    {
        Nome = nome;
        Nascimento = nascimento;
        Cpf = cpf;
        Cref = cref;
    }
    
    // Atributos
    private string? _cref;
    
    // Propriedades
    public string? Cref
    {
        get => _cref;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Cref não pode ser nulo");
            _cref = value;
        }
    }
}