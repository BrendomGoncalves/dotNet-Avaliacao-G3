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

    // Propriedades
    public List<Treino> Treinos
    {
        get => _treinos;
    }

    public List<Exercicio> Exercicios
    {
        get => _exercicios;
    }

    public List<Treinador> Treinadores
    {
        get => _treinadores;
    }

    public List<Cliente> Clientes
    {
        get => _clientes;
    }

    // Metodos
    public void menuTreinador()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("== Menu Treinadores ==");
            Console.WriteLine("1. Gerenciar Treinadores");
            Console.WriteLine("0. Voltar");
            Console.Write("> ");
            opcao = int.Parse(Console.ReadLine() ?? "0");

            switch (opcao)
            {
                case 1:
                    gerenciaTreinadores();
                    App.pausa();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    App.pausa();
                    break;
            }
        } while (opcao != 0);
    }
    private void gerenciaTreinadores()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("== Gerenciar Treinadores ==");
            Console.WriteLine("1. Cadastrar Treinador");
            Console.WriteLine("2. Listar Treinadores");
            Console.WriteLine("3. Editar Treinador");
            Console.WriteLine("4. Remover Treinador");
            Console.WriteLine("0. Voltar");
            Console.Write("> ");
            opcao = int.Parse(Console.ReadLine() ?? "0");

            string? cpf;
            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    Treinador novoTreinador = new Treinador();
                    try
                    {
                        novoTreinador.criarTreinador();
                        _treinadores.Add(novoTreinador);
                        Console.WriteLine("Treinador Cadastrado com sucesso!");
                    }
                    catch
                    {
                        Console.WriteLine("Cadastro Cancelado! Realize a operacao novamente");
                        App.pausa();
                    }
                    App.pausa();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Lista de Treinadores:");
                    Console.WriteLine("CPF\t\tCREF\t\tDATA DE NASCIMENTO\tNOME");
                    foreach (Treinador treinador in _treinadores)
                    {
                        treinador.imprimeTreinador();
                    }
                    Console.WriteLine();
                    App.pausa();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("EDITAR TREINADOR:");
                    Console.Write("Digite o CPF [ex: XXXXXXXXXXXX]: ");
                    cpf = Console.ReadLine();
                    try
                    {
                        Treinador editarTreinador = _treinadores.Find(treinador => treinador.Cpf == cpf) ?? throw new Exception("Treinador não encontrado");
                        editarTreinador.editarTreinador();
                        Console.WriteLine("Nome do treinador editado com sucesso!");
                    }
                    catch
                    {
                        Console.WriteLine("Edicao Cancelada! Realize a operacao novamente");
                        App.pausa();
                    }
                    App.pausa();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("REMOVER TREINADOR:");
                    Console.WriteLine("Digite o CPF [ex: XXXXXXXXXXXX]: ");
                    cpf = Console.ReadLine();
                    try
                    {
                        Treinador removerTreinador = _treinadores.Find(treinador => treinador.Cpf == cpf) ?? throw new Exception("Treinador não encontrado");
                        _treinadores.Remove(removerTreinador);
                        Console.WriteLine("Treinador removido com sucesso!");
                    }
                    catch
                    {
                        Console.WriteLine("Remocao Cancelada! Realize a operacao novamente");
                        App.pausa();
                    }
                    App.pausa();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        } while (opcao != 0);
    }
}