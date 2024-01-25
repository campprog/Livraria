using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Book
    {
        private int code;
        private string title;
        private string author;
        private string isbn;
        private string genre;
        private double price;
        private double taxIVA;
        private int stock;
        private int sold;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public double TaxIVA
        {
            get { return taxIVA; }
            set { taxIVA = value; }
        }

        public int Sold
        {
            get { return sold; }
            set { sold = value; }
        }

        public Book(int code, string title, string author, string isbn, string genre, double price, double taxIVA, int stock)
        {
            Code = code;
            Title = title;
            Author = author;
            Isbn = isbn;
            Genre = genre;
            Price = price;
            TaxIVA = taxIVA;
            Stock = stock;
            Sold = 0;
        }
    }
}