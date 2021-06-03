namespace ChequeEmExtenso.ConsoleApp
{
    public class ExececoesNumericas
    {

        public bool EstaEntreMilEDoisMil(string numero)
        {
            return int.Parse(numero) > 1000 && int.Parse(numero) < 2000;
        }

        public bool EstaNoGrupoDoUmBilhao(string numero)
        {
            return numero.Length == 10 && numero.Substring(0, 1) == "1";
        }

        public bool EstaNoGrupoDoUmMilhao(string numero)
        {
            return numero.Length == 7 && numero.Substring(0, 1) == "1";
        }

        public string GetEhUmNumeroComExcecao(string numero, string acronimoNumero)
        {
            if (EhMaiorQueCemEMenorQueDuzentos(numero))
                acronimoNumero = " cento e ";

            if (EhMaiorOuIgualADuzentosEMenorQueTrezentos(numero))
                if (numero == "200")
                    acronimoNumero = "duzentos";
                else
                    acronimoNumero = "duzentos e ";

            if (EhMaiorOuIgualATrezentosEMenorQueQuatrocentos(numero))
                if (numero == "300")
                    acronimoNumero = "trezentos";
                else
                    acronimoNumero = "trezentos e ";
            return acronimoNumero;
        }

        private static bool EhMaiorOuIgualATrezentosEMenorQueQuatrocentos(string numero)
        {
            return int.Parse(numero) >= 300 && int.Parse(numero) < 400;
        }

        private static bool EhMaiorOuIgualADuzentosEMenorQueTrezentos(string numero)
        {
            return int.Parse(numero) >= 200 && int.Parse(numero) < 300;
        }

        private static bool EhMaiorQueCemEMenorQueDuzentos(string numero)
        {
            return int.Parse(numero) > 100 && int.Parse(numero) < 200;
        }
    }
}