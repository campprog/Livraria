using System;
using System.Collections.Generic;

namespace Livraria
{
    public class Caixa : Funcionario, IGerenteECaixa
    {
        public Caixa(string name, string password) : base(name, password)
        {
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
                    Console.Clear();
                    Console.WriteLine("Livro vendido.");
                }
            }
        }
    }
}