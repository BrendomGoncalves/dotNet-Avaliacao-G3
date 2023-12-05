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

public class PagamentoDinheiro : Pagamento
{
    public void RealizarPagamento(double valor)
    {
        try{

        Desconto = valor * 0.05; //desconto de 5%
        ValorBruto = (valor * 1.10) - Desconto; //taxa e desconto
        Descricao = $"O pagamento foi feito por dinheiro no valor de {ValorBruto}";
        DateTime data = DateTime.Now;
        }catch{
            throw new Exception("O valor informado é inválido");
        }
    }
}

}