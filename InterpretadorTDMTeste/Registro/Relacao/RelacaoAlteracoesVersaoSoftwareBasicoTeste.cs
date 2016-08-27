using InterpretadorTDM;
using InterpretadorTDM.Registro.Relacao;
using NUnit.Framework;
using System;

namespace InterpretadorTDMTeste.Registro.Relacao
{
    [TestFixture()]
    public class RelacaoAlteracoesVersaoSoftwareBasicoTeste
    {
        private static readonly string ENTRADA = 
            "E07BE0306SC95510616430A MP-2000 TH FI       01.03.02  20080409";

        private RelacaoAlteracoesVersaoSoftwareBasico lido;

        [SetUp()]
        public void Setup() 
        {
            lido = RelacaoAlteracoesVersaoSoftwareBasico.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E07_RelacaoAlteracoesVersaoSoftwareBasico, lido.TipoRegistro);
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
        public void DeveLerVersaoSB()
        {
            Assert.AreEqual("01.03.02  ", lido.VersaoSB);
        }

        [Test()]
        public void DeveLerDataGravacao()
        {
            Assert.AreEqual(DateTime.Parse("2008-04-09"), lido.DataGravacao);
        }
    }
}
