using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Gerente g = new Gerente();
            g.checkOnInfoFromBookWithCode();
        }
    }
}