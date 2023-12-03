namespace AcademiaTF;

public class Exercicio
{
    // Construtores
    public Exercicio() { }
    public Exercicio(string grupoMuscular, int series, int repeticoes, int tempoIntervalo)
    {
        GrupoMuscular = grupoMuscular;
        Series = series;
        Repeticoes = repeticoes;
        TempoIntervalo = tempoIntervalo;
    }
    
    // Atributos
    private string? _grupoMuscular;
    private int _series;
    private int _repeticoes;
    private int _tempoIntervalo;
    
    // Propriedades
    public string? GrupoMuscular
    {
        get => _grupoMuscular;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Grupo Muscular não pode ser nulo");
            _grupoMuscular = value;
        }
    }
    public int Series
    {
        get => _series;
        set
        {
            if (value < 0) throw new Exception("Séries não pode ser negativa");
            _series = value;
        }
    }
    public int Repeticoes
    {
        get => _repeticoes;
        set
        {
            if (value < 0) throw new Exception("Repetições não pode ser negativa");
            _repeticoes = value;
        }
    }
    public int TempoIntervalo
    {
        get => _tempoIntervalo;
        set
        {
            if (value < 0) throw new Exception("Tempo de Intervalo não pode ser negativa");
            _tempoIntervalo = value;
        }
    }

    public void criarExercicio()
    {
        Console.Clear();
        Console.WriteLine("CRIAR EXERCÍCIO:");
        Console.Write("Grupo Muscular: ");
        GrupoMuscular = Console.ReadLine();

        Console.Write("Quantidade de séries: ");
        string? series = Console.ReadLine();
      
        Series = int.Parse(series);

        Console.Write("Quantidade de repetições: ");
        string? repeticoes= Console.ReadLine();
        
        Repeticoes = int.Parse(repeticoes);
        

        Console.Write("Tempo de intervalo (em segundos): ");
        string? tempoIntervalo = Console.ReadLine();
        TempoIntervalo = int.Parse(tempoIntervalo);
    }

    public void editarExercicio()
    {

        Console.Clear();
        Console.WriteLine("EDITAR EXERCÍCIO:");

        Console.Write("Quantidade de séries: ");
        string? series = Console.ReadLine();
      
        Series = int.Parse(series);

        Console.Write("Quantidade de repetições: ");
        string? repeticoes= Console.ReadLine();
        
        Repeticoes = int.Parse(repeticoes);
        

        Console.Write("Tempo de intervalo (em segundos): ");
        string? tempoIntervalo = Console.ReadLine();
        TempoIntervalo = int.Parse(tempoIntervalo);
    }

    
    public void imprimeExercicio()
    {
        Console.WriteLine($"{GrupoMuscular}\t\t{Series}\t{Repeticoes}\t\t{TempoIntervalo}");
    }
}