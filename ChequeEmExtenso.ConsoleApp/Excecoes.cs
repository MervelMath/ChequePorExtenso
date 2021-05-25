using System;

namespace ChequeEmExtenso.ConsoleApp
{
    public class Excecoes
    {

        public bool Validar(string numero)
        {
            bool testarValidacao = true;

            testarValidacao = ValidarFormato(numero);

            testarValidacao = ValidarQuantia(numero);

            testarValidacao = ValidarVirgula(numero);

            return testarValidacao;
        }

        private bool ValidarVirgula(string numero)
        {
            if (!numero.Contains(","))
            {
                Console.WriteLine("Erro! É necessário definir os centavos, usando duas 'casas' após uma vírgula, mesmo que totalizem (zero).");
                Console.ReadLine();
                return false;
            }
            return true;
        }

        private bool ValidarQuantia(string numero)
        {
            if (!(double.Parse(numero) > 0))
            {
                Console.WriteLine("Erro! O número não pode ser igual ou menor que 0 (zero). ");
                Console.ReadLine();
                return false;
            }
            return true;
        }

        private bool ValidarFormato(string numero)
        {
            try
            {
                double testeNumero = double.Parse(numero);
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro!\nFormato inválido ou nulo. Tente novamente...");
                Console.ReadLine();
                return false;
            }
            return true;
        }
    }
}