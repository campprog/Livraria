using System;
using System.Collections.Generic;

namespace Livraria
{
    public class Gerente : Funcionario, IGerenteECaixa
    {
        public Gerente(string name, string password) : base(name, password)
        {
        }

        public void addEmployee(List<Gerente> gerentes, List<Repositor> repositores, List<Caixa> caixas)
        {
            Console.WriteLine("Qual é o funcionario que deseja empregar: ");
            Console.WriteLine("1• Gerente");
            Console.WriteLine("2• Repositor");
            Console.WriteLine("3• Caixa");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                Console.WriteLine("Nome do Gerente");
                string nomeGerente = Console.ReadLine();

                Console.WriteLine("Password do Gerente: ");
                string passGerente = Console.ReadLine();

                Gerente gerente = new Gerente(nomeGerente, passGerente);
                gerentes.Add(gerente);
            }
            else if (option == 2)
            {
                Console.WriteLine("Nome do Repositor");
                string nomeRepositores = Console.ReadLine();

                Console.WriteLine("Password do Repositor: ");
                string passRepositor = Console.ReadLine();

                Repositor repositor = new Repositor(nomeRepositores, passRepositor);
                repositores.Add(repositor);
            }
            else if (option == 3)
            {
                Console.WriteLine("Nome do Caixa");
                string nomeCaixa = Console.ReadLine();

                Console.WriteLine("Password do Repositor: ");
                string passCaixa = Console.ReadLine();

                Caixa caixa = new Caixa(nomeCaixa, passCaixa);
                caixas.Add(caixa);
            }
            else
            {
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
                totalReceita += item.Sold * (item.Preco);//+(item.precoitem.taxaIVA));
            }
            Console.WriteLine("O total de livros vendidos foi de : {0}", totalBooksSold);
            Console.WriteLine("E o total de receita acumulado de todas as vendas foi de: {0}", totalReceita);
        }

        public void listEmployee(List<Gerente> gerentes, List<Repositor> repositores, List<Caixa> caixas)
        {
            Console.WriteLine("Qual é os funcionarios que deseja listar: ");
            Console.WriteLine("1• Gerente");
            Console.WriteLine("2• Repositor");
            Console.WriteLine("3• Caixa");
            int option = Convert.ToInt32(Console.ReadLine());
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
                        Console.WriteLine("{0}", caixas[i].Name);
                    }
                }
                else
                {
                    Console.WriteLine("Nao existe caixas para listar.");
                }
            }
            else
            {
                Console.WriteLine("Opção invalida");
            }
        }

        public void removeEmployee(List<Gerente> gerentes, List<Repositor> repositores, List<Caixa> caixas)
        {
            Console.WriteLine("Escolha o tipo de funcionario que deseja despedir:");
            Console.WriteLine("1• Gerente");
            Console.WriteLine("2• Repositor");
            Console.WriteLine("3• Caixa");
            int option = Convert.ToInt32(Console.ReadLine());
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
                    if (optionGerente == repositores[i].Name)
                    {
                        gerentes.RemoveAt(i);
                    }
                }
                Console.WriteLine("Gerente inexistente.");
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
                        repositores.RemoveAt(i);
                        return;
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
                        caixas.RemoveAt(i);
                    }
                }
                Console.WriteLine("Caixa inexistente.");
            }
        }
    }
}