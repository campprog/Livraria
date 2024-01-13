using System;

namespace Livraria { }

public abstract class Funcionario
{
    public string Name { get; set; }
    public string Password { get; set; }

    public Funcionario(string name, string password)
    {
        Name = name;
        Password = password;
    }

    public void checkOnInfoFromBookWithCode()
    {
        //receber o codigo do livro

        //verificar se existe

        //se existir returnar as info do livro
    }

    public void checkStock()
    {
    }

    //public  void logout(Livraria login)
    // {
    // login();
    // };
}