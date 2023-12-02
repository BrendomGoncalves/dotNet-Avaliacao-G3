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

    // Métodos
    public void criarTreinador()
    {
        Console.Clear();
        Console.WriteLine("CRIAR TREINADOR:");
        Console.Write("Nome: ");
        Nome = Console.ReadLine();

        Console.Write("Nascimento [ex: XX/XX/XXXX]: ");
        string? nascimento = Console.ReadLine();
        while (!validaData(nascimento!))
        {
            Console.WriteLine("Data inválida!");
            Console.WriteLine("Nascimento [ex: XX/XX/XXXX]: ");
            nascimento = Console.ReadLine();
        }

        Nascimento = Convert.ToDateTime(nascimento);

        Console.Write("CPF [ex: XXXXXXXXXXXX]: ");
        string? cpf = Console.ReadLine();
        while (!validaCpf(cpf!))
        {
            Console.WriteLine("Cpf invalido");
            Console.Write("Cpf: ");
            cpf = Console.ReadLine();
        }

        Cpf = cpf;

        Console.Write("CREF [ex: XXXXXX-X/XX]:");
        string? cref = Console.ReadLine();
        while (!validaCref(cref!))
        {
            Console.WriteLine("CREF invalido");
            Console.Write("CREF: ");
            cref = Console.ReadLine();
        }

        Cref = cref;
    }

    public void editarTreinador()
    {
        Console.Clear();
        Console.WriteLine("EDITAR TREINADOR:");
        Console.WriteLine("obs: apenas o nome pode ser alterado");
        Console.Write("Nome: ");
        Nome = Console.ReadLine();
    }

    public void imprimeTreinador()
    {
        Console.WriteLine($"{Cpf}\t{Cref}\t{Nascimento:dd/MM/yyyy}\t\t{Nome}");
    }
}