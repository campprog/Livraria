using System;
using System.Collections.Generic;

namespace Livraria
{
    public class Cashier : Employee, IManagerECaixa
    {
        public Cashier(string name, string username, string password) : base(name, username, password)
        {
        }

        public void sellBooks(List<Book> livros)
        {
            Console.WriteLine("Deseja vender que livro");
            for (int i = 0; i < livros.Count; i++)
            {
                Console.WriteLine("{0}", livros[i].Title);
            }
            string option = Console.ReadLine();
            for (int i = 0; i < livros.Count; i++)
            {
                if (option == livros[i].Title)
                {
                    livros[i].Stock = livros[i].Stock - 1;
                    Console.Clear();
                    Console.WriteLine("Livro vendido.");
                }
            }
        }
    }
}