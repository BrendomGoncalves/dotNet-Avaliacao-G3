namespace AcademiaTF;

public class Treino
{
    // Construtores
    public Treino()
    {
        _exercicios = new List<Exercicio>();
        _clientes = new List<(Cliente, int)?>();
    }
    public Treino(string tipo, string objetivo, int duracao, DateTime dataInicio, int vencimento, Treinador? treinador)
    {
        Tipo = tipo;
        Objetivo = objetivo;
        Duracao = duracao;
        DataInicio = dataInicio;
        Vencimento = vencimento;
        Treinador = treinador;
        _exercicios = new List<Exercicio>();
        _clientes = new List<(Cliente, int)?>();
    }
    
    // Atributos
    private string? _tipo;
    private string? _objetivo;
    private int _duracao;
    private DateTime _dataInicio;
    private int _vencimento;
    private Treinador? _treinador;
    private List<Exercicio>? _exercicios;
    private List<(Cliente,int)?>? _clientes;
    
    // Propriedades
    public string? Tipo
    {
        get => _tipo;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Tipo não pode ser nulo");
            _tipo = value;
        }
    }
    public string? Objetivo
    {
        get => _objetivo;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Objetivo não pode ser nulo");
            _objetivo = value;
        }
    }
    public int Duracao
    {
        get => _duracao;
        set
        {
            if (value < 0) throw new Exception("Duração não pode ser negativa");
            if (value == 0) throw new Exception("Duração não pode ser 0");
            _duracao = value;
        }
    }
    public DateTime DataInicio
    {
        get => _dataInicio;
        set
        {
            if (value < DateTime.Now) throw new Exception("Data de início não pode ser anterior a data atual");
            _dataInicio = value;
        }
    }
    public int Vencimento
    {
        get => _vencimento;
        set
        {
            if (value < 0) throw new Exception("Vencimento não pode ser negativo");
            if (value == 0) throw new Exception("Vencimento não pode ser 0");
            _vencimento = value;
        }
    }
    public Treinador? Treinador
    {
        get => _treinador;
        set
        {
            if (value == null) throw new Exception("Treinador não pode ser nulo");
            _treinador = value;
        }
        
    }

    public List<(Cliente, int)?>? Clientes
    {
        get => _clientes;

    }


    
    // Metodos
    public int tamanhoExercicios()
    {
        return _exercicios?.Count ?? 0;
    }
    public int tamanhoClientes()
    {
        return _clientes?.Count ?? 0;
    }

    public void adicionarExercicio(Exercicio exercicio)

    {
        if (_exercicios == null)
        {
            _exercicios?.Add(exercicio);
            return;
        }

        if (_exercicios.Any(e => e == exercicio)) throw new Exception("Exercício já cadastrado");
        _exercicios?.Add(exercicio);
    }

    public void adicionarCliente(Cliente cliente)
    {
        if (_clientes == null)
        {
            _clientes?.Add((cliente, -1));
            return;
        }
        if (_clientes.Any(c => c?.Item1 == cliente)) throw new Exception("Cliente já cadastrado");
        _clientes?.Add((cliente, -1)); // -1 = sem avaliação
    }
    public void imprimeTreino()
    {
        Console.WriteLine($"{Tipo}\t{Objetivo}\t{Duracao}\t{DataInicio:dd/MM/yyyy}\t{Vencimento}\t{Treinador?.Nome}");
    }

    public void adicionarAvaliacao(Cliente cliente, int avaliacao)
    {
        if (_clientes == null)
        {
            throw new Exception("Pensar no que colocar aqui");
        }
        int posicao = _clientes.FindIndex(c => c?.Item1 == cliente);
        if (posicao == -1) throw new Exception("Cliente não cadastrado");
        if (_clientes[posicao]?.Item2 != -1) throw new Exception("Avaliação ja registrada");
        _clientes[posicao] = (cliente, avaliacao);


    }


}