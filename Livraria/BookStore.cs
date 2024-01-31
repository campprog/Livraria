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
    internal class BookStore
    {
        private List<Book> livros = new List<Book>
        {
                // Add instances of Livro to the list
                new Book(1, "Book 1", "Tiago Pereira", "ISBN123", "Romance", 29.99, 0.05, 50),
                new Book(2, "Book 2", "Pedro Pinheiro", "ISBN456", "Drama", 39.99, 0.08, 30),
                new Book(3, "Book 3", "Tiago Pereira", "ISBN789", "Drama", 19.99, 0.03, 70),
                new Book(4, "Book 4", "Pedro Pinheiro", "ISBN782", "Drama", 59.99, 0.03, 70),
        };

        private List<Manager> managers = new List<Manager>
        {
            new Manager("Tiago","userTiago", "tiago123"),
            new Manager("Pedro","userPedro", "pedro123")
        };

        private List<Stocker> stockers = new List<Stocker>
        {
            new Stocker("Fernando","userFernando", "fernando123")
        };

        private List<Cashier> cashiers = new List<Cashier>
        {
            new Cashier("Dino","userDino", "dino123")
        };

        //fazer as exeptions

        //meter o login com melhor aspeto

        //meter a cashier a vermelho quando da resposta invalida
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

        private Manager findManager(string username, string password)
        {
            foreach (var manager in managers)
            {
                if (manager.Username == username && manager.Password == password)
                {
                    return manager;
                }
            }
            return null;
        }

        private Stocker findStocker(string username, string password)
        {
            foreach (var stocker in stockers)
            {
                if (stocker.Username == username && stocker.Password == password)
                {
                    return stocker;
                }
            }
            return null;
        }

        private Cashier findCashier(string username, string password)
        {
            foreach (var cashier in cashiers)
            {
                if (cashier.Username == username && cashier.Password == password)
                {
                    return cashier;
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

            Manager manager = findManager(username, password);
            Stocker stocker = findStocker(username, password);
            Cashier cashier = findCashier(username, password);
            if (manager != null)
            {
                Console.Write("Bem-Vindo {0}", manager.Name);
                managerMenu(manager);
            }
            else if (stocker != null)
            {
                Console.WriteLine("Bem-Vindo {0}", stocker.Name);
                stockerMenu(stocker);
            }
            else if (cashier != null)
            {
                Console.WriteLine("Bem-Vindo {0}", cashier.Name);
                caixaMenu(cashier);
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
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Stocker");
            Console.WriteLine("3. Cashier");
            Console.WriteLine("4. Voltar ao inicio");

            int loginOption = askIntOption("Escolha a sua opcao: ");
            if (loginOption == 1)
            {
                Console.Clear();
                Console.WriteLine("Lista de todos os manager:");
                for (int i = 0; i < managers.Count; i++)
                {
                    Console.WriteLine("{0}, {1}", i + 1, managers[i].Name);
                }

                int option = askIntOption("Escolha a sua opcao: ");
                for (int i = 0; i < managers.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.Write("Digite o username:");
                        string userManager = Console.ReadLine();

                        Console.Write("Digite a password:");
                        string passManager = GetPassword();

                        Manager manager = findManager(userManager, passManager);
                        Console.Clear();
                        if (manager != null)
                        {
                            Console.WriteLine("Bem-vindo Manager:{0}", userManager);
                            managerMenu(managers[i]);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Username ou Password errados");
                        }
                    }
                }

                Console.WriteLine("Nao existe nenhum manager com essa opcao");
            }
            else if (loginOption == 2)
            {
                Console.Clear();
                Console.WriteLine("Lista de todos os stocker: ");
                for (int i = 0; i < stockers.Count; i++)
                {
                    Console.WriteLine("{0} {1}", i + 1, stockers[i].Name);
                }
                int option = askIntOption("Escolha a sua opcao: ");
                for (int i = 0; i < stockers.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.Write("Digite o Username: ");
                        string userStocker = Console.ReadLine();
                        Console.Write("Digite a password: ");
                        string passStocker = GetPassword();

                        Stocker stocker = findStocker(userStocker, passStocker);
                        Console.Clear();
                        if (stocker != null)
                        {
                            Console.WriteLine("Bem-vindo Stocker:{0}", userStocker);
                            stockerMenu(stockers[i]);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Username ou Password incorreta.");
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Nao existe nenhum stocker com essa opcao");
            }
            else if (loginOption == 3)
            {
                for (int i = 0; i < cashiers.Count; i++)
                {
                    Console.Clear();
                    Console.WriteLine("Lista de todos os caixista: ");
                    Console.WriteLine("{0} {1}", i + 1, cashiers[i].Name);
                }
                int option = askIntOption("Escolha a sua opcao: ");

                for (int i = 0; i < cashiers.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.Write("Digite o username: ");
                        string userCaixa = Console.ReadLine();
                        Console.Write("Digite a password: ");
                        string passCaixa = GetPassword();

                        Cashier cashier = findCashier(userCaixa, passCaixa);

                        if (cashier != null)
                        {
                            caixaMenu(cashiers[i]);
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
                Console.WriteLine("Nao existe nenhum cashier com essa opcao");
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

        public void managerMenu(Manager manager) //passa-se manager que fiz login
        {
            while (true)
            {
                Console.WriteLine("\n Menu Manager:");

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

                        manager.checkOnInfoFromBookWithCode(livros);

                        break;

                    case 2:
                        manager.checkStock(livros);

                        break;

                    case 3:
                        manager.addEmployee(managers, stockers, cashiers);

                        break;

                    case 4:
                        manager.removeEmployee(managers, stockers, cashiers);

                        break;

                    case 5:
                        manager.listEmployee(managers, stockers, cashiers);

                        break;

                    case 6:
                        manager.sellBooks(livros);

                        break;

                    case 7:
                        manager.checkTotalBooksSoldAndTotalRevenue(livros);

                        break;

                    case 8:
                        return;

                    default:
                        Console.WriteLine("Opcao invalida.");
                        break;
                }
            }
        }

        public void stockerMenu(Stocker stocker)
        {
            while (true)
            {
                Console.WriteLine("\n Menu Stocker:");

                Console.WriteLine("1. Consultar a informação de um livro a partir do código");

                Console.WriteLine("2. Mostrar os livros registados");

                Console.WriteLine("3. Registar livros");

                Console.WriteLine("4. Consultar livros pelo genre");

                Console.WriteLine("5. Consultar livros pelo author");

                Console.WriteLine("6. Atualizar livros");

                Console.WriteLine("7. Comprar livros ");

                Console.WriteLine("8. Consultar stock ");

                Console.WriteLine("9. Voltar para o menu inicial");

                int option = askIntOption("Escolha a sua opcao: ");

                switch (option)
                {
                    case 1:
                        stocker.checkOnInfoFromBookWithCode(livros);

                        break;

                    case 2:
                        stocker.showRegistedBooks(livros);

                        break;

                    case 3:
                        stocker.registBooks(livros);

                        break;

                    case 4:
                        stocker.listBooksbyGenre(livros);

                        break;

                    case 5:
                        stocker.listBooksByAuthor(livros);

                        break;

                    case 6:
                        stocker.updateBooks(livros);

                        break;

                    case 7:
                        stocker.buyBooks(livros);

                        break;

                    case 8:
                        stocker.checkStock(livros);

                        break;

                    case 9:
                        return;

                    default:
                        Console.WriteLine("Opcao invalida.");
                        break;
                }
            }
        }

        public void caixaMenu(Cashier cashier)
        {
            while (true)
            {
                Console.WriteLine("\nMenu Cashier:");

                Console.WriteLine("1. Consultar a informação de um livro a partir do código");

                Console.WriteLine("2. vender livros");

                Console.WriteLine("3. Consultar stock ");

                Console.WriteLine("4. Voltar para o menu inicial ");

                int option = askIntOption("Escolha a sua opcao: ");
                switch (option)
                {
                    case 1:
                        cashier.checkOnInfoFromBookWithCode(livros);

                        break;

                    case 2:
                        cashier.sellBooks(livros);

                        break;

                    case 3:
                        cashier.checkStock(livros);

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