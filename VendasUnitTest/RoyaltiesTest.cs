using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema.Vendas;
using Moq;
using Sistema_de_vendas;

namespace VendasUnitTest
{
    [TestClass]
    public class RoyaltiesTest
    {
        private Mock<IRepositorioVendas> mockRepository = null;
        private Mock<CalculoComissao> mockComissao = null;
        private CalculoRoyalties calculoRoyalties = null;

        [TestInitialize]
        public void TestInit()
        {
            mockRepository = new Mock<IRepositorioVendas>();
            mockComissao = new Mock<CalculoComissao>();
            calculoRoyalties = new CalculoRoyalties(mockRepository.Object, mockComissao.Object);
        }


        [TestMethod]
        public void Vendas_de_1000_de_mes_retorna_190()
        {
            mockRepository.Setup(mock => mock.GetVendas(2, 2012))
                .Returns(new List<double> { 1000 });

            mockComissao.Setup(mock => mock.calculaComissao(1000)).Returns(50);


            var royalties = calculoRoyalties.CalculaRoyalties(2, 2012);

            Assert.AreEqual(190.0, royalties);
        }

        [TestMethod]
        public void Vendas_de_2000_de_mes_retorna_380()
        {
            mockRepository.Setup(mock => mock.GetVendas(2, 2012))
                .Returns(new List<double> { 2000 });
            
            var royalties = calculoRoyalties.CalculaRoyalties(2, 2012);
            mockRepository.Verify(mock => mock.GetVendas(2, 2012), Times.Once()); 
            
            Assert.AreEqual(380.0, royalties);
        }

        [TestMethod]
        public void Vendas_de_4000_de_mes_retorna_760()
        {
            mockRepository.Setup(mock => mock.GetVendas(2, 2012))
                .Returns(new List<double> { 4000 });

            var royalties = calculoRoyalties.CalculaRoyalties(2, 2012);
            mockRepository.Verify(mock => mock.GetVendas(2, 2012), Times.Once());

            Assert.AreEqual(760.0, royalties);
        }
    }
}
