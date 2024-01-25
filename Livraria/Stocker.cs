using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Stocker : Employee
    {
        public Stocker(string name, string username, string password) : base(name, username, password)
        {
        }

        public void registBooks(List<Book> livros)
        {
            int code = askIntOption("Código do livro:");
            foreach (Book livro in livros)
            {
                if (code == livro.Code)
                {
                    Console.WriteLine("Code ja existente");
                    return;
                }
            }

            Console.Write("Título do livro: ");
            string title = Console.ReadLine();
            foreach (Book livro in livros)
            {
                if (title == livro.Title)
                {
                    Console.WriteLine("Title ja existente");
                    return;
                }
            }

            Console.Write("Author do livro: ");
            string author = Console.ReadLine();

            Console.Write("ISBN do livro: ");
            string isbn = Console.ReadLine();
            foreach (Book livro in livros)
            {
                if (isbn == livro.Isbn)
                {
                    Console.WriteLine("ISBN ja existente");
                    return;
                }
            }

            Console.Write("Género do livro: ");
            string genre = Console.ReadLine();

            double price = askdoubleOption("Preço do livro: ");

            double taxIVA = askdoubleOption("Taxa de IVA do livro: ");

            int stock = askIntOption("Stock do livro: ");

            Book novoLivro = new Book(code, title, author, isbn, genre, price, taxIVA, stock);
            livros.Add(novoLivro);
            Console.Clear();
            Console.WriteLine($"Livro '{title}' registrado!");
        }

        public void showRegistedBooks(List<Book> livros)
        {
            Console.Clear();
            Console.WriteLine("Livros Registrados:");

            foreach (var livro in livros)
            {
                Console.WriteLine($"Código: {livro.Code}, Título: {livro.Title}, Author: {livro.Author}, ISBN: {livro.Isbn}, Gênero: {livro.Genre}, Preço: {livro.Price}, Taxa de IVA: {livro.TaxIVA}, Stock: {livro.Stock}");
            }
        }

        public void updateBooks(List<Book> livros)
        {
            Console.Clear();
            Console.WriteLine("Qual o livro que deseja alterar dados?");
            foreach (Book livro in livros)
            {
                Console.WriteLine("{0}", livro.Title);
            }

            string bookTitle = Console.ReadLine();
            foreach (Book livro in livros)

            {
                if (bookTitle == livro.Title)
                {
                    Console.WriteLine("Tem estes parametros que podera alterar:");
                    Console.WriteLine("code");
                    Console.WriteLine("title");
                    Console.WriteLine("author");
                    Console.WriteLine("isbn");
                    Console.WriteLine("genre");
                    Console.WriteLine("price");
                    Console.WriteLine("taxIVA");
                    Console.WriteLine("stock");
                    Console.WriteLine("Escreva qual deseja alrerar:");
                    string parameters = Console.ReadLine();
                    switch (parameters)
                    {
                        case "code":
                            livro.Code = askIntOption("Novo Código:");
                            break;

                        case "title":
                            Console.WriteLine("Novo Título:");
                            livro.Title = Console.ReadLine();
                            break;

                        case "author":
                            Console.WriteLine("Novo Author:");
                            livro.Author = Console.ReadLine();
                            break;

                        case "isbn":
                            Console.WriteLine("Novo Isbn:");
                            livro.Isbn = Console.ReadLine();
                            break;

                        case "genre":
                            Console.WriteLine("Novo Genre:");
                            livro.Genre = Console.ReadLine();
                            break;

                        case "price":

                            livro.Price = askdoubleOption("Novo Preço: ");
                            break;

                        case "taxIVA":

                            livro.TaxIVA = askdoubleOption("Nova TaxIVA: ");
                            break;

                        case "stock":

                            livro.Stock = askIntOption("Novo Stock:");
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

        public void listBooksbyGenre(List<Book> livros)
        {
            bool encontrouLivro = false;
            Console.WriteLine("Escolha o genre que quer ver livros: ex: Drama, Romance, Poema ");
            string bookGenre = Console.ReadLine();
            for (int i = 0; i < livros.Count; i++)
            {
                if (bookGenre == livros[i].Genre)
                {
                    Console.Clear();
                    Console.WriteLine("O livro {0}", livros[i].Title);
                    encontrouLivro = true;
                }
            }
            if (!encontrouLivro)
            {
                Console.Clear();
                Console.WriteLine("Não há livros disponíveis para o gênero {0}.", bookGenre);
            }
        }

        public void listBooksByAuthor(List<Book> livros)
        {
            bool encontrouLivro = false;
            Console.WriteLine("Escolha o author que quer ver livros: ex: Pedro Pinheiro, Tiago Pereira, etc");
            string bookautor = Console.ReadLine();
            for (int i = 0; i < livros.Count; i++)
            {
                if (bookautor == livros[i].Author)
                {
                    Console.Clear();
                    Console.WriteLine("O livro {0}", livros[i].Title);
                    encontrouLivro = true;
                }
            }
            if (!encontrouLivro)
            {
                Console.Clear();
                Console.WriteLine("Não há livros disponíveis com o author {0}.", bookautor);
            }
        }

        /// <summary>
        /// Código do artigo, quantidade, preço unitário e taxa de IVA. Podem ser inseridos um nº de livros
        //indeterminado.Termina a introdução de dados inserindo o código de artigo 0.
        //Se a soma dos valores da venda for superior a 50 €, aplica um desconto ao valor total de 10%.
        //No final deverá mostrar o total, o desconto, o valor do IVA e o total depois do IVA.

        //o price que compro is diferente do price do regist books, porque ao registrar estou a meter o price para o public
        //recebe do user o artigo e quantidade mas porque pede tambem o price e a taxa??
        //fazer um while em que recebe o code de um livro e adiciona
        //verificar se existe stock
        /// </summary>
        public void buyBooks(List<Book> livros)
        {
            int code;
            double total = 0;
            double totalIVA = 0;
            do
            {
                Console.WriteLine("Lista de livros que podera comprar para adicionar ao stock existente:");
                for (int i = 0; i < livros.Count; i++)
                {
                    Console.WriteLine("O livro {0} com o stock de {1} e code {2}", livros[i].Title, livros[i].Stock, livros[i].Code);
                }
                code = askIntOption("Escolha o code do livro que deseja comprar:");

                for (int i = 0; i < livros.Count; i++)
                {
                    if (code == livros[i].Code)
                    {
                        Console.Clear();
                        int quantidade = askIntOption("Quantidade:");
                        livros[i].Stock = livros[i].Stock + quantidade;

                        int price = askIntOption("Price: ");

                        int iva = askIntOption("Taxa de IVA: ");

                        Console.WriteLine("Livro {0} com o code {1} foi adicionado ao stock", livros[i].Title, livros[i].Code);
                        total = total + (price * quantidade);
                        totalIVA = totalIVA + (price * iva / 100);
                    }
                }
            } while (code != 0);
            if (total > 50)
            {
                Console.WriteLine("Total fica {0} devido a compra ultrapassar os 50 euros fica com desconto de 10%, o valor do IVA sera de {1}% e o valor total com o IVA sera de {2}", total * 0.9, totalIVA, (total * 0.9) + totalIVA);
            }
            else
            {
                Console.WriteLine("Total fica por {0}, o valor do IVA sera de {1} e o valor total com o IVA sera de {2}", total, totalIVA, total + totalIVA);
            }
        }
    }
}