using InterpretadorTDM;
using InterpretadorTDM.Registro.CNPJ;
using NUnit.Framework;
using System;

namespace InterpretadorTDMTeste.Registro.CNPJ
{
    [TestFixture()]
	public class IdentificacaoECFTeste
	{
        private static readonly string ENTRADA = 
            "E01BE0306SC95510616430A ECF-IF BEMATECH            MP-2000 TH FI       01.03.04  2014120309200598718219329000103TDM000224000243201501012015013101.00.55AC1704 01.00.00";

        private IdentificacaoECF lido;

        [SetUp()]
        public void Setup() 
        {
            lido = IdentificacaoECF.InterpretaLinha(ENTRADA);
        }

		[Test()]
		public void DeveLerTipoRegistro()
		{
            Assert.AreEqual(TipoRegistro.E01_IdentificacaoECF, lido.TipoRegistro);
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
        public void DeveLerTipoECF()
        {
            Assert.AreEqual("ECF-IF", lido.TipoECF);
        }

        [Test()]
        public void DeveLerMarcaECF()
        {
            Assert.AreEqual("BEMATECH            ", lido.MarcaECF);
        }

        [Test()]
        public void DeveLerModeloECF()
        {
            Assert.AreEqual("MP-2000 TH FI       ", lido.ModeloECF);
        }

        [Test()]
        public void DeveLerVersaoSB()
        {
            Assert.AreEqual("01.03.04  ", lido.VersaoSB);
        }

        [Test()]
        public void DeveLerDataHoraGravacaoSB()
        {
            Assert.AreEqual(DateTime.Parse("2014-12-03 09:20:05"), lido.DataHoraGravacaoSB);
        }

        [Test()]
        public void DeveLerNumeroSequencialECF()
        {
            Assert.AreEqual(987, lido.NumeroSequencialECF);
        }

        [Test()]
        public void DeveLerCNPJUsuario()
        {
            Assert.AreEqual("18219329000103", lido.CNPJUsuario);
        }

        [Test()]
        public void DeveLerComandoGeracao()
        {
            Assert.AreEqual("TDM", lido.ComandoGeracao);
        }

        [Test()]
        public void DeveLerCRZInicial()
        {
            Assert.AreEqual(224, lido.CRZInicial);
        }

        [Test()]
        public void DeveLerCRZFinal()
        {
            Assert.AreEqual(243, lido.CRZFinal);
        }

        [Test()]
        public void DeveLerDataInicial()
        {
            Assert.AreEqual(DateTime.Parse("2015-01-01"), lido.DataInicial);
        }

        [Test()]
        public void DeveLerDataFinal()
        {
            Assert.AreEqual(DateTime.Parse("2015-01-31"), lido.DataFinal);
        }

        [Test()]
        public void DeveLerVersaoBiblioteca()
        {
            Assert.AreEqual("01.00.55", lido.VersaoBiblioteca);
        }

        [Test()]
        public void DeveLerVersaoAto()
        {
            Assert.AreEqual("AC1704 01.00.00", lido.VersaoAto);
        }

	}
}
