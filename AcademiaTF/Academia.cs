namespace AcademiaTF;

public class Academia
{
    // Construtores
    public Academia()
    {
        _treinos = new List<Treino>();
        _exercicios = new List<Exercicio>();
        _treinadores = new List<Treinador>();
        _clientes = new List<Cliente>();
    }
    
    // Atributos
    private List<Treino> _treinos;
    private List<Exercicio> _exercicios;
    private List<Treinador> _treinadores;
    private List<Cliente> _clientes;
}