using System;
using System.Collections.Generic;

namespace Livraria
{
    public class Gerente : Funcionario, IGerenteECaixa
    {
        public Gerente(string name, string username, string password) : base(name, username, password)
        {
        }

        private static void ApplyColor(Action<string> printFunction, string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            printFunction(message);
            Console.ForegroundColor = originalColor;
        }

        public void addEmployee(List<Gerente> gerentes, List<Repositor> repositores, List<Caixa> caixas)
        {
            Console.WriteLine("Qual é o funcionario que deseja empregar: ");
            Console.WriteLine("1. Gerente");
            Console.WriteLine("2. Repositor");
            Console.WriteLine("3 Caixa");
            int option = askIntOption("Escolha a opcao: ");

            if (option == 1)
            {
                Console.WriteLine("Nome do Gerente: ");
                string nomeGerente = Console.ReadLine();

                Console.WriteLine("Username do Usuario: ");
                string usernameGerente = Console.ReadLine();

                Console.WriteLine("Password do Gerente: ");
                string passGerente = Console.ReadLine();

                Gerente gerente = new Gerente(nomeGerente, usernameGerente, passGerente);
                gerentes.Add(gerente);
                Console.Clear();
                Console.WriteLine("Gerente adicionado.");
            }
            else if (option == 2)
            {
                Console.WriteLine("Nome do Repositor");
                string nomeRepositores = Console.ReadLine();

                Console.WriteLine("Username do Repositor: ");
                string usernameRepositor = Console.ReadLine();

                Console.WriteLine("Password do Repositor: ");
                string passRepositor = Console.ReadLine();

                Repositor repositor = new Repositor(nomeRepositores, usernameRepositor, passRepositor);
                repositores.Add(repositor);
                Console.Clear();
                Console.WriteLine("Repositor adicionado.");
            }
            else if (option == 3)
            {
                Console.WriteLine("Nome do Caixa");
                string nomeCaixa = Console.ReadLine();

                Console.WriteLine("Username do Caixa: ");
                string usernameCaixa = Console.ReadLine();

                Console.WriteLine("Password do Caixa: ");
                string passCaixa = Console.ReadLine();

                Caixa caixa = new Caixa(nomeCaixa, usernameCaixa, passCaixa);
                caixas.Add(caixa);
                Console.Clear();
                Console.WriteLine("Caixa adicionado.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção invalida.");
            }
        }

        public void sellBooks(List<Livro> livros)
        {
            Console.WriteLine("Deseja vender que livro");
            for (int i = 0; i < livros.Count; i++)
            {
                Console.WriteLine("{0}", livros[i].Titulo);
            }
            string option = Console.ReadLine();
            for (int i = 0; i < livros.Count; i++)
            {
                if (option == livros[i].Titulo)
                {
                    livros[i].Stock = livros[i].Stock - 1;
                    livros[i].Sold++;
                    Console.Clear();
                    Console.WriteLine("Livro vendido.");
                }
            }
        }

        public void checkTotalBooksSoldAndTotalRevenue(List<Livro> livros)
        {
            int totalBooksSold = 0;
            double totalReceita = 0;
            foreach (Livro item in livros)
            {
                totalBooksSold += item.Sold;
                totalReceita += item.Sold * (item.Preco + (item.Preco * (item.TaxaIVA / 100)));
            }
            Console.Clear();
            Console.WriteLine("O total de livros vendidos foi de : {0}", totalBooksSold);
            Console.WriteLine("E o total de receita acumulado de todas as vendas foi de: {0}", totalReceita);
        }

        public void listEmployee(List<Gerente> gerentes, List<Repositor> repositores, List<Caixa> caixas)
        {
            Console.Clear();

            Console.WriteLine("Qual é os funcionarios que deseja listar: ");
            Console.WriteLine("1• Gerente");
            Console.WriteLine("2• Repositor");
            Console.WriteLine("3• Caixa");
            int option = askIntOption("Escolha a opcao: ");

            if (option == 1)
            {
                if (gerentes.Count > 0)
                {
                    Console.WriteLine("Os gerentes da livraria são:");
                    for (int i = 0; i < gerentes.Count; i++)
                    {
                        Console.WriteLine("{0}", gerentes[i].Name);
                    }
                }
                else
                {
                    // applyColor(Console.WriteLine, "Nao tem gerentes para listar.", ConsoleColor.Red);
                    Console.WriteLine("Nao tem gerentes para listar.");
                }
            }
            else if (option == 2)
            {
                if (repositores.Count > 0)
                {
                    Console.WriteLine("Os repositores da livraria são: ");
                    for (int i = 0; i < repositores.Count; i++)
                    {
                        Console.WriteLine("{0}", repositores[i].Name);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Nao existe repositores para listar.");
                }
            }
            else if (option == 3)
            {
                if (caixas.Count > 0)
                {
                    Console.WriteLine("Os caixas da livraria são: ");
                    for (int i = 0; i < caixas.Count; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("{0}", caixas[i].Name);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Nao existe caixas para listar.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção invalida");
            }
        }

        public void removeEmployee(List<Gerente> gerentes, List<Repositor> repositores, List<Caixa> caixas)
        {
            Console.Clear();
            Console.WriteLine("Escolha o tipo de funcionario que deseja despedir:");
            Console.WriteLine("1• Gerente");
            Console.WriteLine("2• Repositor");
            Console.WriteLine("3• Caixa");
            int option = askIntOption("Escolha a opcao: ");
            if (option == 1)
            {
                Console.WriteLine("Estes sao todos os gerentes desta livraria que podera remover:");

                for (int i = 0; i < gerentes.Count; i++)
                {
                    Console.WriteLine("O funcionario {0}", gerentes[i].Name);
                }
                Console.WriteLine("Escolha o funcionario que deseja remover.");
                string optionGerente = Console.ReadLine();
                for (int i = 0; i < gerentes.Count; i++)
                {
                    if (optionGerente == gerentes[i].Name)
                    {
                        Console.WriteLine("O gerente {0} foi removido", gerentes[i].Name);
                        gerentes.RemoveAt(i);
                        return;
                    }
                }

                // Console.WriteLine("Gerente inexistente.");
            }
            else if (option == 2)
            {
                Console.WriteLine("Estes sao todos os repositores desta livraria que podera remover:");

                for (int i = 0; i < repositores.Count; i++)
                {
                    Console.WriteLine("O funcionario {0} ", repositores[i].Name);
                }
                Console.WriteLine("Escolha o funcionario que deseja remover.");
                string optionRepositor = Console.ReadLine();
                for (int i = 0; i < repositores.Count; i++)
                {
                    if (optionRepositor == repositores[i].Name)
                    {
                        Console.WriteLine("O repositor {0} foi removido", repositores[i].Name);
                        repositores.RemoveAt(i);
                    }
                }

                Console.WriteLine("Repositor inexistente.");
            }
            else if (option == 3)
            {
                Console.WriteLine("Estes sao todos os caixas desta livraria que podera remover:");

                for (int i = 0; i < caixas.Count; i++)
                {
                    Console.WriteLine("O funcionario {0}", caixas[i].Name);
                }
                Console.WriteLine("Escolha o numero do funcionario que deseja remover.");
                string optionCaixa = Console.ReadLine();
                for (int i = 0; i < caixas.Count; i++)
                {
                    if (optionCaixa == caixas[i].Name)
                    {
                        Console.WriteLine("O caixa {0} foi removido", caixas[i].Name);
                        caixas.RemoveAt(i);
                    }
                }

                Console.WriteLine("Caixa inexistente.");
            }
        }
    }
}