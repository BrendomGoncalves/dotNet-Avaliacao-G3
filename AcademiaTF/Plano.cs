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
            if(double.IsNullOrWhiteSpace(value)) throw new Exception ("Não pode ser um valor nulo");
            _valorPorMes = value
        }
    }
}

