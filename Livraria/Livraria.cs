using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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
                new Livro(1, "Book 1", "Tiago Pereira", "ISBN123", "Romance", 29.99, 0.05, 50),
                new Livro(2, "Book 2", "Pedro Pinheiro", "ISBN456", "Drama", 39.99, 0.08, 30),
                new Livro(3, "Book 3", "Tiago Pereira", "ISBN789", "Drama", 19.99, 0.03, 70),
                new Livro(4, "Book 4", "Pedro Pinheiro", "ISBN782", "Drama", 59.99, 0.03, 70),
        };

        private List<Gerente> gerentes = new List<Gerente>
        {
            new Gerente("Tiago","userTiago", "tiago123"),
            new Gerente("Pedro","userPedro", "pedro123")
        };

        private List<Repositor> repositores = new List<Repositor>
        {
            new Repositor("Fernando","userFernando", "fernando123")
        };

        private List<Caixa> caixas = new List<Caixa>
        {
            new Caixa("Dino","UserDino", "dino123")
        };

        //fazer as exeptions

        //meter o login com melhor aspeto

        //meter a caixa a vermelho quando da resposta invalida
        //fazer o try and catch proprio para a livraria

        //perguntar qual sera melhor o menu principal
        private static string GetPassword()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Ignore any non-character keys (e.g., Enter, Tab)
                if (char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar) || char.IsPunctuation(key.KeyChar))
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Length--;
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            return password.ToString();
        }

        public int askIntOption(string message)
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

        private Gerente findGerente(string username, string password)
        {
            foreach (var gerente in gerentes)
            {
                if (gerente.Username == username && gerente.Password == password)
                {
                    return gerente;
                }
            }
            return null;
        }

        private Repositor findRepositor(string username, string password)
        {
            foreach (var repositor in repositores)
            {
                if (repositor.Username == username && repositor.Password == password)
                {
                    return repositor;
                }
            }
            return null;
        }

        private Caixa findCaixa(string username, string password)
        {
            foreach (var caixa in caixas)
            {
                if (caixa.Username == username && caixa.Password == password)
                {
                    return caixa;
                }
            }
            return null;
        }

        public void Loginn()
        {
            Console.Clear();
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = GetPassword();

            Console.WriteLine("");

            Gerente gerente = findGerente(username, password);
            Repositor repositor = findRepositor(username, password);
            Caixa caixa = findCaixa(username, password);
            if (gerente != null)
            {
                Console.Write("Bem-Vindo {0}", gerente.Name);
                gerenteMenu(gerente);
            }
            else if (repositor != null)
            {
                Console.WriteLine("Bem-Vindo {0}", repositor.Name);
                repositorMenu(repositor);
            }
            else if (caixa != null)
            {
                Console.WriteLine("Bem-Vindo {0}", caixa.Name);
                caixaMenu(caixa);
            }
            else
            {
                Console.WriteLine("Opcao invalida.");
            }
        }

        /*
        public void login()
        {
            //Console.Clear();
            Console.WriteLine("Login as: ");
            Console.WriteLine("1. Gerente");
            Console.WriteLine("2. Repositor");
            Console.WriteLine("3. Caixa");
            Console.WriteLine("4. Voltar ao inicio");

            int loginOption = askIntOption("Escolha a sua opcao: ");
            if (loginOption == 1)
            {
                Console.Clear();
                Console.WriteLine("Lista de todos os gerente:");
                for (int i = 0; i < gerentes.Count; i++)
                {
                    Console.WriteLine("{0}, {1}", i + 1, gerentes[i].Name);
                }

                int option = askIntOption("Escolha a sua opcao: ");
                for (int i = 0; i < gerentes.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.Write("Digite o username:");
                        string userGerente = Console.ReadLine();

                        Console.Write("Digite a password:");
                        string passGerente = GetPassword();

                        Gerente gerente = findGerente(userGerente, passGerente);
                        Console.Clear();
                        if (gerente != null)
                        {
                            Console.WriteLine("Bem-vindo Gerente:{0}", userGerente);
                            gerenteMenu(gerentes[i]);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Username ou Password errados");
                        }
                    }
                }

                Console.WriteLine("Nao existe nenhum gerente com essa opcao");
            }
            else if (loginOption == 2)
            {
                Console.Clear();
                Console.WriteLine("Lista de todos os repositor: ");
                for (int i = 0; i < repositores.Count; i++)
                {
                    Console.WriteLine("{0} {1}", i + 1, repositores[i].Name);
                }
                int option = askIntOption("Escolha a sua opcao: ");
                for (int i = 0; i < repositores.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.Write("Digite o Username: ");
                        string userRepositor = Console.ReadLine();
                        Console.Write("Digite a password: ");
                        string passRepositor = GetPassword();

                        Repositor repositor = findRepositor(userRepositor, passRepositor);
                        Console.Clear();
                        if (repositor != null)
                        {
                            Console.WriteLine("Bem-vindo Repositor:{0}", userRepositor);
                            repositorMenu(repositores[i]);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Username ou Password incorreta.");
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Nao existe nenhum repositor com essa opcao");
            }
            else if (loginOption == 3)
            {
                for (int i = 0; i < caixas.Count; i++)
                {
                    Console.Clear();
                    Console.WriteLine("Lista de todos os caixista: ");
                    Console.WriteLine("{0} {1}", i + 1, caixas[i].Name);
                }
                int option = askIntOption("Escolha a sua opcao: ");

                for (int i = 0; i < caixas.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.Write("Digite o username: ");
                        string userCaixa = Console.ReadLine();
                        Console.Write("Digite a password: ");
                        string passCaixa = GetPassword();

                        Caixa caixa = findCaixa(userCaixa, passCaixa);

                        if (caixa != null)
                        {
                            caixaMenu(caixas[i]);
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Password incorreta");
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Nao existe nenhum caixa com essa opcao");
            }
            else if (loginOption == 4)
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opcao invalida.");
                login();
            }
        }
        */

        public void gerenteMenu(Gerente gerente) //passa-se gerente que fiz login
        {
            while (true)
            {
                Console.WriteLine("\n Menu Gerente:");

                Console.WriteLine("1. Consultar a informação de um livro a partir do código");

                Console.WriteLine("2. Consultar stock");

                Console.WriteLine("3. Adicionar funcionario");

                Console.WriteLine("4. Remover funcionario");

                Console.WriteLine("5. Listar os utilizadores");

                Console.WriteLine("6. Vender livros ");

                Console.WriteLine("7. Consultar o total de livros vendidos e respetiva receita ");

                Console.WriteLine("8. Voltar para o menu inicial ");

                int option = askIntOption("Escolha a sua opcao: ");
                switch (option)
                {
                    case 1:

                        gerente.checkOnInfoFromBookWithCode(livros);

                        break;

                    case 2:
                        gerente.checkStock(livros);

                        break;

                    case 3:
                        gerente.addEmployee(gerentes, repositores, caixas);

                        break;

                    case 4:
                        gerente.removeEmployee(gerentes, repositores, caixas);

                        break;

                    case 5:
                        gerente.listEmployee(gerentes, repositores, caixas);

                        break;

                    case 6:
                        gerente.sellBooks(livros);

                        break;

                    case 7:
                        gerente.checkTotalBooksSoldAndTotalRevenue(livros);

                        break;

                    case 8:
                        return;

                    default:
                        Console.WriteLine("Opcao invalida.");
                        break;
                }
            }
        }

        public void repositorMenu(Repositor repositor)
        {
            while (true)
            {
                Console.WriteLine("\n Menu Repositor:");

                Console.WriteLine("1. Consultar a informação de um livro a partir do código");

                Console.WriteLine("2. Mostrar os livros registados");

                Console.WriteLine("3. Registar livros");

                Console.WriteLine("4. Consultar livros pelo genero");

                Console.WriteLine("5. Consultar livros pelo autor");

                Console.WriteLine("6. Atualizar livros");

                Console.WriteLine("7. Comprar livros ");

                Console.WriteLine("8. Consultar stock ");

                Console.WriteLine("9. Voltar para o menu inicial");

                int option = askIntOption("Escolha a sua opcao: ");

                switch (option)
                {
                    case 1:
                        repositor.checkOnInfoFromBookWithCode(livros);

                        break;

                    case 2:
                        repositor.showRegistedBooks(livros);

                        break;

                    case 3:
                        repositor.registBooks(livros);

                        break;

                    case 4:
                        repositor.listBooksbyGenre(livros);

                        break;

                    case 5:
                        repositor.listBooksByAuthor(livros);

                        break;

                    case 6:
                        repositor.updateBooks(livros);

                        break;

                    case 7:
                        repositor.buyBooks(livros);

                        break;

                    case 8:
                        repositor.checkStock(livros);

                        break;

                    case 9:
                        return;

                    default:
                        Console.WriteLine("Opcao invalida.");
                        break;
                }
            }
        }

        public void caixaMenu(Caixa caixa)
        {
            while (true)
            {
                Console.WriteLine("\nMenu Caixa:");

                Console.WriteLine("1. Consultar a informação de um livro a partir do código");

                Console.WriteLine("2. vender livros");

                Console.WriteLine("3. Consultar stock ");

                Console.WriteLine("4. Voltar para o menu inicial ");

                int option = askIntOption("Escolha a sua opcao: ");
                switch (option)
                {
                    case 1:
                        caixa.checkOnInfoFromBookWithCode(livros);

                        break;

                    case 2:
                        caixa.sellBooks(livros);

                        break;

                    case 3:
                        caixa.checkStock(livros);

                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Opcao invalida.");
                        break;
                }
            }
        }
    }
}