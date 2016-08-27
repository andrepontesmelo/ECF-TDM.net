using InterpretadorTDM;
using InterpretadorTDM.Registro;
using NUnit.Framework;
using System;

namespace InterpretadorTDMTeste.Registro
{
    [TestFixture()]
    public class DemaisDocumentosEmitidosTeste
    {
        private static readonly string ENTRADA = "E16BE0306SC95510616430A " + 
            "MP-2000 TH FI       010018140000000000000000000238RZ20150123163313";

        private DemaisDocumentosEmitidos lido;

        [SetUp()]
        public void Setup() 
        {
            lido = DemaisDocumentosEmitidos.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E16_DemaisDocumentosEmitidos, lido.TipoRegistro);
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
            Assert.AreEqual(1814, lido.COO);
        }

        [Test()]
        public void DeveLerGNF()
        {
            Assert.AreEqual(0, lido.GNF);
        }

        [Test()]
        public void DeveLerGRG()
        {
            Assert.AreEqual(0, lido.GRG);
        }

        [Test()]
        public void DeveLerCDC()
        {
            Assert.AreEqual(0, lido.CDC);
        }

        [Test()]
        public void DeveLerCRZ()
        {
            Assert.AreEqual(238, lido.CRZ);
        }

        [Test()]
        public void DeveLerDenominacao()
        {
            Assert.AreEqual("RZ", lido.Denominacao);
        }

        [Test()]
        public void DeveLerDataHoraFinalEmissao()
        {
            Assert.AreEqual(DateTime.Parse("2015-01-23 16:33:13"), lido.DataHoraFinalEmissao);
        }
    }
}
