namespace AcademiaTF;

public class Academia
{
    // Construtores
    public Academia()
    {
        Treinos = new List<Treino>();
        Exercicios = new List<Exercicio>();
        Treinadores = new List<Treinador>();
        Clientes = new List<Cliente>();

        #region MetodosParaTeste

        criarTreinadores();
        criarClientes();
        criarExercicios();
        criarTreinos();

        #endregion
    }

    #region MetodosParaTeste

    //criando treinadores
    public void criarTreinadores()
    {
        Treinador t1 = new Treinador("João", new DateTime(1993, 10, 20), "12345678901", "123456-4/BA");
        Treinador t2 = new Treinador("Maria", new DateTime(1995, 8, 25), "12345678902", "123456-4/RJ");
        Treinador t3 = new Treinador("José", new DateTime(1991, 5, 11), "12345678903", "123456-4/AC");
        Treinador t4 = new Treinador("Ana", new DateTime(1989, 1, 7), "12345678904", "123456-4/PB");
        Treinador t5 = new Treinador("Pedro", new DateTime(1985, 2, 1), "12345678905", "123456-4/SP");
        Treinadores.Add(t1);
        Treinadores.Add(t2);
        Treinadores.Add(t3);
        Treinadores.Add(t4);
        Treinadores.Add(t5);
    }

    //criando clientes
    public void criarClientes()
    {
        Cliente c1 = new Cliente("Igor", new DateTime(2000, 12, 11), "98765432101", 185, 80);
        Cliente c2 = new Cliente("Lima", new DateTime(2001, 9, 5), "98765432102", 178, 65);
        Cliente c3 = new Cliente("Rocha", new DateTime(1997, 3, 31), "98765432103", 165, 80);
        Clientes.Add(c1);
        Clientes.Add(c2);
        Clientes.Add(c3);
    }

    //criando exercicios
    public void criarExercicios()
    {
        Exercicio e1 = new Exercicio("Pernas", 3, 20, 20);
        Exercicio e2 = new Exercicio("Braços", 2, 10, 35);
        Exercicio e3 = new Exercicio("Peito", 6, 15, 15);
        Exercicio e4 = new Exercicio("Costas", 4, 8, 40);
        Exercicio e5 = new Exercicio("Ombros", 2, 10, 12);
        Exercicio e6 = new Exercicio("Abdomen", 1, 5, 10);
        Exercicios.Add(e1);
        Exercicios.Add(e2);
        Exercicios.Add(e3);
        Exercicios.Add(e4);
        Exercicios.Add(e5);
        Exercicios.Add(e6);
    }

    public void criarTreinos()
    {
        Treino t1 = new Treino("Treino 1", "Perda peso", 30, new DateTime(2023, 12, 15), 5, Treinadores[0],
            Exercicios.Take(4).ToList());
        Treino t2 = new Treino("Treino 2", "Ganho de massa", 25, new DateTime(2023, 12, 20), 6, Treinadores[1],
            Exercicios.Take(4).ToList());
        Treino t3 = new Treino("Treino 3", "Fortalecimento", 35, new DateTime(2024, 1, 6), 7, Treinadores[2],
            Exercicios.Take(4).ToList());
        Treino t4 = new Treino("Treino 4", "Jogador", 50, new DateTime(2024, 2, 20), 8, Treinadores[3],
            Exercicios.Take(4).ToList());
        Treino t5 = new Treino("Treino 5", "Corrida", 45, new DateTime(2023, 12, 10), 4, Treinadores[4],
            Exercicios.Take(4).ToList());
        Treinos.Add(t1);
        Treinos.Add(t2);
        Treinos.Add(t3);
        Treinos.Add(t4);
        Treinos.Add(t5);
    }
    #endregion

    // Propriedades
    public List<Treino> Treinos { get; }

    public List<Exercicio> Exercicios { get; }

    public List<Treinador> Treinadores { get; }

    public List<Cliente> Clientes { get; }

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
                    List<Treinador> treinadoresFiltrados = Treinadores.Where(treinador =>
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
                    Console.Clear();
                    Console.WriteLine("Relatório de Treinadores em Ordem Decrescente da Média de Notas dos Treinos:");
                    try
                    {
                        var mediaTreinadores = Treinadores.Select(treinador =>
                        {
                            var treinosDoTreinador = Treinos.Where(treino =>
                                treino.Treinador == treinador && treino.MediaAvaliacoes() != -1);
                            double mediaNotas = treinosDoTreinador.Any()
                                ? treinosDoTreinador.Average(treino => treino.MediaAvaliacoes())
                                : -1;
                            return new { Treinador = treinador, MediaNotas = mediaNotas };
                        }).OrderByDescending(item => item.MediaNotas);

                        foreach (var item in mediaTreinadores)
                        {
                            Console.WriteLine(
                                $"Treinador: {item.Treinador.Nome}, Média de Notas: {(item.MediaNotas != -1 ? item.MediaNotas.ToString() : "N/A")}");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Nenhum treino vinculado ao treinador");
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
                        if (Treinadores.Any(t => t.Cpf == novoTreinador.Cpf))
                            throw new Exception("Treinador já cadastrado (CPF repetido)");
                        if (Treinadores.Any(t => t.Cref == novoTreinador.Cref))
                            throw new Exception("Treinador já cadastrado (CREF repetido)");
                        Treinadores.Add(novoTreinador);
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
                    foreach (Treinador treinador in Treinadores)
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
                        Treinador eTreinador = Treinadores.Find(treinador => treinador.Cpf == cpf) ??
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
                        Treinador rTreinador = Treinadores.Find(treinador => treinador.Cpf == cpf) ??
                                               throw new Exception("Treinador não encontrado");
                        Treinadores.Remove(rTreinador);
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
                    Console.Clear();
                    Console.WriteLine("Top 10 exercícios mais utilizados nos treinos");
                    if (Treinos.Count > 0)
                    {
                        var exerciciosMaisUtilizados = Treinos
                            .SelectMany(treino => treino.Exercicios!)
                            .GroupBy(exercicio => exercicio.GrupoMuscular)
                            .OrderByDescending(grupo => grupo.Count())
                            .Take(10)
                            .Select(grupo => grupo.Key);
                        foreach (var exercicio in exerciciosMaisUtilizados) Console.WriteLine(exercicio);
                    }
                    else Console.WriteLine("Nenhum treino criado");

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
                        Exercicios.Add(novoExercicio);
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
                    foreach (Exercicio exercicio in Exercicios)
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
                            Exercicios.Find(exercicio => exercicio.GrupoMuscular == grupoMuscular) ??
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
                            Exercicios.Find(exercicio => exercicio.GrupoMuscular == grupoMuscular) ??
                            throw new Exception("Treinador não encontrado");
                        Exercicios.Remove(rExercicio);
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
                    List<Cliente> clientesFiltrados = Clientes.Where(cliente =>
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
                    List<Cliente> clientesFiltrados2 = Clientes
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
                    List<Cliente> clientesOrdenados = Clientes.OrderBy(c => c.Nome).ToList();
                    foreach (Cliente cliente in clientesOrdenados) cliente.imprimeCliente();
                    App.pausa();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Clientes por Idade Descrescente:");
                    List<Cliente> clientesOrdenados2 = Clientes.OrderBy(c => c.Nascimento).ToList();
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
                        if (Clientes.Any(c => c.Cpf == novoCliente.Cpf))
                            throw new Exception("Cliente já cadastrado (CPF repetido)");
                        Clientes.Add(novoCliente);
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
                    foreach (Cliente cliente in Clientes)
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
                        Cliente eCliente = Clientes.Find(cliente => cliente.Cpf == cpf) ??
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
                        Cliente rCliente = Clientes.Find(cliente => cliente.Cpf == cpf) ??
                                           throw new Exception("Cliente não encontrado");
                        Clientes.Remove(rCliente);
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

        List<Treinador> treinadoresAniversariantes = Treinadores.Where(treinador =>
            treinador.Nascimento.Month == mesAniversario).ToList();
        List<Cliente> clientesAniversariantes = Clientes.Where(cliente =>
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

        App.pausa();
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
            Console.WriteLine("9. Treinos cujo objetivo contenham determinada palavra");
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
                    Console.Clear();
                    listarTreinadores();
                    Console.Write("Escolha o ID do treinador responsável: ");
                    Treinador treinador;
                    try
                    {
                        int indexTreinador = int.Parse(Console.ReadLine() ?? "-1");
                        treinador = Treinadores[indexTreinador];
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
                        Treinos.Add(t1);
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
                    Console.Clear();
                    if (Treinos.Count == 0)
                    {
                        Console.WriteLine("Nenhum treino cadastrado");
                        App.pausa();
                        break;
                    }

                    if (Clientes.Count == 0)
                    {
                        Console.WriteLine("Nenhum cliente cadastrado");
                        App.pausa();
                        break;
                    }

                    Console.Clear();
                    listarClientes();
                    Console.Write("Escolha o ID do cliente: ");
                    Cliente cliente;
                    try
                    {
                        int indexCliente = int.Parse(Console.ReadLine() ?? "-1");
                        cliente = Clientes[indexCliente];
                    }
                    catch
                    {
                        Console.WriteLine("Cliente não encontrado");
                        App.pausa();
                        break;
                    }

                    if (Treinos.Count(t => t.Clientes?.Any(c => c?.Item1 == cliente) ?? false) >= 2)
                    {
                        Console.WriteLine("Cliente já faz parte de 2 treinos");
                        App.pausa();
                        break;
                    }

                    Console.Clear();
                    listarTreinos();
                    Console.Write("Escolha o ID do treino: ");
                    Treino treinoId;
                    try
                    {
                        int indexTreino = int.Parse(Console.ReadLine() ?? "-1");
                        treinoId = Treinos[indexTreino];
                    }
                    catch
                    {
                        Console.WriteLine("Treino não encontrado");
                        App.pausa();
                        break;
                    }

                    treinoId.adicionarCliente(cliente);
                    App.pausa();
                    break;
                case 3:
                    Console.Clear();
                    listarExercicios();
                    Console.Write("Escolha o ID do exercicio: ");
                    Exercicio exercicio;
                    try
                    {
                        int indexExercicio = int.Parse(Console.ReadLine() ?? "-1");
                        exercicio = Exercicios[indexExercicio];
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
                        treino2 = Treinos[indexTreino];
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
                    Console.Clear();
                    listarClientes();
                    Console.Write("Escolha o ID do cliente que deseja inserir avaliação: ");
                    Cliente cliente1;
                    try
                    {
                        int indexCliente = int.Parse(Console.ReadLine() ?? "-1");
                        cliente1 = Clientes[indexCliente];
                    }
                    catch
                    {
                        Console.WriteLine("Cliente não encontrado");
                        App.pausa();
                        break;
                    }

                    if (!Treinos.Any(t => t.Clientes?.Any(c => c?.Item1 == cliente1) ?? false))
                    {
                        Console.WriteLine("Cliente não faz parte de nenhum treino");
                        App.pausa();
                        break;
                    }

                    Console.Clear();
                    listarTreinosCliente(cliente1);
                    Console.Write("Escolha o ID do treino: ");
                    Treino treino1;
                    try
                    {
                        int indexTreino = int.Parse(Console.ReadLine() ?? "-1");
                        treino1 = Treinos[indexTreino];
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

                    App.pausa();
                    break;
                case 5:
                    Console.Clear();
                    listarTreinos();
                    App.pausa();
                    break;
                case 6:
                    Console.Clear();
                    listarClientes();
                    Console.Write("Escolha o ID do cliente: ");
                    Cliente cliente2;
                    try
                    {
                        int indexCliente = int.Parse(Console.ReadLine() ?? "-1");
                        cliente2 = Clientes[indexCliente];
                    }
                    catch
                    {
                        Console.WriteLine("Cliente não encontrado");
                        App.pausa();
                        break;
                    }
                    Console.Clear();
                    listarTreinosCliente(cliente2);
                    App.pausa();
                    break;
                case 7:
                    Console.Clear();
                    listarTreinadores();
                    Console.Write("Escolha o ID do treinador: ");
                    Treinador treinador2;
                    try
                    {
                        int indexTreinador = int.Parse(Console.ReadLine() ?? "-1");
                        treinador2 = Treinadores[indexTreinador];
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
                        Treinos.OrderBy(t => t.Vencimento - (DateTime.Now - t.DataInicio).Days).ToList();
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
                case 9:
                    Console.Clear();
                    Console.WriteLine("Treinos cujo objetivo contenham determinada palavra:");
                    Console.Write("Palavra: ");
                    string? palavra = Console.ReadLine();
                    List<Treino> treinoPalavra =
                        Treinos.Where(t => t.Objetivo!.Contains(palavra ?? string.Empty)).ToList();
                    if (treinoPalavra.Count > 0)
                    {
                        foreach (Treino treino in treinoPalavra)
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
        for (int i = 0; i < Treinadores.Count; i++)
        {
            Console.Write($"{i}\t");
            Treinadores[i].imprimeTreinador();
        }

        Console.WriteLine();
    }

    public void listarClientes()
    {
        Console.Clear();
        Console.WriteLine("Lista de Clientes:");
        Console.WriteLine("ID\tCPF\t\tDATA DE NASCIMENTO\tALTURA\tPESO\tNOME");
        for (int i = 0; i < Clientes.Count; i++)
        {
            Console.Write($"{i}\t");
            Clientes[i].imprimeCliente();
        }

        Console.WriteLine();
    }

    public void listarTreinos()
    {
        Console.WriteLine("ID\tTreinador\tClientes\tExercicios\tTipo\tObjetivo\tDuracao\tDataInicio\tVencimento");
        int i = 0;
        foreach (Treino treino in Treinos)
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
        for (int i = 0; i < Exercicios.Count; i++)
        {
            Console.Write($"{i}\t");
            Exercicios[i].imprimeExercicio();
        }

        Console.WriteLine();
    }

    public void listarTreinosCliente(Cliente cliente)
    {
        Console.WriteLine("Lista de Treinos:");
        Console.WriteLine($"Tipo\tObjetivo\tDuracao\tDataInicio\tVencimento\tTreinador");
        for (int i = 0; i < Treinos.Count; i++)
        {
            if (Treinos[i].Clientes?.Any(c => c?.Item1 == cliente) ?? false)
            {
                Console.Write($"{i}\t");
                Treinos[i].imprimeTreino();
            }
            Exercicios[i].imprimeExercicio();
        }
        Console.WriteLine();
    }

    public void listarTreinosTreinador(Treinador treinador)
    {
        Console.Clear();
        Console.WriteLine("Lista de Treinos:");
        foreach (Treino treino in Treinos)
        {
            if (treino.Treinador == treinador)
            {
                treino.imprimeTreino();
            }
        }
    }
}