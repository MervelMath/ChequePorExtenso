using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeEmExtenso.ConsoleApp
{
    public class Tela : Excecoes
    {
        Controlador controlador = new Controlador();
        Excecoes excecoes = new Excecoes();
        public void CriarCheque()
        {
            bool testarNumero = true;
            string numeroExtenso;

            Console.Clear();

            Console.Write("Digite o número monetário a ser escrito por extenso no cheque: ");
            string numero = Console.ReadLine();

            testarNumero = excecoes.Validar(numero);

            if (testarNumero == true)
            {
                numeroExtenso = controlador.ConverterParaExtenso(numero);
                Console.WriteLine(numeroExtenso);
            }

            else
                CriarCheque();
            

        }
    }
}
