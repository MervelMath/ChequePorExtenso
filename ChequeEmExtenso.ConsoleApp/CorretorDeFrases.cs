namespace ChequeEmExtenso.ConsoleApp
{
    public class CorretorDeFrases
    {
        public string GetCorrecaoUmReais(string palavraFinal)
        {
            if (palavraFinal == "um reais")
                palavraFinal = "um real";
            return palavraFinal = (palavraFinal == "um reais") ? "um real" : palavraFinal;
        }

      

        public bool FraseTemUmMilOuUmCento(string valorPalavra)
        {
            return (valorPalavra.Trim().Substring(0, 6) == "um mil" && valorPalavra.Trim().Substring(0, 7) != "um milh") || valorPalavra.Trim().Substring(0, 8) == "um cento";
        }

        public string UmBilhoes(string palavraFinal)
        {
            return palavraFinal = (palavraFinal.Substring(0, 10) == "um bilhões") ? "um bilhão de reais" : palavraFinal;
        }

        public string UmMilhoes(string palavraFinal)
        {
            return palavraFinal = (palavraFinal.Substring(0, 10) == "um milhões") ? "um milhão de reais" : palavraFinal; ;
        }

        public string FormarPalavrasParaMenosQueUmReal(string palavraFinal, string numeroDecimalPalavra, string centavos)
        {
            if (GetEhMenorQueUmReal(palavraFinal))
            {
                palavraFinal = PalavraParaCentavos(numeroDecimalPalavra, centavos);

                palavraFinal = (palavraFinal == " um centavos de real") ? " um centavo de real" : palavraFinal;
            }

            return palavraFinal;
        }

        public bool GetEhMenorQueUmReal(string palavraFinal)
        {
            return palavraFinal.Substring(0, 6) == " reais";
        }

        public bool GetPrecisaMudarSufixo(string num, int decimalPlace)
        {
            return num.Substring(0, decimalPlace).Length > 6 && (double.Parse(num.Substring(1)) == 0 || (double.Parse(num.Substring(1)) > 0 && double.Parse(num.Substring(1)) < 1));
        }

        public string PalavraParaCentavos(string numeroDecimalPalavra, string centavos)
        {
            return string.Format("{0}{1} {2} {3}", numeroDecimalPalavra, centavos, "de", "real");
        }

       
    }
}