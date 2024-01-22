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
        /// Código do artigo, quantidade, preço unitário e taxa de IVA. Podem ser inseridos um nº de livros
        //indeterminado.Termina a introdução de dados inserindo o código de artigo 0.
        //Se a soma dos valores da venda for superior a 50 €, aplica um desconto ao valor total de 10%.
        //No final deverá mostrar o total, o desconto, o valor do IVA e o total depois do IVA.

        //o preco que compro is diferente do preco do regist books, porque ao registrar estou a meter o preco para o public
        //recebe do user o artigo e quantidade mas porque pede tambem o preco e a taxa??
        //fazer um while em que recebe o codigo de um livro e adiciona
        //verificar se existe stock
        /// </summary>
        public void buyBooks(List<Livro> livros)
        {
            int codigo;
            double total = 0;
            double totalIVA = 0;
            do
            {
                Console.WriteLine("Lista de livros que podera comprar para adicionar ao stock existente:");
                for (int i = 0; i < livros.Count; i++)
                {
                    Console.WriteLine("O livro {0} com o stock de {1} e codigo {2}", livros[i].Titulo, livros[i].Stock, livros[i].Codigo);
                }
                codigo = askIntOption("Escolha o codigo do livro que deseja comprar:");

                for (int i = 0; i < livros.Count; i++)
                {
                    if (codigo == livros[i].Codigo)
                    {
                        Console.Clear();
                        int quantidade = askIntOption("Quantidade:");
                        livros[i].Stock = livros[i].Stock + quantidade;

                        int preco = askIntOption("Preco: ");

                        int iva = askIntOption("Taxa de IVA: ");

                        Console.WriteLine("Livro {0} com o codigo {1} foi adicionado ao stock", livros[i].Titulo, livros[i].Codigo);
                        total = total + (preco * quantidade);
                        totalIVA = totalIVA + (preco * iva / 100);
                    }
                }
            } while (codigo != 0);
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