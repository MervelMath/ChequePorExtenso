using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChequeEmExtenso.ConsoleApp;
namespace Validar.Test
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// USE SEMPRE VÍRGULLA PARA DEFINIR AS CASAS DOS CENTAVOS, AINDA QUE VALHAM ZERO (00).
        /// </summary>

        [TestMethod]
        public void ValidarDezenaComCentavo()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("10,05");

            Assert.AreEqual("dez reais e cinco centavos", test);
        }

        [TestMethod]
        public void ValidarMaisDeMilMenosDeDoisMil()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("1001,00");

            Assert.AreEqual("mil e um reais", test);
        }


        [TestMethod]
        public void ValidarDezenaComDezenaDeCentavo()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("10,25");

            Assert.AreEqual("dez reais e vinte e cinco centavos", test);
        }

       

        [TestMethod]
        public void ValidarCentena()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("110,00");

            Assert.AreEqual("cento e dez reais", test);
        }

        [TestMethod]
        public void ValidarDezenaPura()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("10,00");

            Assert.AreEqual("dez reais", test);
        }

        [TestMethod]
        public void ValidarUmReal()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("1,00");

            Assert.AreEqual("um real", test);
        }

        [TestMethod]
        public void VallidarCentavoPuro()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("0,05");

            Assert.AreEqual(" cinco centavos de real", test);
        }

        [TestMethod]
        public void ValidarUmCentavo()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("0,01");

            Assert.AreEqual(" um centavo de real", test);
        }

        [TestMethod]
        public void ValidarDuzentos()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("200,00");

            Assert.AreEqual("duzentos reais", test);
        }

        [TestMethod]
        public void ValidarTrezentos()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("300,00");

            Assert.AreEqual("trezentos reais", test);
        }

        [TestMethod]
        public void ValidarTrezentosComDEzenaECentavos()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("310,25");

            Assert.AreEqual("trezentos e dez reais e vinte e cinco centavos", test);
        }

        [TestMethod]
        public void ValidarUmMilhao()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("1000000,00");

            Assert.AreEqual("um milhão de reais", test);
        }

        [TestMethod]
        public void ValidarCemMil()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("100000,00");

            Assert.AreEqual("cem mil reais", test);
        }

        [TestMethod]
        public void ValidarNumeroGrandeMilhao()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("206699000,00");

            Assert.AreEqual("duzentos e seis milhões seiscentos noventa e nove mil reais", test);
        }

        [TestMethod]
        public void ValidarNumeroGrandeMilhaoComCentavos()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("206699000,05");

            Assert.AreEqual("duzentos e seis milhões seiscentos noventa e nove mil reais e cinco centavos", test);
        }

        [TestMethod]
        public void ValidarMilhaoComCentavos()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("1000000,05");

            Assert.AreEqual("um milhão de reais e cinco centavos", test);
        }

        [TestMethod]
        public void ValidarUmBilhao()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("1000000000,00");

            Assert.AreEqual("um bilhão de reais", test);
        }

        [TestMethod]
        public void ValidarDezMilComCentavos()
        {
            Controlador numeroTeste = new Controlador();
            string test = numeroTeste.ConverterParaExtenso("10000,05");

            Assert.AreEqual("dez mil reais e cinco centavos", test);
        }

    }
}
