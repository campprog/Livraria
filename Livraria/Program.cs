using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Livraria livraria = new Livraria();

            livraria.login();
        }
    }
}