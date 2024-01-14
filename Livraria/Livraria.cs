using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Livraria
{
    internal class Livraria
    {
        private List<Livro> livros = new List<Livro>
        {
                // Add instances of Livro to the list
                new Livro(1, "Book 1", "Tiago Pereira", "ISBN123", "Romance", 29.99, 0.05, 50),
                new Livro(2, "Book 2", "Pedro Pinheiro", "ISBN456", "Drama", 39.99, 0.08, 30),
                new Livro(3, "Book 3", "Tiago Pereira", "ISBN789", "Drama", 19.99, 0.03, 70),
                new Livro(3, "Book 3", "Pedro Pinheiro", "ISBN789", "Drama", 19.99, 0.03, 70),
        };

        private List<Gerente> gerentes = new List<Gerente>
        {
            new Gerente("Tiago", "tiago123")
        };

        private List<Repositor> repositores = new List<Repositor>
        {
            new Repositor("Fernando", "fernando123")
        };

        private List<Caixa> caixas = new List<Caixa>
        {
            new Caixa("dionisio", "dionisio123")
        };

        //quero que quando uma funcao acabar nao volte para o inicio do login, mas sim para as funcoes a que o utilizador logado tem acesso
        //falta acabar a funcao updatebooks no repositor
        //meter o login com melhor aspeto
        public void login()
        {
            Console.WriteLine("Login as: ");
            Console.WriteLine("1• Gerente");
            Console.WriteLine("2• Repositor");
            Console.WriteLine("3• Caixa");
            int loginOption = Convert.ToInt32(Console.ReadLine());
            if (loginOption == 1)
            {
                for (int i = 0; i < gerentes.Count; i++)
                {
                    Console.WriteLine("Escolha o gerente:");
                    Console.WriteLine("{0} {1}", i + 1, gerentes[i].Name);
                }
                int option = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < gerentes.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.WriteLine("Digite a password:");
                        string passGerente = Console.ReadLine();
                        if (passGerente == gerentes[i].Password)
                        {
                            gerente(gerentes[i]);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Password errada");
                            login();
                        }
                    }
                }
                Console.WriteLine("Nao existe nenhum gerente com essa opcao");
                login();
            }
            else if (loginOption == 2)
            {
                for (int i = 0; i < repositores.Count; i++)
                {
                    Console.WriteLine("Escolha o repositor: ");
                    Console.WriteLine("{0} {1}", i + 1, repositores[i].Name);
                }
                int option = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < repositores.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.WriteLine("Digite a password: ");
                        string passRepositor = Console.ReadLine();
                        if (passRepositor == repositores[i].Password)
                        {
                            repositor(repositores[i]);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Password incorreta.");
                            login();
                        }
                    }
                }
                Console.WriteLine("Nao existe nenhum repositor com essa opcao");
                login();
            }
            else if (loginOption == 3)
            {
                for (int i = 0; i < caixas.Count; i++)
                {
                    Console.WriteLine("Escolha o caixista: ");
                    Console.WriteLine("{0} {1}", i + 1, caixas[i].Name);
                }
                int option = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < caixas.Count; i++)
                {
                    if (option == i + 1)
                    {
                        Console.WriteLine("Digite a password: ");
                        string passCaixa = Console.ReadLine();
                        if (passCaixa == caixas[i].Password)
                        {
                            caixa(caixas[i]);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Password incorreta");
                            login();
                        }
                    }
                }
                Console.WriteLine("Nao existe nenhum caixa com essa opcao");
                login();
            }
        }

        //nao entendi bem porque meteu o Gerente gerente a passar para a funcao aqui
        public void gerente(Gerente gerente)
        {
            Console.WriteLine("Sessao inciada com sucesso");

            Console.WriteLine("1• Consultar a informação de um livro a partir do código");

            Console.WriteLine("2• Consultar stock");

            Console.WriteLine("3• Adicionar funcionario");

            Console.WriteLine("4• Remover funcionario");

            Console.WriteLine("5• Listar os utilizadores");

            Console.WriteLine("6• Vender livros ");

            Console.WriteLine("7• Consultar o total de livros vendidos e respetiva receita ");

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:

                    gerente.checkOnInfoFromBookWithCode(livros);
                    login();
                    break;

                case 2:
                    gerente.checkStock(livros);
                    login();
                    break;

                case 3:
                    gerente.addEmployee(gerentes, repositores, caixas);
                    login();
                    break;

                case 4:
                    gerente.removeEmployee(gerentes, repositores, caixas);
                    login();
                    break;

                case 5:
                    gerente.listEmployee(gerentes, repositores, caixas);
                    login();
                    break;

                case 6:
                    gerente.sellBooks(livros);
                    login();
                    break;

                case 7:
                    gerente.checkTotalBooksSoldAndTotalRevenue(livros);
                    login();
                    break;
            }
        }

        public void repositor(Repositor repositor)
        {
            Console.WriteLine("Sessao inciada com sucesso");

            Console.WriteLine("1• Consultar a informação de um livro a partir do código");

            Console.WriteLine("2• Mostrar os livros registados");

            Console.WriteLine("3• Registar livros");

            Console.WriteLine("4• Consultar livros pelo genero");

            Console.WriteLine("5• Consultar livros pelo autor");

            Console.WriteLine("6• Atualizar livros");

            Console.WriteLine("7• Comprar livros ");

            Console.WriteLine("8• Consultar stock ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    repositor.checkOnInfoFromBookWithCode(livros);
                    login();
                    break;

                case 2:
                    repositor.showRegistedBooks(livros);
                    login();
                    break;

                case 3:
                    repositor.registBooks(livros);
                    login();
                    break;

                case 4:
                    repositor.listBooksbyGenre(livros);
                    login();
                    break;

                case 5:
                    repositor.listBooksByAuthor(livros);
                    login();
                    break;

                case 6:
                    break;

                case 7:
                    repositor.buyBooks(livros);
                    login();
                    break;

                case 8:
                    repositor.checkStock(livros);
                    login();
                    break;
            }
        }

        public void caixa(Caixa caixa)
        {
            Console.WriteLine("Sessao inciada com sucesso");

            Console.WriteLine("1• Consultar a informação de um livro a partir do código");

            Console.WriteLine("2• vender livros");

            Console.WriteLine("3• Consultar stock ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    caixa.checkOnInfoFromBookWithCode(livros);
                    login();
                    break;

                case 2:
                    caixa.sellBooks(livros);
                    login();
                    break;

                case 3:
                    caixa.checkStock(livros);
                    login();
                    break;
            }
        }
    }
}