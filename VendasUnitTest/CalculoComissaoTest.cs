using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema.Vendas;

namespace VendasUnitTest
{
    [TestClass]
    public class CalculoComissaoTest
    {
        [TestMethod] 
        public void Test_Venda_de_1000_retorna_comissao_de_50()
        {
           Double comissaoEsperada = 50.0;
           Double totalVendas = 1000.0;
           CalculoComissao calculo = new CalculoComissao();
           Double comissao = calculo.calculaComissao(totalVendas);

           Assert.AreEqual(comissaoEsperada, comissao);
        }

        [TestMethod]
        public void Test_Venda_de_2000_retorna_comissao_de_100()
        {
            Double totalVendas = 2000.0;
            CalculoComissao calculo = new CalculoComissao();
            Double comissao = calculo.calculaComissao(totalVendas);

            Assert.AreEqual(100.0, comissao);
        }

        [TestMethod]
        public void Test_Venda_de_10000_retorna_comissao_de_600()
        {
            Double totalVendas = 10000;
            CalculoComissao calculo = new CalculoComissao();
            Double comissao = calculo.calculaComissao(totalVendas);

            Assert.AreEqual(600, comissao);
        }

        [TestMethod]
        public void Test_Venda_de_77_99_retorna_comissao_de_3_89()
        {
            Double totalVendas = 77.99;
            CalculoComissao calculo = new CalculoComissao();
            Double comissao = calculo.calculaComissao(totalVendas);

            Assert.AreEqual(3.89, comissao);
        }
    }
}
