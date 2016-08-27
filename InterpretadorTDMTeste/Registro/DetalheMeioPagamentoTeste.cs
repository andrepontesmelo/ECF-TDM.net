using NUnit.Framework;
using System;
using InterpretadorTDM;
using System.IO;
using System.Reflection;
using InterpretadorTDM.Registro;

namespace InterpretadorTDMTeste.Registro
{
    [TestFixture()]
    public class DetalheMeioPagamentoTeste
    {
        private static readonly string ENTRADA = "E21BE0306SC95510616430A " + 
            "MP-2000 TH FI       01001853000288000000CHEQUE         000000" + 
            "0307853N0000000000000";

        private DetalheMeioPagamento lido;

        [SetUp()]
        public void Setup() 
        {
            lido = DetalheMeioPagamento.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E21_DetalheMeioPagamento, 
                lido.TipoRegistro);
        }

        [Test()]
        public void DeveLerNumeroFabricacao()
        {
            Assert.AreEqual("BE0306SC95510616430", lido.NumeroFabricacao);
        }

        [Test()]
        public void DeveLerMFAdicional()
        {
            Assert.AreEqual('A', lido.MFAdicional);
        }

        [Test()]
        public void DeveLerModeloECF()
        {
            Assert.AreEqual("MP-2000 TH FI       ", lido.ModeloECF);
        }

        [Test()]
        public void DeveLerNumeroUsuario()
        {
            Assert.AreEqual(1, lido.NumeroUsuario);
        }

        [Test()]
        public void DeveLerCOO()
        {
            Assert.AreEqual(1853, lido.COO);
        }

        [Test()]
        public void DeveLerCCF()
        {
            Assert.AreEqual(288, lido.CCF);
        }

        [Test()]
        public void DeveLerGNF()
        {
            Assert.AreEqual(0, lido.GNF);
        }

        [Test()]
        public void DeveLerMeioPagamento()
        {
            Assert.AreEqual("CHEQUE         ", lido.MeioPagamento);
        }

        [Test()]
        public void DeveLerValorPago()
        {
            Assert.AreEqual(3078.53d, lido.ValorPago);
        }

        [Test()]
        public void DeveLerIndicadorCancelamento()
        {
            Assert.AreEqual('N', lido.IndicadorEstorno);
        }

        [Test()]
        public void DeveLerValorEstornado()
        {
            Assert.AreEqual(0d, lido.ValorEstornado);
        }
    }
}
