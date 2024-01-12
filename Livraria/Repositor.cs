using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Repositor : Funcionario
    {
        /// <summary>
        /// add a new book with a new atributes
        /// </summary>
        private List<Livro> livros = new List<Livro>();

        public void registBooks()
        {
            Console.Write("Código: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            Console.Write("Género: ");
            string genero = Console.ReadLine();

            Console.Write("Preço: ");
            double preco = Convert.ToDouble(Console.ReadLine());

            Console.Write("Taxa de IVA: ");
            double taxaIVA = Convert.ToDouble(Console.ReadLine());

            Console.Write("Stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            Livro novoLivro = new Livro
            {
                Codigo = codigo,
                Titulo = titulo,
                Autor = autor,
                Isbn = isbn,
                Genero = genero,
                Preco = preco,
                TaxaIVA = taxaIVA,
                Stock = stock
            };

            livros.Add(novoLivro);

            Console.WriteLine($"Livro '{titulo}' registrado!");
            Console.ReadKey();
        }

        public void showRegistedBooks()
        {
            Console.WriteLine("Livros Registrados:");

            foreach (var livro in livros)
            {
                Console.WriteLine($"Código: {livro.Codigo}, Título: {livro.Titulo}, Autor: {livro.Autor}, ISBN: {livro.Isbn}, Gênero: {livro.Genero}, Preço: {livro.Preco}, Taxa de IVA: {livro.TaxaIVA}, Stock: {livro.Stock}");
            }
            Console.ReadKey();
        }

        public void updateBooks()
        {
            Console.WriteLine("sdsada");
        }

        public void listBooksbyGenre()
        {
        }

        public void listBooksByAuthor()
        {
        }

        /// <summary>
        /// add books to a stock from a existing bookstore stock
        /// </summary>
        public void buyBooks()
        {
        }

        public void checkStock()
        {
        }
    }
}