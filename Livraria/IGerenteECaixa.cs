using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public interface IGerenteECaixa
    {
        void sellBooks(List<Livro> livros);
    }
}