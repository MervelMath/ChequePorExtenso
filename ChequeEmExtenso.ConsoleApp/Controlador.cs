using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeEmExtenso.ConsoleApp
{
    public class Controlador
    {
        private NumerosExtenso numerosDominio = new NumerosExtenso();
        private CorretorDeFrases corretor = new CorretorDeFrases();
        private ExececoesNumericas verificaExcecao = new ExececoesNumericas();

        public string ConveterNumerosGrandes(string numero)
        {

            string palavraNumeroExtenso = "";
            try
            {

                bool ehUnidadeOuDezena = false;
                double numeroEmDouble = (Convert.ToDouble(numero));

                if (numeroEmDouble > 0)
                {


                    int tamanhoDonumero = numero.Length;
                    int finalDoNumeroInicial = 0;
                    string acronimoNumero = "";
                    switch (tamanhoDonumero)
                    {
                        case 1:
                            palavraNumeroExtenso = numerosDominio.Unidades(numero);
                            ehUnidadeOuDezena = true;
                            break;

                        case 2:
                            palavraNumeroExtenso = numerosDominio.Dezenas(numero);
                            ehUnidadeOuDezena = true;
                            break;

                        case 3:
                            finalDoNumeroInicial = (tamanhoDonumero % 3) + 1;
                            acronimoNumero = "centos ";
                            acronimoNumero = verificaExcecao.GetEhUmNumeroComExcecao(numero, acronimoNumero);

                            break;
                        case 4:
                        case 5:
                        case 6:
                            finalDoNumeroInicial = (tamanhoDonumero % 4) + 1;
                            acronimoNumero = " mil ";
                            if (verificaExcecao.EstaEntreMilEDoisMil(numero))
                                acronimoNumero = " mil e ";
                            break;

                        case 7:
                        case 8:
                        case 9:
                            finalDoNumeroInicial = (tamanhoDonumero % 7) + 1;
                            acronimoNumero = " milhões ";
                            if (verificaExcecao.EstaNoGrupoDoUmMilhao(numero))
                                acronimoNumero = " milhão";
                            break;

                        case 10:
                        case 11:
                        case 12:

                            finalDoNumeroInicial = (tamanhoDonumero % 10) + 1;
                            acronimoNumero = " bilhões ";
                            if (verificaExcecao.EstaNoGrupoDoUmBilhao(numero))
                                acronimoNumero = " bilhão";
                            break;

                        default:
                            ehUnidadeOuDezena = true;
                            break;
                    }

                    string a = numero.Substring(finalDoNumeroInicial);

                    if (!ehUnidadeOuDezena && numero.Substring(0, finalDoNumeroInicial) != "0")
                    {
                        palavraNumeroExtenso = ExtensoParaNumerosComExcecoes(numero, palavraNumeroExtenso, finalDoNumeroInicial, acronimoNumero);
                    }

                    else
                    {
                        palavraNumeroExtenso = ConveterNumerosGrandes(numero.Substring(0, finalDoNumeroInicial)) + ConveterNumerosGrandes(numero.Substring(finalDoNumeroInicial));
                    }
                }
            }
            catch { }



            return palavraNumeroExtenso.Trim();
        }

        private string ExtensoParaNumerosComExcecoes(string numero, string palavraNumeroExtenso, int armazenadorDigitoNumero, string acronimoNumero)
        {
            if (numero != "100" && acronimoNumero != "duzentos" && acronimoNumero != "trezentos" && acronimoNumero != "trezentos e " && acronimoNumero != "duzentos e ")
            {
                try
                {
                    palavraNumeroExtenso = ConveterNumerosGrandes(numero.Substring(0, armazenadorDigitoNumero)) + acronimoNumero + ConveterNumerosGrandes(numero.Substring(armazenadorDigitoNumero));
                }
                catch { }
            }

            else if (numero == "100")
                palavraNumeroExtenso = "cem" + ConveterNumerosGrandes(numero.Substring(armazenadorDigitoNumero));

            else if (acronimoNumero == "duzentos" || acronimoNumero == "duzentos e ")
                palavraNumeroExtenso = acronimoNumero + ConveterNumerosGrandes(numero.Substring(armazenadorDigitoNumero));

            else if (acronimoNumero == "trezentos" || acronimoNumero == "trezentos e ")
                palavraNumeroExtenso = acronimoNumero + ConveterNumerosGrandes(numero.Substring(armazenadorDigitoNumero));
            return palavraNumeroExtenso;
        }

        public string ConverterParaExtenso(string num)
        {
            string palavraFinal = "", numeroAntesDaVirgula = num, numeroCentavo = "", conjuncaoE = "", centavosEmExtenso = "";
            string palavraMonetariaFixa = "reais";
            string endStr1Dereais = "de reais";
            string sufixoCentavos = "";
            try
            {
                int decimalPlace = num.IndexOf(",");

                numeroAntesDaVirgula = num.Substring(0, decimalPlace);
                numeroCentavo = num.Substring(decimalPlace + 1);

                if (Convert.ToInt32(numeroCentavo) > 0)
                {
                    conjuncaoE = " e";
                    sufixoCentavos = " centavos";
                    centavosEmExtenso = ConverterCentavos(numeroCentavo);
                }


                if (corretor.GetPrecisaMudarSufixo(num, decimalPlace))
                    palavraFinal = GetFraseParaaSufixoDeReais(numeroAntesDaVirgula, conjuncaoE,
                        centavosEmExtenso, endStr1Dereais, sufixoCentavos);

                else
                    palavraFinal = GetFraseComSufixoNormalReais(numeroAntesDaVirgula, conjuncaoE, centavosEmExtenso,
                        palavraMonetariaFixa, sufixoCentavos);

            }

            catch { }

            if (corretor.FraseTemUmMilOuUmCento(palavraFinal))
            {
                palavraFinal = palavraFinal.Remove(0, 3);
            }

            palavraFinal = corretor.FormarPalavrasParaMenosQueUmReal(palavraFinal, centavosEmExtenso, sufixoCentavos);

            if (palavraFinal.Length >= 10)
            {
                palavraFinal = corretor.UmMilhoes(palavraFinal);

                palavraFinal = corretor.UmBilhoes(palavraFinal);
            }

            palavraFinal = corretor.GetCorrecaoUmReais(palavraFinal);

            return palavraFinal;
        }

        public string GetFraseComSufixoNormalReais(string numeroGrande, string conjuncaoE, string numeroDecimalPalavra, string palavraMonetariaFixa, string centavos)
        {
            return string.Format("{0} {1}{2}{3}{4}", ConveterNumerosGrandes(numeroGrande).Trim(), palavraMonetariaFixa, conjuncaoE, numeroDecimalPalavra, centavos);
        }

        public string GetFraseParaaSufixoDeReais(string numeroGrande, string conjuncaoE, string numeroDecimalPalavra, string endStr1Dereais, string centavos)
        {
            return String.Format("{0} {1}{2}{3}{4}", ConveterNumerosGrandes(numeroGrande).Trim(), endStr1Dereais, conjuncaoE, numeroDecimalPalavra, centavos);
        }

        public string ConverterCentavos(string numero)
        {
            string centavosExtenso = "", digito = "", centavosUnidade = "";

            if (numero.Substring(0, 1) == "0")
            {
                for (int i = 0; i < numero.Length; i++)
                {
                    digito = numero[i].ToString();
                    if (!digito.Equals("0"))
                    {
                        centavosUnidade = numerosDominio.Unidades(digito);
                        centavosExtenso += " " + centavosUnidade;
                    }

                }
            }

            else
            {
                digito = numero.ToString();
                if (!digito.Equals("0"))
                {
                    centavosUnidade = numerosDominio.Dezenas(digito);
                    centavosExtenso += " " + centavosUnidade;
                }

            }

            return centavosExtenso;
        }
    }
}
