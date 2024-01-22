using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Repositor : Funcionario
    {
        public Repositor(string name, string password) : base(name, password)
        {
        }

        public void registBooks(List<Livro> livros)
        {
            Console.Write("Código: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            foreach (Livro livro in livros)
            {
                if (codigo == livro.Codigo)
                {
                    Console.WriteLine("Codigo ja existente");
                    return;
                }
            }

            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            foreach (Livro livro in livros)
            {
                if (titulo == livro.Titulo)
                {
                    Console.WriteLine("Titulo ja existente");
                    return;
                }
            }

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();
            foreach (Livro livro in livros)
            {
                if (isbn == livro.Isbn)
                {
                    Console.WriteLine("ISBN ja existente");
                    return;
                }
            }

            Console.Write("Género: ");
            string genero = Console.ReadLine();

            Console.Write("Preço: ");
            double preco = Convert.ToDouble(Console.ReadLine());

            Console.Write("Taxa de IVA: ");
            double taxaIVA = Convert.ToDouble(Console.ReadLine());

            Console.Write("Stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            Livro novoLivro = new Livro(codigo, titulo, autor, isbn, genero, preco, taxaIVA, stock);
            livros.Add(novoLivro);
            Console.Clear();
            Console.WriteLine($"Livro '{titulo}' registrado!");
        }

        public void showRegistedBooks(List<Livro> livros)
        {
            Console.Clear();
            Console.WriteLine("Livros Registrados:");

            foreach (var livro in livros)
            {
                Console.WriteLine($"Código: {livro.Codigo}, Título: {livro.Titulo}, Autor: {livro.Autor}, ISBN: {livro.Isbn}, Gênero: {livro.Genero}, Preço: {livro.Preco}, Taxa de IVA: {livro.TaxaIVA}, Stock: {livro.Stock}");
            }
        }

        public void updateBooks(List<Livro> livros)
        {
            Console.Clear();
            Console.WriteLine("Qual o livro que deseja alterar dados?");
            foreach (Livro livro in livros)
            {
                Console.WriteLine("{0}", livro.Titulo);
            }

            string bookTitle = Console.ReadLine();
            foreach (Livro livro in livros)

            {
                if (bookTitle == livro.Titulo)
                {
                    Console.WriteLine("Tem estes parametros que podera alterar:");
                    Console.WriteLine("codigo");
                    Console.WriteLine("titulo");
                    Console.WriteLine("autor");
                    Console.WriteLine("isbn");
                    Console.WriteLine("genero");
                    Console.WriteLine("preco");
                    Console.WriteLine("taxaIVA");
                    Console.WriteLine("stock");
                    Console.WriteLine("Escreva qual deseja alrerar:");
                    string parameters = Console.ReadLine();
                    switch (parameters)
                    {
                        case "codigo":
                            Console.WriteLine("Novo Código:");
                            livro.Codigo = Convert.ToInt32(Console.ReadLine());
                            break;

                        case "titulo":
                            Console.WriteLine("Novo Título:");
                            livro.Titulo = Console.ReadLine();
                            break;

                        case "autor":
                            Console.WriteLine("Novo Autor:");
                            livro.Autor = Console.ReadLine();
                            break;

                        case "isbn":
                            Console.WriteLine("Novo Isbn:");
                            livro.Isbn = Console.ReadLine();
                            break;

                        case "genero":
                            Console.WriteLine("Novo Genero:");
                            livro.Genero = Console.ReadLine();
                            break;

                        case "preco":
                            Console.WriteLine("Novo Preço:");
                            livro.Preco = Convert.ToDouble(Console.ReadLine());
                            break;

                        case "taxaIVA":
                            Console.WriteLine("Nova TaxaIVA:");
                            livro.TaxaIVA = Convert.ToDouble(Console.ReadLine());
                            break;

                        case "stock":
                            Console.WriteLine("Novo Stock:");
                            livro.Stock = Convert.ToInt32(Console.ReadLine());
                            break;

                        default:
                            Console.WriteLine("Parâmetro inválido.");
                            break;
                    }

                    Console.WriteLine("Livro atualizado com sucesso!");
                    return;
                }
            }

            Console.WriteLine("Livro nao encontrado");
        }

        public void listBooksbyGenre(List<Livro> livros)
        {
            bool encontrouLivro = false;
            Console.WriteLine("Escolha o genero que quer ver livros: ex: Drama, Romance, Poema ");
            string bookGenre = Console.ReadLine();
            for (int i = 0; i < livros.Count; i++)
            {
                if (bookGenre == livros[i].Genero)
                {
                    Console.Clear();
                    Console.WriteLine("O livro {0}", livros[i].Titulo);
                    encontrouLivro = true;
                }
            }
            if (!encontrouLivro)
            {
                Console.Clear();
                Console.WriteLine("Não há livros disponíveis para o gênero {0}.", bookGenre);
            }
        }

        public void listBooksByAuthor(List<Livro> livros)
        {
            bool encontrouLivro = false;
            Console.WriteLine("Escolha o autor que quer ver livros: ex: Pedro Pinheiro, Tiago Pereira, etc");
            string bookautor = Console.ReadLine();
            for (int i = 0; i < livros.Count; i++)
            {
                if (bookautor == livros[i].Autor)
                {
                    Console.Clear();
                    Console.WriteLine("O livro {0}", livros[i].Titulo);
                    encontrouLivro = true;
                }
            }
            if (!encontrouLivro)
            {
                Console.Clear();
                Console.WriteLine("Não há livros disponíveis com o autor {0}.", bookautor);
            }
        }

        /// <summary>
        /// add books to a stock from a existing bookstore stock and ask how many to you want to add
        /// </summary>
        public void buyBooks(List<Livro> livros)
        {
            Console.WriteLine("Lista de livros que podera comprar para adicionar ao stock existente:");
            for (int i = 0; i < livros.Count; i++)
            {
                Console.WriteLine("O livro {0} com o stock de {1}", livros[i].Titulo, livros[i].Stock);
            }
            Console.WriteLine("Escolha o titulo do livro que deseja comprar:");
            string bookTitle = Console.ReadLine();

            for (int i = 0; i < livros.Count; i++)
            {
                if (bookTitle == livros[i].Titulo)
                {
                    Console.Clear();
                    livros[i].Stock = livros[i].Stock + 1;
                    Console.WriteLine("Livro {0} adicionado ao stock", livros[i].Titulo);
                }
            }
        }
    }
}