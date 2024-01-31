using System;
using System.Collections.Generic;

namespace Livraria
{
    public class Manager : Employee, IManagerECaixa
    {
        public Manager(string name, string username, string password) : base(name, username, password)
        {
        }

        public void addEmployee(List<Manager> managers, List<Stocker> stockers, List<Cashier> cashiers)
        {
            Console.WriteLine("Qual é o funcionario que deseja empregar: ");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Stocker");
            Console.WriteLine("3 Cashier");
            int option = askIntOption("Escolha a opcao: ");

            if (option == 1)
            {
                Console.WriteLine("Nome do Manager: ");
                string nameManager = Console.ReadLine();

                Console.WriteLine("Username do Usuario: ");
                string usernameManager = Console.ReadLine();

                Console.WriteLine("Password do Manager: ");
                string passManager = Console.ReadLine();

                Manager manager = new Manager(nameManager, usernameManager, passManager);
                managers.Add(manager);
                Console.Clear();
                Console.WriteLine("Manager adicionado.");
            }
            else if (option == 2)
            {
                Console.WriteLine("Nome do Stocker");
                string nameStockeres = Console.ReadLine();

                Console.WriteLine("Username do Stocker: ");
                string usernameStocker = Console.ReadLine();

                Console.WriteLine("Password do Stocker: ");
                string passStocker = Console.ReadLine();

                Stocker stocker = new Stocker(nameStockeres, usernameStocker, passStocker);
                stockers.Add(stocker);
                Console.Clear();
                Console.WriteLine("Stocker adicionado.");
            }
            else if (option == 3)
            {
                Console.WriteLine("Nome do Cashier");
                string nameCaixa = Console.ReadLine();

                Console.WriteLine("Username do Cashier: ");
                string usernameCaixa = Console.ReadLine();

                Console.WriteLine("Password do Cashier: ");
                string passCaixa = Console.ReadLine();

                Cashier cashier = new Cashier(nameCaixa, usernameCaixa, passCaixa);
                cashiers.Add(cashier);
                Console.Clear();
                Console.WriteLine("Cashier adicionado.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção invalida.");
            }
        }

        public void sellBooks(List<Book> livros)
        {
            Console.WriteLine("Deseja vender que livro");
            for (int i = 0; i < livros.Count; i++)
            {
                Console.WriteLine("{0}", livros[i].Title);
            }
            Console.WriteLine(" ");
            Console.Write("Esolha o livro: ");
            string option = Console.ReadLine();
            for (int i = 0; i < livros.Count; i++)
            {
                if (option == livros[i].Title)
                {
                    livros[i].Stock = livros[i].Stock - 1;
                    livros[i].Sold++;
                    Console.Clear();
                    Console.WriteLine("Livro vendido.");
                }
            }
        }

        public void checkTotalBooksSoldAndTotalRevenue(List<Book> livros)
        {
            int totalBooksSold = 0;
            double totalReceita = 0;
            foreach (Book item in livros)
            {
                totalBooksSold += item.Sold;
                totalReceita += item.Sold * (item.Price + (item.Price * (item.TaxIVA / 100)));
            }
            Console.Clear();
            Console.WriteLine("O total de livros vendidos foi de : {0}", totalBooksSold);
            Console.WriteLine("E o total de receita acumulado de todas as vendas foi de: {0}", totalReceita);
        }

        public void listEmployee(List<Manager> managers, List<Stocker> stockers, List<Cashier> cashiers)
        {
            Console.Clear();

            Console.WriteLine("Qual é os funcionarios que deseja listar: ");
            Console.WriteLine("1• Manager");
            Console.WriteLine("2• Stocker");
            Console.WriteLine("3• Cashier");
            int option = askIntOption("Escolha a opcao: ");

            if (option == 1)
            {
                if (managers.Count > 0)
                {
                    Console.WriteLine("Os managers da livraria são:");
                    for (int i = 0; i < managers.Count; i++)
                    {
                        Console.WriteLine("{0}", managers[i].Name);
                    }
                }
                else
                {
                    // applyColor(Console.WriteLine, "Nao tem managers para listar.", ConsoleColor.Red);
                    Console.WriteLine("Nao tem managers para listar.");
                }
            }
            else if (option == 2)
            {
                if (stockers.Count > 0)
                {
                    Console.WriteLine("Os stockers da livraria são: ");
                    for (int i = 0; i < stockers.Count; i++)
                    {
                        Console.WriteLine("{0}", stockers[i].Name);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Nao existe stockers para listar.");
                }
            }
            else if (option == 3)
            {
                if (cashiers.Count > 0)
                {
                    Console.WriteLine("Os cashiers da livraria são: ");
                    for (int i = 0; i < cashiers.Count; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("{0}", cashiers[i].Name);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Nao existe cashiers para listar.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção invalida");
            }
        }

        public void removeEmployee(List<Manager> managers, List<Stocker> stockers, List<Cashier> cashiers)
        {
            Console.Clear();
            Console.WriteLine("Escolha o tipo de funcionario que deseja despedir:");
            Console.WriteLine("1• Manager");
            Console.WriteLine("2• Stocker");
            Console.WriteLine("3• Cashier");
            int option = askIntOption("Escolha a opcao: ");
            if (option == 1)
            {
                Console.WriteLine("Estes sao todos os managers desta livraria que podera remover:");

                for (int i = 0; i < managers.Count; i++)
                {
                    Console.WriteLine("O funcionario {0}", managers[i].Name);
                }
                Console.WriteLine("Escolha o funcionario que deseja remover:");
                string optionManager = Console.ReadLine();
                for (int i = 0; i < managers.Count; i++)
                {
                    if (optionManager == managers[i].Name)
                    {
                        Console.WriteLine("O manager {0} foi removido", managers[i].Name);
                        managers.RemoveAt(i);
                        return;
                    }
                }

                Console.WriteLine("Manager inexistente.");
            }
            else if (option == 2)
            {
                Console.WriteLine("Estes sao todos os stockers desta livraria que podera remover:");

                for (int i = 0; i < stockers.Count; i++)
                {
                    Console.WriteLine("O funcionario {0} ", stockers[i].Name);
                }
                Console.WriteLine("Escolha o funcionario que deseja remover.");
                string optionStocker = Console.ReadLine();
                for (int i = 0; i < stockers.Count; i++)
                {
                    if (optionStocker == stockers[i].Name)
                    {
                        Console.WriteLine("O stocker {0} foi removido", stockers[i].Name);
                        stockers.RemoveAt(i);
                        return;
                    }
                }

                Console.WriteLine("Stocker inexistente.");
            }
            else if (option == 3)
            {
                Console.WriteLine("Estes sao todos os cashiers desta livraria que podera remover:");

                for (int i = 0; i < cashiers.Count; i++)
                {
                    Console.WriteLine("O funcionario {0}", cashiers[i].Name);
                }
                Console.WriteLine("Escolha o numero do funcionario que deseja remover.");
                string optionCaixa = Console.ReadLine();
                for (int i = 0; i < cashiers.Count; i++)
                {
                    if (optionCaixa == cashiers[i].Name)
                    {
                        Console.WriteLine("O cashier {0} foi removido", cashiers[i].Name);
                        cashiers.RemoveAt(i);
                        return;
                    }
                }

                Console.WriteLine("Cashier inexistente.");
            }
        }
    }
}