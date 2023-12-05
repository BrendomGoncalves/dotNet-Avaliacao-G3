namespace AcademiaTF;

public abstract class Pagamento
{
    private String _descricao;
    private double _valor;
    private double _desconto;

    private DateTime _dataHora;
    public String Descricao { get=> _descricao; set{
        if (value == null) throw new Exception("Descrição não pode ser nula");
        if (value == "") throw new Exception("Descrição não pode ser vazia");
        _descricao = value;
    
    } }

    public double ValorBruto { get=>_valor; set{
        if (value < 0) throw new Exception("Valor não pode ser negativo");
        if (value == 0) throw new Exception("Valor não pode ser zero");
        _valor = value;
    } }

    public double Desconto { get=>_desconto; set{
        if (value < 0) throw new Exception("Desconto não pode ser negativo");
        if (value == 0) throw new Exception("Desconto não pode ser zero");
        _desconto = value;

    } }
    public DateTime DataHora { get=>_dataHora; set{
        if (value == DateTime.MinValue) throw new Exception("Data não pode ser vazia");
        _dataHora = value;
    } }


}
}