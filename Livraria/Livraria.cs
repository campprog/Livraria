using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Livraria
{
    internal class Livraria
    {
        private List<Livro> livros = new List<Livro>
        {
                // Add instances of Livro to the list
                new Livro(1, "Book 1", "Author 1", "ISBN123", "Genre 1", 29.99, 0.05, 50),
                new Livro(2, "Book 2", "Author 2", "ISBN456", "Genre 2", 39.99, 0.08, 30),
                new Livro(3, "Book 3", "Author 3", "ISBN789", "Genre 3", 19.99, 0.03, 70)
        };

        private List<Gerente> gerentes = new List<Gerente>
        {
            new Gerente("Tiago", "tiago123")
        };

        private List<Repositor> repositores = new List<Repositor>
        {
            new Repositor("Fernando", "fernando123")
        };

        private List<Caixa> caixistas = new List<Caixa>
        {
            new Caixa("dionisio", "dionisio123")
        };

        public void login()
        {
            Console.WriteLine("Login as: ");
            Console.WriteLine("1• Gerente");
            Console.WriteLine("2• Repositor");
            Console.WriteLine("3• Caixa");
            int loginOption = Convert.ToInt32(Console.ReadLine());
            if (loginOption == 1)
            {
                for (int i = 0; i < gerentes.Count; i++)
                {
                    Console.WriteLine("Escolha o gerente:");
                    Console.WriteLine("{0} {1}", i + 1, gerentes[i].Name);
                }
                int option = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < gerentes.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.WriteLine("Digite a password:");
                        string passGerente = Console.ReadLine();
                        if (passGerente == gerentes[i].Password)
                        {
                            gerente();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Password errada");
                            login();
                        }
                    }
                }
                Console.WriteLine("Nao existe nenhum gerente com essa opcao");
                login();
            }
            else if (loginOption == 2)
            {
                for (int i = 0; i < repositores.Count; i++)
                {
                    Console.WriteLine("Escolha o repositor: ");
                    Console.WriteLine("{0} {1}", i + 1, repositores[i].Name);
                }
                int option = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < repositores.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.WriteLine("Digite a password: ");
                        string passRepositor = Console.ReadLine();
                        if (passRepositor == repositores[i].Password)
                        {
                            repositor();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Password incorreta.");
                            login();
                        }
                    }
                }
                Console.WriteLine("Nao existe nenhum repositor com essa opcao");
                login();
            }
            else if (loginOption == 3)
            {
                for (int i = 0; i < caixistas.Count; i++)
                {
                    Console.WriteLine("Escolha o caixista: ");
                    Console.WriteLine("{0} {1}", i + 1, caixistas[i].Name);
                }
                int option = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < caixistas.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.WriteLine("Digite a password: ");
                        string passCaixa = Console.ReadLine();
                        if (passCaixa == caixistas[i].Password)
                        {
                            caixa();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Password incorreta");
                            login();
                        }
                    }
                }
                Console.WriteLine("Nao existe nenhum caixa com essa opcao");
                login();
            }
        }

        public void gerente()
        {
            Console.WriteLine("Sessao inciada com sucesso");

            Console.WriteLine("1• Consultar a informação de um livro a partir do código");

            Console.WriteLine("2• Listar os utilizadores");

            Console.WriteLine("3• Adicionar funcionario");

            Console.WriteLine("4• Remover funcionario");

            Console.WriteLine("5• Vender livros");

            Console.WriteLine("6• Consultar stock ");

            Console.WriteLine("7• Consultar o total de livros vendidos e respetiva receita ");

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:

                    break;
            }
        }

        public void repositor()
        {
            Console.WriteLine("Sessao inciada com sucesso");

            Console.WriteLine("1• Consultar a informação de um livro a partir do código");

            Console.WriteLine("2• Mostrar os livros registados");

            Console.WriteLine("3• Registar livros:");

            Console.WriteLine("4• Atualizar livros");

            Console.WriteLine("5• Comprar livros ");

            Console.WriteLine("6• Consultar stock ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:

                    login();
                    break;

                case 2:

                    login();
                    break;
            }
        }

        public void caixa()
        {
            Console.WriteLine("Sessao inciada com sucesso");

            Console.WriteLine("1• Consultar a informação de um livro a partir do código");

            Console.WriteLine("2• vender livros");

            Console.WriteLine("3• Consultar stock ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:

                    break;
            }
        }
    }
}