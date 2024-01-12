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
        private int loginOption;
        private string passGerente;
        private string passRepositor;
        private string passCaixa;

        private static void Main(string[] args)
        {
            Program program = new Program();
            program.login();
        }

        private void login()
        {
            Console.WriteLine("Login as: ");
            Console.WriteLine("1• Gerente");
            Console.WriteLine("2• Repositor");
            Console.WriteLine("3• Caixa");
            loginOption = Convert.ToInt32(Console.ReadLine());

            if (loginOption == 1)
            {
                Console.WriteLine("Password: ");
                Console.WriteLine();
                passGerente = Console.ReadLine();

                if (passGerente == "gerente1")
                {
                    Console.WriteLine("Sessao inciada com sucesso");

                    Console.WriteLine("1• Consultar a informação de um livro a partir do código");
                    Gerente g = new Gerente();
                    g.checkTotalBooksSoldAndTotalRevenue();
                    Console.WriteLine("2• Listar os utilizadores");

                    Console.WriteLine("3• Adicionar funcionario");

                    Console.WriteLine("4• Remover funcionario");

                    Console.WriteLine("5• Vender livros");

                    Console.WriteLine("6• Consultar stock ");

                    Console.WriteLine("7• Consultar o total de livros vendidos e respetiva receita ");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Password incorreta");
                    Console.ReadLine();
                }
            }
            else if (loginOption == 2)
            {
                Console.WriteLine("Password: ");
                passRepositor = Console.ReadLine();

                if (passRepositor == "repositor1")
                {
                    Console.WriteLine("Sessao inciada com sucesso");

                    Console.WriteLine("1• Consultar a informação de um livro a partir do código");

                    Console.WriteLine("2• Mostrar os livros registados");

                    Console.WriteLine("2• Registar livros:");

                    Console.WriteLine("3• Atualizar livros");

                    Console.WriteLine("4• Comprar livros ");

                    Console.WriteLine("5• Consultar stock ");
                    string choose = Console.ReadLine();
                    switch (choose)
                    {
                        case "1":
                            Repositor repositor = new Repositor();
                            repositor.registBooks();
                            break;

                        case "2":
                            Repositor repositor1 = new Repositor();
                            repositor1.showRegistedBooks();
                            break;
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Password incorreta");
                    Console.WriteLine();
                }
            }
            else if (loginOption == 3)
            {
                Console.WriteLine("Password: ");
                passCaixa = Console.ReadLine();

                if (passCaixa == "caixa1")
                {
                    Console.WriteLine("Sessao inciada com sucesso");

                    Console.WriteLine("1• Consultar a informação de um livro a partir do código");

                    Console.WriteLine("2• vender livros");

                    Console.WriteLine("3• Consultar stock ");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Password incorreta");
                    Console.ReadLine();
                }
            }
        }
    }
}