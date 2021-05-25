using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeEmExtenso.ConsoleApp
{
    public class Numeros
    {
        // public string Centavos(string numero)
        // {
        //     string numeroTest = "centavo";
        //     double novoNumero = Double.Parse(numero);
        //     if (novoNumero < 1)
        //     {
        //         if (novoNumero < 0.10)
        //         {
        //             switch (novoNumero)
        //             {
        //                 case 0.01:
        //                     numeroTest = Unidades("1") + " centavo";
        //                     break;
        //             }
        //         }
        //     }
        //     return numeroTest;
        // }

        public String Unidades(String numero)
        {
            int _numero = Convert.ToInt32(numero);
            String nome = "";
            switch (_numero)
            {
                case 1:
                    nome = "um";
                    break;
                case 2:
                    nome = "dois";
                    break;
                case 3:
                    nome = "três";
                    break;
                case 4:
                    nome = "quatro";
                    break;
                case 5:
                    nome = "cinco";
                    break;
                case 6:
                    nome = "seis";
                    break;
                case 7:
                    nome = "sete";
                    break;
                case 8:
                    nome = "oito";
                    break;
                case 9:
                    nome = "nove";
                    break;
            }
            return nome;
        }

        public String Dezenas(String numero)
        {
            int _numero = Convert.ToInt32(numero);
            String nome = null;
            switch (_numero)
            {
                case 10:
                    nome = "dez";
                    break;
                case 11:
                    nome = "onze";
                    break;
                case 12:
                    nome = "doze";
                    break;
                case 13:
                    nome = "treze";
                    break;
                case 14:
                    nome = "quatorze";
                    break;
                case 15:
                    nome = "quinze";
                    break;
                case 16:
                    nome = "dezesseis";
                    break;
                case 17:
                    nome = "dezessete";
                    break;
                case 18:
                    nome = "dezoito";
                    break;
                case 19:
                    nome = "dezenove";
                    break;
                case 20:
                    nome = "vinte";
                    break;
                case 30:
                    nome = "trinta";
                    break;
                case 40:
                    nome = "quarenta";
                    break;
                case 50:
                    nome = "cinquenta";
                    break;
                case 60:
                    nome = "sessenta";
                    break;
                case 70:
                    nome = "setenta";
                    break;
                case 80:
                    nome = "oitenta";
                    break;
                case 90:
                    nome = "noventa";
                    break;
                default:
                    if (_numero > 0)
                    {
                        if (numero.StartsWith("0"))
                            nome = Unidades(numero.Substring(1));

                        else
                            nome = Dezenas(numero.Substring(0, 1) + "0") + " e " + Unidades(numero.Substring(1));
                        
                    }
                    break;
            }
            return nome;
        }

        public String ConveterNumerosGrandes(String numero)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX    
                bool isDone = false;//test if already translated    
                double dblAmt = (Convert.ToDouble(numero));
                //if ((dblAmt > 0) && number.StartsWith("0"))    
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric    
                    beginsZero = numero.StartsWith("0");

                    int numDigits = numero.Length;
                    int pos = 0;//store digit grouping    
                    String place = "";//digit grouping name:hundres,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' range    

                            word = Unidades(numero);
                            isDone = true;
                            break;
                        case 2://tens' range    
                            word = Dezenas(numero);
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            pos = (numDigits % 3) + 1;
                            place = "centos ";

                            if (int.Parse(numero) > 100 && int.Parse(numero) < 200)
                                place = " cento e ";

                            if (int.Parse(numero) >= 200 && int.Parse(numero) < 300)
                                if (numero == "200")
                                    place = "duzentos";
                            else
                            place = "duzentos e ";

                            if (int.Parse(numero) >= 300 && int.Parse(numero) < 400)
                                if (numero == "300")
                                    place = "trezentos";
                            else
                            place = "trezentos e ";

                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " mil ";
                            if (int.Parse(numero)>1000 && int.Parse(numero)<2000)
                                place = " mil e ";
                            break;
                        case 7://millions' range    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " milhões ";
                            if (numero.Length == 7 && numero.Substring(0, 1) == "1")
                                place = " milhão";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " bilhões ";
                            if (numero.Length == 10 && numero.Substring(0, 1) == "1")
                                place = " bilhão";
                            break;
                        //add extra case options for anything above Billion...    
                        default:
                            isDone = true;
                            break;
                    }

                    string a = numero.Substring(pos);

                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)    
                        if (numero.Substring(0, pos) != "0" && numero.Substring(pos) != "0")
                        {
                            if (numero != "100" && place != "duzentos" && place != "trezentos" && place != "trezentos e " && place != "duzentos e " )
                            {
                                try
                                {
                                    word = ConveterNumerosGrandes(numero.Substring(0, pos)) + place + ConveterNumerosGrandes(numero.Substring(pos));
                                }
                                catch { }
                            }

                            else if (numero == "100")
                                word = "cem" + ConveterNumerosGrandes(numero.Substring(pos));

                            else if (place == "duzentos" || place == "duzentos e ")
                                word = place  + ConveterNumerosGrandes(numero.Substring(pos));

                            else if (place == "trezentos" || place == "trezentos e ")
                                word = place  + ConveterNumerosGrandes(numero.Substring(pos));

                        }
                        else
                        {
                            word = ConveterNumerosGrandes(numero.Substring(0, pos)) + ConveterNumerosGrandes(numero.Substring(pos));
                        }

                        //check for trailing zeros    
                        //if (beginsZero) word = " and " + word.Trim();    
                    }
                    //ignore digit grouping names
                    //if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }



            return word.Trim();
        }

        public String ConvertToWords(String num)
        {
            String val = "", wholeNo = num, points = "", andStr = "", pointStr = "";
            String endStr1 = "reais";
            string endStr1Dereais = "de reais";
            string endStr2 = "";
            try
            {
                int decimalPlace = num.IndexOf(",");
                if (decimalPlace > 0)
                {
                    wholeNo = num.Substring(0, decimalPlace);
                    points = num.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = " e";// just to separate whole numbers from points/cents    
                        endStr2 = " centavos";//Cents    
                        pointStr = ConvertDecimals(points);
                    }
                }

                if (num.Substring(0 , decimalPlace).Length > 6 && (double.Parse(num.Substring(1)) == 0 || (double.Parse(num.Substring(1)) > 0 && double.Parse(num.Substring(1)) < 1)))
                    val = String.Format("{0} {1}{2}{3}{4}", ConveterNumerosGrandes(wholeNo).Trim(), endStr1Dereais, andStr, pointStr, endStr2);

                else
                    val = String.Format("{0} {1}{2}{3}{4}", ConveterNumerosGrandes(wholeNo).Trim(), endStr1, andStr, pointStr, endStr2);
                
            }

            catch { }

            if ((val.Trim().Substring(0, 6) == "um mil" &&  val.Trim().Substring(0, 7) != "um milh") || val.Trim().Substring(0, 8) == "um cento")
            {
                val = val.Remove(0, 3);
            }

            if (val.Substring(0, 6) == " reais")
            {
                val = String.Format("{0}{1} {2} {3}", pointStr, endStr2, "de", "real");
                if (val == " um centavos de real")
                    val = " um centavo de real";
            }


            if (val.Length >= 10)
            {
                if (val.Substring(0, 10) == "um milhões")
                    val = "um milhão de reais";

                if (val.Substring(0, 10) == "um bilhões")
                    val = "um bilhão de reais";
            }
            if (val == "um reais")
                val = "um real";

            return val;
        }

        public String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";

            if (number.Substring(0, 1) == "0")
            {
                for (int i = 0; i < number.Length; i++)
                {
                    digit = number[i].ToString();
                    if (!digit.Equals("0"))
                    {
                        engOne = Unidades(digit);
                        cd += " " + engOne;
                    }

                }
            }

            else
            {
                digit = number.ToString();
                if (!digit.Equals("0"))
                {
                    engOne = Dezenas(digit);
                    cd += " " + engOne;
                }

            }

            return cd;
        }



    }
}
