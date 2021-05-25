using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeEmExtenso.ConsoleApp
{
    public class Controlador
    {
        Dominio numerosDominio = new Dominio();
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
                    int armazenadorDigitoNumero = 0; 
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
                            armazenadorDigitoNumero = (tamanhoDonumero % 3) + 1;
                            acronimoNumero = "centos ";

                            if (int.Parse(numero) > 100 && int.Parse(numero) < 200)
                                acronimoNumero = " cento e ";

                            if (int.Parse(numero) >= 200 && int.Parse(numero) < 300)
                                if (numero == "200")
                                    acronimoNumero = "duzentos";
                                else
                                    acronimoNumero = "duzentos e ";

                            if (int.Parse(numero) >= 300 && int.Parse(numero) < 400)
                                if (numero == "300")
                                    acronimoNumero = "trezentos";
                                else
                                    acronimoNumero = "trezentos e ";

                            break;
                        case 4:
                        case 5:
                        case 6:
                            armazenadorDigitoNumero = (tamanhoDonumero % 4) + 1;
                            acronimoNumero = " mil ";
                            if (int.Parse(numero) > 1000 && int.Parse(numero) < 2000)
                                acronimoNumero = " mil e ";
                            break;
                        case 7:
                        case 8:
                        case 9:
                            armazenadorDigitoNumero = (tamanhoDonumero % 7) + 1;
                            acronimoNumero = " milhões ";
                            if (numero.Length == 7 && numero.Substring(0, 1) == "1")
                                acronimoNumero = " milhão";
                            break;
                        case 10:
                        case 11:
                        case 12:

                            armazenadorDigitoNumero = (tamanhoDonumero % 10) + 1;
                            acronimoNumero = " bilhões ";
                            if (numero.Length == 10 && numero.Substring(0, 1) == "1")
                                acronimoNumero = " bilhão";
                            break;
                        
                        default:
                            ehUnidadeOuDezena = true;
                            break;
                    }

                    string a = numero.Substring(armazenadorDigitoNumero);

                    if (!ehUnidadeOuDezena)
                    {//if transalation is not done, continue...(Recursion comes in now!!)    
                        if (numero.Substring(0, armazenadorDigitoNumero) != "0" && numero.Substring(armazenadorDigitoNumero) != "0")
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

                        }
                        else
                        {
                            palavraNumeroExtenso = ConveterNumerosGrandes(numero.Substring(0, armazenadorDigitoNumero)) + ConveterNumerosGrandes(numero.Substring(armazenadorDigitoNumero));
                        }

                        //check for trailing zeros    
                        //if (beginsZero) word = " and " + word.Trim();    
                    }
                    //ignore digit grouping names
                    //if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }



            return palavraNumeroExtenso.Trim();
        }

        public string ConverterParaExtenso(string num)
        {
            string valorPalavra = "", numeroGrande = num, numeroDecimal = "", conjuncaoE = "", numeroDecimalPalavra = "";
            string palavraMonetariaFixa = "reais";
            string endStr1Dereais = "de reais";
            string centavos = "";
            try
            {
                int decimalPlace = num.IndexOf(",");
                if (decimalPlace > 0)
                {
                    numeroGrande = num.Substring(0, decimalPlace);
                    numeroDecimal = num.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(numeroDecimal) > 0)
                    {
                        conjuncaoE = " e"; 
                        centavos = " centavos";//Cents    
                        numeroDecimalPalavra = ConverterCentavos(numeroDecimal);
                    }
                }

                if (num.Substring(0, decimalPlace).Length > 6 && (double.Parse(num.Substring(1)) == 0 || (double.Parse(num.Substring(1)) > 0 && double.Parse(num.Substring(1)) < 1)))
                    valorPalavra = String.Format("{0} {1}{2}{3}{4}", ConveterNumerosGrandes(numeroGrande).Trim(), endStr1Dereais, conjuncaoE, numeroDecimalPalavra, centavos);

                else
                    valorPalavra = string.Format("{0} {1}{2}{3}{4}", ConveterNumerosGrandes(numeroGrande).Trim(), palavraMonetariaFixa, conjuncaoE, numeroDecimalPalavra, centavos);

            }

            catch { }

            if ((valorPalavra.Trim().Substring(0, 6) == "um mil" && valorPalavra.Trim().Substring(0, 7) != "um milh") || valorPalavra.Trim().Substring(0, 8) == "um cento")
            {
                valorPalavra = valorPalavra.Remove(0, 3);
            }

            if (valorPalavra.Substring(0, 6) == " reais")
            {
                valorPalavra = string.Format("{0}{1} {2} {3}", numeroDecimalPalavra, centavos, "de", "real");
                if (valorPalavra == " um centavos de real")
                    valorPalavra = " um centavo de real";
            }


            if (valorPalavra.Length >= 10)
            {
                if (valorPalavra.Substring(0, 10) == "um milhões")
                    valorPalavra = "um milhão de reais";

                if (valorPalavra.Substring(0, 10) == "um bilhões")
                    valorPalavra = "um bilhão de reais";
            }
            if (valorPalavra == "um reais")
                valorPalavra = "um real";

            return valorPalavra;
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
