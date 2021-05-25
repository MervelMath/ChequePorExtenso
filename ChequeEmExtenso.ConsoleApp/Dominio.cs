using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeEmExtenso.ConsoleApp
{
    public class Dominio
    {
        public string Unidades(string numero)
        {
            int _numero = Convert.ToInt32(numero);
            string nome = "";
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

        public string Dezenas(string numero)
        {
            int _numero = Convert.ToInt32(numero);
            string nome = null;
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
    }
}
