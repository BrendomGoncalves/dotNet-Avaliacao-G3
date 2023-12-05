namespace AcademiaTF;

public class Cliente : Pessoa
{
    // Construtores
    public Cliente()
    {
        Pagamentos = new List<Pagamento>();
        MesPagamento = new List<bool>{false, false, false, false, false, false, false, false, false, false, false, false};
    }
    public Cliente(string nome, DateTime nascimento, string cpf, int altura, int peso, Plano planoAtivo)
    {
        Nome = nome;
        Nascimento = nascimento;
        Cpf = cpf;
        Altura = altura;
        Peso = peso;
        PlanoAtivo = planoAtivo;
        Pagamentos = new List<Pagamento>();
        MesPagamento = new List<bool>{false, false, false, false, false, false, false, false, false, false, false, false};
    }
    public Cliente(string nome, DateTime nascimento, string cpf, int altura, int peso)
    {
        Nome = nome;
        Nascimento = nascimento;
        Cpf = cpf;
        Altura = altura;
        Peso = peso;
        Pagamentos = new List<Pagamento>();
        MesPagamento = new List<bool>{false, false, false, false, false, false, false, false, false, false, false, false};
    }
    
    // Atributos
    private int _altura;
    private int _peso;
    private Plano _planoAtivo;

    // Propriedades
    public int Altura
    {
        get => _altura;
        set
        {
            if (value < 0) throw new Exception("Altura não pode ser negativa");
            if (value > 300) throw new Exception("Altura não pode ser maior que 3 metros");
            if (value == 0) throw new Exception("Altura não pode ser zero");
            _altura = value;
        }
    }
    public int Peso
    {
        get => _peso;
        set
        {
            if (value < 0) throw new Exception("Peso não pode ser negativo");
            if (value == 0) throw new Exception("Peso não pode ser zero");
            _peso = value;
        }
    }
    public Plano PlanoAtivo
    {
        get => _planoAtivo;
        set
        {
            if (value == null) throw new Exception("Plano inválido");
            _planoAtivo = value;
        }
    }
    public List<Pagamento> Pagamentos { get; }
    public List<Boolean> MesPagamento{get;}

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

        Console.Write("Altura em cm[ex:180]: ");
        try
        {
            Altura = int.Parse(Console.ReadLine() ?? "0");
        }
        catch
        {
            throw new Exception("Altura inválida");
        }
        
        Console.Write("Peso em kg[ex: 45]: ");
        try
        {
            Peso = int.Parse(Console.ReadLine() ?? "0");
        }
        catch
        {
            throw new Exception("Peso inválido");
        }
    }
    
    public void editarCliente()
    {
        Console.Clear();
        Console.WriteLine("EDITAR CLIENTE:");
        Console.Write("Nome: ");
        Nome = Console.ReadLine();
        Console.Write("Altura [ex: X,XX]: ");
        Altura = int.Parse(Console.ReadLine() ?? "0.00");
        Console.Write("Peso [ex: XX,X]: ");
        Peso = int.Parse(Console.ReadLine() ?? "0.00");
    }
    public void imprimeCliente()
    {
        Console.WriteLine($"{Cpf}\t{Nascimento:dd/MM/yyyy}\t\t{Altura:F2}\t{Peso:F2}\t{Nome}");
    }
}