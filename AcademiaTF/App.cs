namespace AcademiaTF;

public class App
{
    public static void Main()
    {
        Academia academia = new();
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("Menu da Academia:");
            Console.WriteLine("1. Treinadores");
            Console.WriteLine("2. Clientes");
            Console.WriteLine("3. Exercícios");
            Console.WriteLine("4. Treinadores e clientes aniversariantes");
            Console.WriteLine("0. Sair");
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
                    academia.menuTreinador();
                    break;
                case 2:
                    academia.menuCliente();
                    break;
                case 3:
                    academia.menuExercicio();
                    break;
                case 4:
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
                            treinador.imprimeCliente();
                        }
                    }
                    else Console.WriteLine("Nenhum cliente encontrado.");
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Encerrando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    pausa();
                    break;
            }
        } while (opcao != 0);
    }

    public static void pausa()
    {
        Console.Write("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}