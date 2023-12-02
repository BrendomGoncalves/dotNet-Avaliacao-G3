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
            Console.WriteLine("0. Sair");
            Console.Write("> ");
            opcao = int.Parse(Console.ReadLine() ?? "0");

            switch (opcao)
            {
                case 1:
                    academia.menuTreinador();
                    break;
                case 2:
                    // academia.menuCliente();
                    pausa();
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