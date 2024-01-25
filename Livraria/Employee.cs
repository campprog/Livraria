using Livraria;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web;

namespace Livraria { }

public abstract class Employee
{
    public string Name { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }

    public Employee(string name, string username, string password)
    {
        Name = name;
        Username = username;
        Password = password;
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

    public double askdoubleOption(string message)
    {
        double option = -1;
        bool isValidOption = false;
        do
        {
            Console.Write(message);

            try
            {
                option = Convert.ToDouble(Console.ReadLine());
                isValidOption = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Opcao invalida");
            }
        } while (!isValidOption);
        return option;
    }

    public void checkOnInfoFromBookWithCode(List<Book> livros)
    {
        Console.WriteLine("Codigos dos livros:");
        for (int i = 0; i < livros.Count; i++)
        {
            Console.WriteLine("{0}", livros[i].Code);
        }

        int codigoLivro = 1 + askIntOption("Digite o code do livro: ");

        for (int i = 0; i < livros.Count; i++)
        {
            if (codigoLivro == livros[i].Code)
            {
                Console.Clear();
                Console.WriteLine("O Title do livro é {0}", livros[i].Title);
                Console.WriteLine("O author do livro é {0}", livros[i].Author);
                Console.WriteLine("O ISBN do livro é {0}", livros[i].Isbn);
                Console.WriteLine("O Genre do livro é {0}", livros[i].Genre);
                Console.WriteLine("O Price do livro é {0}", livros[i].Price);
                Console.WriteLine("A taxa de IVA do livro é {0}", livros[i].TaxIVA);
                Console.WriteLine("O Stock do livro é {0}", livros[i].Stock);
                return;
            }
        }
        Console.Clear();
        Console.WriteLine("Code invalido");
    }

    public void checkStock(List<Book> livros)
    {
        int soma = 0;
        Console.Clear();
        for (int i = 0; i < livros.Count; i++)
        {
            soma = soma + livros[i].Stock;

            Console.WriteLine("O livro com title {0} tem o stock de {1}", livros[i].Title, livros[i].Stock);
        }

        Console.WriteLine("O stock de todos os livros é de {0}", soma);
    }
}