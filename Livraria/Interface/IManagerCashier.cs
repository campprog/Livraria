using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public interface IManagerECaixa
    {
        void sellBooks(List<Book> livros);
    }
}