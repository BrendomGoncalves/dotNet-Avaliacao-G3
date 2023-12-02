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
            try
            {
                opcao = int.Parse(Console.ReadLine() ?? "0");
            }
            catch
            {
                opcao = -1;
            }

            switch (opcao)
            {
                case 1:
                    gerenciaTreinadores();
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
            try
            {
                opcao = int.Parse(Console.ReadLine() ?? "0");
            }
            catch
            {
                opcao = -1;
            }

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
                        Treinador eTreinador = _treinadores.Find(treinador => treinador.Cpf == cpf) ??
                                               throw new Exception("Treinador não encontrado");
                        eTreinador.editarTreinador();
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
                        Treinador rTreinador = _treinadores.Find(treinador => treinador.Cpf == cpf) ??
                                               throw new Exception("Treinador não encontrado");
                        _treinadores.Remove(rTreinador);
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

    public void menuCliente()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("== Menu Clientes ==");
            Console.WriteLine("1. Gerenciar Clientes");
            Console.WriteLine("0. Voltar");
            Console.Write("> ");
            try
            {
                opcao = int.Parse(Console.ReadLine() ?? "0");
            }
            catch
            {
                opcao = -1;
            }

            switch (opcao)
            {
                case 1:
                    gerenciaClientes();
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

    private void gerenciaClientes()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("== Gerenciar Clientes ==");
            Console.WriteLine("1. Cadastrar Cliente");
            Console.WriteLine("2. Listar Clientes");
            Console.WriteLine("3. Editar Cliente");
            Console.WriteLine("4. Remover Cliente");
            Console.WriteLine("0. Voltar");
            Console.Write("> ");
            try
            {
                opcao = int.Parse(Console.ReadLine() ?? "0");
            }
            catch
            {
                opcao = -1;
            }

            string? cpf;
            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    Cliente novoCliente = new Cliente();
                    try
                    {
                        novoCliente.criarCliente();
                        _clientes.Add(novoCliente);
                        Console.WriteLine("Cliente Cadastrado com sucesso!");
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
                    Console.WriteLine("Lista de Clientes:");
                    Console.WriteLine("CPF\t\tDATA DE NASCIMENTO\tALTURA\tPESO\tNOME");
                    foreach (Cliente cliente in _clientes)
                    {
                        cliente.imprimeCliente();
                    }

                    Console.WriteLine();
                    App.pausa();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("EDITAR CLIENTE:");
                    Console.Write("Digite o CPF [ex: XXXXXXXXXXXX]: ");
                    cpf = Console.ReadLine();
                    try
                    {
                        Cliente eCliente = _clientes.Find(cliente => cliente.Cpf == cpf) ??
                                           throw new Exception("Cliente não encontrado");
                        eCliente.editarCliente();
                        Console.WriteLine("Cliente editado com sucesso!");
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
                    Console.WriteLine("REMOVER CLIENTE:");
                    Console.WriteLine("Digite o CPF [ex: XXXXXXXXXXXX]: ");
                    cpf = Console.ReadLine();
                    try
                    {
                        Cliente rCliente = _clientes.Find(cliente => cliente.Cpf == cpf) ??
                                           throw new Exception("Cliente não encontrado");
                        _clientes.Remove(rCliente);
                        Console.WriteLine("Cliente removido com sucesso!");
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