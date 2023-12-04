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
        criarTreinadores();
        criarClientes();
        criarExercicios();
    }

    // Atributos
    private List<Treino> _treinos;
    private List<Exercicio> _exercicios;
    private List<Treinador> _treinadores;
    private List<Cliente> _clientes;

    #region MetodosDeTeste
        //criando treinadores
        public void criarTreinadores()
        {
            Treinador t1 = new Treinador("João", new DateTime(1990, 10, 10), "12345678901", "123456-4/AA");
            Treinador t2 = new Treinador("Maria", new DateTime(1990, 10, 10), "12345678902", "123456-4/AB");
            Treinador t3 = new Treinador("José", new DateTime(1990, 10, 10), "12345678903", "123456-4/AC");
            Treinador t4 = new Treinador("Ana", new DateTime(1990, 10, 10), "12345678904", "123456-4/AE");
            Treinador t5 = new Treinador("Pedro", new DateTime(1990, 10, 10), "12345678905", "123456-4/AF");
            _treinadores.Add(t1);
            _treinadores.Add(t2);
            _treinadores.Add(t3);
            _treinadores.Add(t4);
            _treinadores.Add(t5);
        }
        //criando clientes
        public void criarClientes()
        {
            Cliente c1 = new Cliente("igor", new DateTime(1990, 10, 10), "12345678901", 185, 80);
            Cliente c2 = new Cliente("lima", new DateTime(1990, 10, 10), "12345678902", 180, 50);
            Cliente c3 = new Cliente("rocha", new DateTime(1990, 10, 10), "12345678903", 165, 80);
            _clientes.Add(c1);
            _clientes.Add(c2);
            _clientes.Add(c3);
        }
        //criando exercicios
        public void criarExercicios()
        {
            Exercicio e1 = new Exercicio("Pernas", 3, 10, 30);
            Exercicio e2 = new Exercicio("Braços", 3, 10, 30);
            Exercicio e3 = new Exercicio("Peito", 3, 10, 30);
            Exercicio e4 = new Exercicio("Costas", 3, 10, 30);
            Exercicio e5 = new Exercicio("Ombros", 3, 10, 30);
            Exercicio e6 = new Exercicio("Abdomen", 3, 10, 30);
            _exercicios.Add(e1);
            _exercicios.Add(e2);
            _exercicios.Add(e3);
            _exercicios.Add(e4);
            _exercicios.Add(e5);
            _exercicios.Add(e6);
        }
    #endregion
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
            Console.WriteLine("3. Media de notas de treinos");
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
                case 3:

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
                        if (_treinadores.Any(t => t.Cpf == novoTreinador.Cpf))
                            throw new Exception("Treinador já cadastrado (CPF repetido)");
                        if (_treinadores.Any(t => t.Cref == novoTreinador.Cref))
                            throw new Exception("Treinador já cadastrado (CREF repetido)");
                        _treinadores.Add(novoTreinador);
                        Console.WriteLine("Treinador Cadastrado com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
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
            Console.WriteLine("2. Top 10 exercícios mais utilizados nos treinos");
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
                case 2:
                    Console.WriteLine("Top 10 exercícios mais utilizados nos treinos");
                    var exerciciosMaisUtilizados = Treinos
                        .SelectMany(treino => treino.Exercicios!)
                        .GroupBy(exercicio => exercicio.GrupoMuscular)
                        .OrderByDescending(grupo => grupo.Count())
                        .Take(10)
                        .Select(grupo => grupo.Key);
                    
                    foreach (var exercicio in exerciciosMaisUtilizados)
                    {
                        Console.WriteLine(exercicio);
                    }
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
                        Exercicio uExercicio =
                            _exercicios.Find(exercicio => exercicio.GrupoMuscular == grupoMuscular) ??
                            throw new Exception("Exercício não encontrado");
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
                        Exercicio rExercicio =
                            _exercicios.Find(exercicio => exercicio.GrupoMuscular == grupoMuscular) ??
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
                        if (_clientes.Any(c => c.Cpf == novoCliente.Cpf))
                            throw new Exception("Cliente já cadastrado (CPF repetido)");
                        _clientes.Add(novoCliente);
                        Console.WriteLine("Cliente Cadastrado com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
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
    public void MesAniversariantes()
    {
        Console.Clear();
        Console.WriteLine("Treinadores e clientes aniversariantes do mes");
        Console.Write("Digite o mes que deseja consultar (entre 1-12): ");
        int mesAniversario = int.Parse(Console.ReadLine() ?? "0");

        List<Treinador> treinadoresAniversariantes = _treinadores.Where(treinador =>
            treinador.Nascimento.Month == mesAniversario).ToList();
        List<Cliente> clientesAniversariantes = _clientes.Where(cliente =>
            cliente.Nascimento.Month == mesAniversario).ToList();
        Console.WriteLine("Treinadores aniversariantes:");
        if (treinadoresAniversariantes.Count > 0)
        {
            foreach (Treinador treinador in treinadoresAniversariantes)
            {
                treinador.imprimeTreinador();
            }
        }
        else Console.WriteLine("Nenhum treinador encontrado.");

        Console.WriteLine("Clientes aniversariantes:");
        if (clientesAniversariantes.Count > 0)
        {
            foreach (Cliente cliente in clientesAniversariantes)
            {
                cliente.imprimeCliente();
            }
        }
        else Console.WriteLine("Nenhum cliente encontrado.");
    }
    public void menuTreino()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("== Menu Treinos ==");
            Console.WriteLine("1. Cadastrar Treino");
            Console.WriteLine("2. Vincular Cliente a Treino");
            Console.WriteLine("3. Vincular Exercicio a Treino");
            Console.WriteLine("4. Adicionar avaliação");
            Console.WriteLine("5. Listar todos os Treinos");
            Console.WriteLine("6. Listar treinos por Cliente");
            Console.WriteLine("7. Listar treinos por Treinador");
            Console.WriteLine("8. Treinos em ordem crescente da data de vencimento");
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
                    listarTreinadores();
                    Console.Write("Escolha o ID do treinador responsável: ");
                    Treinador treinador;
                    try
                    {
                        int indexTreinador = int.Parse(Console.ReadLine() ?? "-1");
                        treinador = _treinadores[indexTreinador];
                    }
                    catch
                    {
                        Console.WriteLine("Treinador não encontrado");
                        App.pausa();
                        break;
                    }

                    try
                    {
                        Treino t1 = Treino.cadastrarTreino(treinador);
                        _treinos.Add(t1);
                        Console.WriteLine("Treino cadastrado com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Cadastro Cancelado! Realize a operacao novamente");
                        App.pausa();
                    }

                    break;
                case 2:
                    if (_treinos.Count == 0)
                    {
                        Console.WriteLine("Nenhum treino cadastrado");
                        App.pausa();
                        break;
                    }

                    if (_clientes.Count == 0)
                    {
                        Console.WriteLine("Nenhum cliente cadastrado");
                        App.pausa();
                        break;
                    }

                    listarClientes();
                    Console.Write("Escolha o ID do cliente: ");
                    Cliente cliente;
                    try
                    {
                        int indexCliente = int.Parse(Console.ReadLine() ?? "-1");
                        cliente = _clientes[indexCliente];
                    }
                    catch
                    {
                        Console.WriteLine("Cliente não encontrado");
                        App.pausa();
                        break;
                    }

                    if (_treinos.Count(t => t.Clientes?.Any(c => c?.Item1 == cliente) ?? false) >= 2)
                    {
                        Console.WriteLine("Cliente já faz parte de 2 treinos");
                        App.pausa();
                        break;
                    }

                    listarTreinos();
                    Console.Write("Escolha o ID do treino: ");
                    Treino treinoId;
                    try
                    {
                        int indexTreino = int.Parse(Console.ReadLine() ?? "-1");
                        treinoId = _treinos[indexTreino];
                    }
                    catch
                    {
                        Console.WriteLine("Treino não encontrado");
                        App.pausa();
                        break;
                    }

                    treinoId.adicionarCliente(cliente);
                    break;
                case 3:
                    listarExercicios();
                    Console.Write("Escolha o ID do exercicio: ");
                    Exercicio exercicio;
                    try
                    {
                        int indexExercicio = int.Parse(Console.ReadLine() ?? "-1");
                        exercicio = _exercicios[indexExercicio];
                    }
                    catch
                    {
                        Console.WriteLine("Exercicio não encontrado");
                        App.pausa();
                        break;
                    }

                    listarTreinos();
                    Console.Write("Escolha o ID do treino: ");
                    Treino treino2;
                    try
                    {
                        int indexTreino = int.Parse(Console.ReadLine() ?? "-1");
                        treino2 = _treinos[indexTreino];
                    }
                    catch
                    {
                        Console.WriteLine("Treino não encontrado");
                        App.pausa();
                        break;
                    }

                    if (treino2.tamanhoExercicios() >= 10)
                    {
                        Console.WriteLine("Treino já possui 10 exercícios");
                        App.pausa();
                        break;
                    }

                    treino2.adicionarExercicio(exercicio);
                    break;
                case 4:
                    listarClientes();
                    Console.Write("Escolha o ID do cliente que deseja inserir avaliação: ");
                    Cliente cliente1;
                    try
                    {
                        int indexCliente = int.Parse(Console.ReadLine() ?? "-1");
                        cliente1 = _clientes[indexCliente];
                    }
                    catch
                    {
                        Console.WriteLine("Cliente não encontrado");
                        App.pausa();
                        break;
                    }

                    if (_treinos.Any(t => t.Clientes?.Any(c => c?.Item1 == cliente1) ?? false))
                    {
                        Console.WriteLine("Cliente não faz parte de nenhum treino");
                        App.pausa();
                        break;
                    }

                    listarTreinosCliente(cliente1);
                    Console.Write("Escolha o ID do treino: ");
                    Treino treino1;
                    try
                    {
                        int indexTreino = int.Parse(Console.ReadLine() ?? "-1");
                        treino1 = _treinos[indexTreino];
                    }
                    catch
                    {
                        Console.WriteLine("Treino não encontrado");
                        App.pausa();
                        break;
                    }

                    if (!treino1.Clientes?.Any(c => c?.Item1 == cliente1) ?? false)
                    {
                        Console.WriteLine("Cliente não faz parte do treino");
                        App.pausa();
                        break;
                    }

                    Console.Write("Digite a avaliação: ");
                    try
                    {
                        int avaliacao = int.Parse(Console.ReadLine() ?? "-1");
                        if (avaliacao < 0 || avaliacao > 10) throw new Exception("Avaliação inválida");
                        treino1.adicionarAvaliacao(cliente1, avaliacao);
                    }
                    catch
                    {
                        Console.WriteLine("Avaliação inválida");
                        App.pausa();
                    }

                    break;
                case 5:
                    listarTreinos();
                    App.pausa();
                    break;
                case 6:
                    listarClientes();
                    Console.Write("Escolha o ID do cliente: ");
                    Cliente cliente2;
                    try
                    {
                        int indexCliente = int.Parse(Console.ReadLine() ?? "-1");
                        cliente2 = _clientes[indexCliente];
                    }
                    catch
                    {
                        Console.WriteLine("Cliente não encontrado");
                        App.pausa();
                        break;
                    }

                    listarTreinosCliente(cliente2);
                    App.pausa();
                    break;

                case 7:
                    listarTreinadores();
                    Console.Write("Escolha o ID do treinador: ");
                    Treinador treinador2;
                    try
                    {
                        int indexTreinador = int.Parse(Console.ReadLine() ?? "-1");
                        treinador2 = _treinadores[indexTreinador];
                    }
                    catch
                    {
                        Console.WriteLine("Treinador não encontrado");
                        App.pausa();
                        break;
                    }

                    listarTreinosTreinador(treinador2);
                    App.pausa();

                    break;

                case 8:
                    Console.Clear();
                    Console.WriteLine("Treinos em ordem crescente pela quantidade de dias até o vencimento");
                    List<Treino> treinoVencimento =
                        _treinos.OrderBy(t => t.Vencimento - (DateTime.Now - t.DataInicio).Days).ToList();
                    if (treinoVencimento.Count > 0)
                    {
                        foreach (Treino treino in treinoVencimento)
                        {
                            treino.imprimeTreino();
                        }
                    }
                    else Console.WriteLine("Nenhum treino encontrado.");

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
    public void listarTreinadores()
    {
        Console.Clear();
        Console.WriteLine("Lista de Treinadores:");
        Console.WriteLine("ID\tCPF\t\tCREF\t\tDATA DE NASCIMENTO\tNOME");
        for (int i = 0; i < _treinadores.Count; i++)
        {
            Console.Write($"{i}\t");
            _treinadores[i].imprimeTreinador();
        }

        Console.WriteLine();
    }
    public void listarClientes()
    {
        Console.Clear();
        Console.WriteLine("Lista de Clientes:");
        Console.WriteLine("ID\tCPF\t\tDATA DE NASCIMENTO\tALTURA\tPESO\tNOME");
        for (int i = 0; i < _clientes.Count; i++)
        {
            Console.Write($"{i}\t");
            _clientes[i].imprimeCliente();
        }

        Console.WriteLine();
    }
    public void listarTreinos()
    {
        Console.WriteLine($"ID\tTreinador\tClientes\tExercicios\tTipo\tObjetivo\tDuracao\tDataInicio\tVencimento");
        int i = 0;
        foreach (Treino treino in _treinos)
        {
            Console.WriteLine(
                $"{i}\t{treino.Treinador?.Nome}\t{treino.Clientes?.Count}\t{treino.tamanhoExercicios()}\t{treino.Tipo}\t{treino.Objetivo}\t{treino.Duracao}\t{treino.DataInicio}\t{treino.Vencimento}");
            i++;
        }
    }
    public void listarExercicios()
    {
        Console.Clear();
        Console.WriteLine("Lista de Exercício:");
        Console.WriteLine("ID\tGRUPO MUSCULAR\t\tSÉRIES\t\tREPETIÇÕES\tINTERVALO DE DESCANSO (s)");
        for (int i = 0; i < _exercicios.Count; i++)
        {
            Console.Write($"{i}\t");
            _exercicios[i].imprimeExercicio();
        }

        Console.WriteLine();
    }
    public void listarTreinosCliente(Cliente cliente)
    {
        Console.WriteLine($"Tipo\tObjetivo\tDuracao\tDataInicio\tVencimento\tTreinador");
        for (int i = 0; i < _treinos.Count; i++)
        {
            if (_treinos[i].Clientes?.Any(c => c?.Item1 == cliente) ?? false)
            {
                Console.Write($"{i}\t");
                _treinos[i].imprimeTreino();
            }

            _exercicios[i].imprimeExercicio();
        }

        Console.WriteLine();
    }
    public void listarTreinosTreinador(Treinador treinador)
    {
        Console.WriteLine("Tipo\tObjetivo\tDuracao\tDataInicio\tVencimento\tTreinador");
        foreach (Treino treino in _treinos)
        {
            if (treino.Treinador == treinador)
            {
                treino.imprimeTreino();
            }
        }
    }
}