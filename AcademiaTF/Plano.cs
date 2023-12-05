namespace AcademiaTF;

public class Plano
{
    private string _titulo;
    private double _valorPorMes;

    public string? Titulo
    {
        get => _titulo;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Nome não pode ser um título nulo");
            _titulo = value;
        }
    }
    public double ValorPorMes
    {
        get => _valorPorMes;
        set
        {
            if(double.IsNegative(value)) throw new Exception ("Não pode ser um valor negativo");
            _valorPorMes = value;
        }
    }

    public void criarPlano()
    {
        Console.Clear();
        Console.WriteLine("CRIAR PLANO:");
        Console.Write("Nome do plano: ");
        Titulo = Console.ReadLine();

        Console.Write("Valor por mês do plano: ");
        string? valorInput = Console.ReadLine();
        int valorMes;
        while (!int.TryParse(valorInput, out valorMes))
        {
            Console.Write("Por favor, insira um número válido para o valor da mensalidade: ");
            valorInput = Console.ReadLine();
        }

        ValorPorMes = valorMes;

    }

    public void editarPlano()
    {
        Console.Clear();
        Console.WriteLine("EDITAR PLANO:");

        Console.Write("Valor por mês do plano: ");
        string? valorInput = Console.ReadLine();

        ValorPorMes = int.Parse(valorInput!);

    }

    public void imprimePlano()
    {
        Console.WriteLine($"{Titulo}\t\t{ValorPorMes}");
    }

}

