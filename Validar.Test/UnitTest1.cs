using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChequeEmExtenso.ConsoleApp;

namespace Validar.Test
{
    [TestClass]
    public class UnitTest1
    {
      //  [TestMethod]
      //  public  void TestMethod1()
      //  {
      //      Tela tela = new Tela();
      //      string test = tela.Entrada
      //
      //      Assert.AreEqual("dez", test);
      //  }



        [TestMethod]
        public void ValidarDezenaComCentavo()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("10,05");

            Assert.AreEqual("dez reais e cinco centavos", test);
        }

        [TestMethod]
        public void ValidarDezenaComDezenaDeCentavo()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("10,25");

            Assert.AreEqual("dez reais e vinte e cinco centavos", test);
        }

       

        [TestMethod]
        public void ValidarCentena()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("110,00");

            Assert.AreEqual("cento e dez reais", test);
        }

        [TestMethod]
        public void ValidarDezenaPura()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("10,00");

            Assert.AreEqual("dez reais", test);
        }

        [TestMethod]
        public void ValidarUmReal()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("1,00");

            Assert.AreEqual("um real", test);
        }

        [TestMethod]
        public void VallidarCentavoPuro()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("0,05");

            Assert.AreEqual(" cinco centavos de real", test);
        }

        [TestMethod]
        public void ValidarUmCentavo()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("0,01");

            Assert.AreEqual(" um centavo de real", test);
        }

        [TestMethod]
        public void ValidarDuzentos()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("200,00");

            Assert.AreEqual("duzentos reais", test);
        }

        [TestMethod]
        public void ValidarTrezentos()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("300,00");

            Assert.AreEqual("trezentos reais", test);
        }

        [TestMethod]
        public void ValidarTrezentosComDEzenaECentavos()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("310,25");

            Assert.AreEqual("trezentos e dez reais e vinte e cinco centavos", test);
        }

        [TestMethod]
        public void ValidarUmMilhao()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("1000000,00");

            Assert.AreEqual("um milhão de reais", test);
        }

        [TestMethod]
        public void ValidarCemMil()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("100000,00");

            Assert.AreEqual("cem mil reais", test);
        }

        [TestMethod]
        public void ValidarNumeroGrandeMilhao()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("206699000,00");

            Assert.AreEqual("duzentos e seis milhões seiscentos noventa e nove mil reais", test);
        }

        [TestMethod]
        public void ValidarNumeroGrandeMilhaoComCentavos()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("206699000,05");

            Assert.AreEqual("duzentos e seis milhões seiscentos noventa e nove mil reais e cinco centavos", test);
        }

        [TestMethod]
        public void ValidarMilhaoComCentavos()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("1000000,05");

            Assert.AreEqual("um milhão de reais e cinco centavos", test);
        }

        [TestMethod]
        public void ValidarUmBilhao()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("1000000000,00");

            Assert.AreEqual("um bilhão de reais", test);
        }

        [TestMethod]
        public void ValidarDezMilComCentavos()
        {
            Numeros numeroTeste = new Numeros();
            string test = numeroTeste.ConvertToWords("10000,05");

            Assert.AreEqual("dez mil reais e cinco centavos", test);
        }

    }
}
