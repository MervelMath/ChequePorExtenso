using System;

namespace ChequeEmExtenso.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Tela tela = new Tela();
            tela.CriarCheque();
            Console.ReadLine();
        }
    }
}
