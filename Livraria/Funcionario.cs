using Livraria;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web;

namespace Livraria { }

public abstract class Funcionario
{
    public string Name { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }

    public Funcionario(string name, string username, string password)
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

    public void checkOnInfoFromBookWithCode(List<Livro> livros)
    {
        Console.WriteLine("Codigos dos livros:");
        for (int i = 0; i < livros.Count; i++)
        {
            Console.WriteLine("{0}", livros[i].Codigo);
        }

        int codigoLivro = 1 + askIntOption("Digite o codigo do livro: ");

        for (int i = 0; i < livros.Count; i++)
        {
            if (codigoLivro == livros[i].Codigo)
            {
                Console.Clear();
                Console.WriteLine("O Titulo do livro é {0}", livros[i].Titulo);
                Console.WriteLine("O autor do livro é {0}", livros[i].Autor);
                Console.WriteLine("O ISBN do livro é {0}", livros[i].Isbn);
                Console.WriteLine("O Genero do livro é {0}", livros[i].Genero);
                Console.WriteLine("O Preco do livro é {0}", livros[i].Preco);
                Console.WriteLine("A taxa de IVA do livro é {0}", livros[i].TaxaIVA);
                Console.WriteLine("O Stock do livro é {0}", livros[i].Stock);
                return;
            }
        }
        Console.Clear();
        Console.WriteLine("Codigo invalido");
    }

    public void checkStock(List<Livro> livros)
    {
        int soma = 0;
        Console.Clear();
        for (int i = 0; i < livros.Count; i++)
        {
            soma = soma + livros[i].Stock;

            Console.WriteLine("O livro com titulo {0} tem o stock de {1}", livros[i].Titulo, livros[i].Stock);
        }

        Console.WriteLine("O stock de todos os livros é de {0}", soma);
    }
}