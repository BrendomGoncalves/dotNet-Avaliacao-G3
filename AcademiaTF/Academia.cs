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
            Console.WriteLine("2. Filtrar por Idade");
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
                case 2:
                    Console.Clear();
                    Console.WriteLine("Filtrar por Idade:");
                    Console.Write("Idade minima: ");
                    int idadeMinima = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Idade maxima: ");
                    int idadeMaxima = int.Parse(Console.ReadLine() ?? "0");
                    Console.Clear();
                    Console.WriteLine("Treinadores encontrado:");
                    List<Treinador> treinadoresFiltrados = _treinadores.Where(treinador =>
                        Pessoa.calculaIdade(treinador.Nascimento) >= idadeMinima &&
                        Pessoa.calculaIdade(treinador.Nascimento) <= idadeMaxima).ToList();
                    if (treinadoresFiltrados.Count > 0)
                    {
                        foreach (Treinador treinador in treinadoresFiltrados)
                        {
                            treinador.imprimeTreinador();
                        }
                    }
                    else Console.WriteLine("Nenhum treinador encontrado.");

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

    public void menuExercicio()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("== Menu Exercícios ==");
            Console.WriteLine("1. Gerenciar Exercícios");
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
                    gerenciaExercicios();
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
    private void gerenciaExercicios()
    {

        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("== Gerenciar Exercícios ==");
            Console.WriteLine("1. Cadastrar Exercício");
            Console.WriteLine("2. Listar Exercícios");
            Console.WriteLine("3. Editar Exercícios");
            Console.WriteLine("4. Remover Exercícios");
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

            string? grupoMuscular;
            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    Exercicio novoExercicio = new Exercicio();
                    try
                    {
                        novoExercicio.criarExercicio();
                        _exercicios.Add(novoExercicio);
                        Console.WriteLine("Exercício cadastrado com sucesso!");
                    }
                    catch
                    {
                        Console.WriteLine("Cadastro cancelado! Realize a operacao novamente");
                        App.pausa();
                    }

                    App.pausa();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Lista de Exercício:");
                    Console.WriteLine("GRUPO MUSCULAR\tSÉRIES\tREPETIÇÕES\tINTERVALO DE DESCANSO (s)");
                    foreach (Exercicio exercicio in _exercicios)
                    {
                        exercicio.imprimeExercicio();
                    }

                    Console.WriteLine();
                    App.pausa();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("EDITAR EXERCÍCIO:");
                    Console.Write("Digite o grupo muscular [ex: Pernas]: ");
                    grupoMuscular = Console.ReadLine();
                    try
                    {
                        Exercicio uExercicio = _exercicios.Find(exercicio => exercicio.GrupoMuscular == grupoMuscular) ?? throw new Exception("Exercício não encontrado");
                        uExercicio.editarExercicio();
                        Console.WriteLine("Exercício editado com sucesso!");
                    }
                    catch
                    {
                        Console.WriteLine("Edição cancelada! Realize a operacao novamente");
                        App.pausa();
                    }

                    App.pausa();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("REMOVER EXERCÍCIO:");
                    Console.WriteLine("Digite o grupo muscular [ex: Pernas]: ");
                    grupoMuscular = Console.ReadLine();
                    try
                    {
                        Exercicio rExercicio = _exercicios.Find(exercicio => exercicio.GrupoMuscular == grupoMuscular) ??
                                               throw new Exception("Treinador não encontrado");
                        _exercicios.Remove(rExercicio);
                        Console.WriteLine("Exercício removido com sucesso!");
                    }
                    catch
                    {
                        Console.WriteLine("Remoção cancelada! Realize a operacao novamente");
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
            Console.WriteLine("2. Filtrar por Idade");
            Console.WriteLine("3. Filtrar por IMC");
            Console.WriteLine("4. Listar Clientes em Ordem Alfabetica");
            Console.WriteLine("5. Listar Clientes por Idade Descrescente");
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
                case 2:
                    Console.Clear();
                    Console.WriteLine("Filtro por Idade:");
                    Console.Write("Idade minima: ");
                    int idadeMinima = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Idade maxima: ");
                    int idadeMaxima = int.Parse(Console.ReadLine() ?? "0");
                    Console.Clear();
                    Console.WriteLine("Clientes encontrado:");
                    List<Cliente> clientesFiltrados = _clientes.Where(cliente =>
                        Pessoa.calculaIdade(cliente.Nascimento) >= idadeMinima &&
                        Pessoa.calculaIdade(cliente.Nascimento) <= idadeMaxima).ToList();
                    if (clientesFiltrados.Count > 0)
                    {
                        foreach (Cliente cliente in clientesFiltrados)
                        {
                            cliente.imprimeCliente();
                        }
                    }
                    else Console.WriteLine("Nenhum cliente encontrado.");

                    App.pausa();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Filtro por IMC:");
                    Console.Write("IMC minimo: ");
                    double imcBase = double.Parse(Console.ReadLine() ?? "0");

                    Console.Clear();
                    Console.WriteLine("Clientes encontrado:");
                    List<Cliente> clientesFiltrados2 = _clientes
                        .Where(cliente => cliente.Peso / Math.Pow(cliente.Altura, 2) > imcBase)
                        .OrderBy(cliente => cliente.Peso / Math.Pow(cliente.Altura, 2)).ToList();

                    if (clientesFiltrados2.Count > 0)
                    {
                        foreach (Cliente cliente in clientesFiltrados2)
                        {
                            cliente.imprimeCliente();
                        }
                    }
                    else Console.WriteLine("Nenhum cliente encontrado.");
                    App.pausa();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Clientes em Ordem Alfabetica:");
                    List<Cliente> clientesOrdenados = _clientes.OrderBy(c => c.Nome).ToList();
                    foreach (Cliente cliente in clientesOrdenados) cliente.imprimeCliente();
                    App.pausa();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Clientes por Idade Descrescente:");
                    List<Cliente> clientesOrdenados2 = _clientes.OrderBy(c => c.Nascimento).ToList();
                    foreach (Cliente cliente in clientesOrdenados2) cliente.imprimeCliente();
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