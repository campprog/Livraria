using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Program
    {
        //alterar a cena default do switch
        //meter o try and catch proprio para aqui

        private static void Main(string[] args)
        {
            int askIntOption(string message)
            {
                int option = -1;
                bool isValidOption = false;
                do
                {
                    Console.Write(message);

                    try
                    {
                        option = Convert.ToInt32(Console.ReadLine());
                        isValidOption = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Opcao invalida");
                    }
                } while (!isValidOption);
                return option;
            }

            BookStore livraria = new BookStore();
            while (true)
            {
                //
                Console.WriteLine("Bem-vindo a livraria");
                Console.WriteLine("1. Entrar na livraria");
                Console.WriteLine("2. Sair");
                int option = askIntOption("Escolha a sua opcao: ");
                switch (option)
                {
                    case 1:

                        livraria.Loginn();
                        break;

                    case 2:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opcao invalida");
                        break;
                }
                //livraria.login();
            }
        }
    }
}