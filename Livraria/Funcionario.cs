using Livraria;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Livraria { }

public abstract class Funcionario
{
    public string Name { get; set; }
    public string Password { get; set; }

    public Funcionario(string name, string password)
    {
        Name = name;
        Password = password;
    }

    public void checkOnInfoFromBookWithCode(List<Livro> livros)
    {
        Console.WriteLine("Codigos dos livros:");
        for (int i = 0; i < livros.Count; i++)
        {
            Console.WriteLine("{0}", livros[i].Codigo);
        }
        Console.WriteLine("Digite o codigo do livro");

        int codigoLivro = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < livros.Count; i++)
        {
            if (codigoLivro == livros[i].Codigo)
            {
                Console.WriteLine("O Titulo do livro é {0}", livros[i].Titulo);
                Console.WriteLine("O autor do livro é {0}", livros[i].Autor);
                Console.WriteLine("O ISBN do livro é {0}", livros[i].Isbn);
                Console.WriteLine("O Genero do livro é {0}", livros[i].Genero);
                Console.WriteLine("O Preco do livro é {0}", livros[i].Preco);
                Console.WriteLine("A taxa de IVA do livro é {0}", livros[i].TaxaIVA);
                Console.WriteLine("O Stock do livro é {0}", livros[i].Stock);
            }
        }
        Console.WriteLine("Codigo invalido");
    }

    public void checkStock(List<Livro> livros)
    {
        int soma = 0;
        for (int i = 0; i < livros.Count; i++)
        {
            Console.WriteLine("O livro com titulo {0} tem o stock de {1}", livros[i].Titulo, livros[i].Stock);
            soma = soma + livros[i].Stock;
        }
        Console.WriteLine("O stock de todos os livros é de {0}", soma);
    }
}