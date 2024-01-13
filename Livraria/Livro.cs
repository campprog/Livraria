using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Livro
    {
        private int codigo;
        private string titulo;
        private string autor;
        private string isbn;
        private string genero;
        private double preco;
        private double taxaIVA;
        private int stock;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public double TaxaIVA
        {
            get { return taxaIVA; }
            set { taxaIVA = value; }
        }

        public Livro(int codigo, string titulo, string autor, string isbn, string genero, double preco, double taxaIVA, int stock)
        {
            Codigo = codigo;
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            Genero = genero;
            Preco = preco;
            TaxaIVA = taxaIVA;
            Stock = stock;
        }
    }
}