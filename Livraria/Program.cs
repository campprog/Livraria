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
        private static void Main(string[] args)
        {
            Livraria livraria = new Livraria();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo a livraria");
                Console.WriteLine("1. Entrar na livraria");
                Console.WriteLine("2. Sair");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        livraria.login();
                        break;

                    case 2:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opcao invalida");
                        livraria.login();
                        break;
                }
                livraria.login();
            }
        }
    }
}