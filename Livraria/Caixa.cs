namespace Livraria
{
    public class Caixa : Funcionario, GerenteECaixa
    {
        public Caixa(string name, string password) : base(name, password)
        {
        }

        public void sellBooks()
        {
        }
    }
}