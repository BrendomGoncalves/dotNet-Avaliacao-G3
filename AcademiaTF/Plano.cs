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
        double valorInput = double.Parse(Console.ReadLine()!);
        ValorPorMes = valorInput;
    }

    public void editarPlano()
    {
        Console.Clear();
        Console.WriteLine("EDITAR PLANO:");

        Console.Write("Valor por mês do plano: ");
        string? valorInput = Console.ReadLine();

        ValorPorMes = double.Parse(valorInput!);
    }

    public void imprimePlano()
    {
        Console.WriteLine($"{Titulo}\t\t{ValorPorMes}");
    }

}