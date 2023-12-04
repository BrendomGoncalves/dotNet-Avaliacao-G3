namespace AcademiaTF;

public class Cliente : Pessoa
{
    // Construtores
    public Cliente() { }
    public Cliente(string nome, DateTime nascimento, string cpf, float altura, float peso)
    {
        Nome = nome;
        Nascimento = nascimento;
        Cpf = cpf;
        Altura = altura;
        Peso = peso;
    }
    
    // Atributos
    private float _altura;
    private float _peso;
    
    // Propriedades
    public float Altura
    {
        get => _altura;
        set
        {
            if (value < 0) throw new Exception("Altura não pode ser negativa");
            _altura = value;
        }
    }
    public float Peso
    {
        get => _peso;
        set
        {
            if (value < 0) throw new Exception("Peso não pode ser negativo");
            _peso = value;
        }
    }
    
    // Metodos
    public void criarCliente()
    {
        Console.Clear();
        Console.WriteLine("CRIAR CLIENTE:");
        Console.Write("Nome: ");
        Nome = Console.ReadLine();

        Console.Write("Nascimento [ex: XX/XX/XXXX]: ");
        string? nascimento = Console.ReadLine();
        while (!validaData(nascimento!))
        {
            Console.WriteLine("Data inválida!");
            Console.Write("Nascimento [ex: XX/XX/XXXX]: ");
            nascimento = Console.ReadLine();
        }
        DateTime dataConvertida;
        DateTime.TryParseExact(nascimento, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataConvertida);
        Nascimento = dataConvertida;

        Console.Write("CPF [ex: XXXXXXXXXXXX]: ");
        string? cpf = Console.ReadLine();
        while (!validaCpf(cpf!))
        {
            Console.WriteLine("Cpf invalido");
            Console.Write("Cpf: ");
            cpf = Console.ReadLine();
        }
        Cpf = cpf;

        Console.Write("Altura [ex: X,XX]: ");
        Altura = float.Parse(Console.ReadLine() ?? "0.00");
        
        Console.Write("Peso [ex: XX,X]: ");
        Peso = float.Parse(Console.ReadLine() ?? "0.00");
    }
    
    public void editarCliente()
    {
        Console.Clear();
        Console.WriteLine("EDITAR CLIENTE:");
        Console.Write("Nome: ");
        Nome = Console.ReadLine();
        Console.Write("Altura [ex: X,XX]: ");
        Altura = float.Parse(Console.ReadLine() ?? "0.00");
        Console.Write("Peso [ex: XX,X]: ");
        Peso = float.Parse(Console.ReadLine() ?? "0.00");
    }
    public void imprimeCliente()
    {
        Console.WriteLine($"{Cpf}\t{Nascimento:dd/MM/yyyy}\t\t{Altura:F2}\t{Peso:F2}\t{Nome}");
    }
}