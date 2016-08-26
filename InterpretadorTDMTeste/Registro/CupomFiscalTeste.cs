using NUnit.Framework;
using System;
using InterpretadorTDM;
using System.IO;
using System.Reflection;
using InterpretadorTDM.Registro;

namespace InterpretadorTDMTeste.Registro
{
    [TestFixture()]
    public class CupomFiscalTeste
    {
        private static readonly string ENTRADA = 
            "E14BE0306SC95510616430A MP-2000 TH FI       0100021200170220150109000000000143330000000000000V0000000000000V00000000014333N0000000000000 a                                      z00000000000000";

        private CupomFiscal lido;


        [SetUp()]
        public void Setup() 
        {
            lido = CupomFiscal.InterpretaLinha(ENTRADA);
        }


        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E14_CupomFiscal, lido.TipoRegistro);
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
        public void DeveLerNumeroContadorDocumentoEmitido()
        {
            Assert.AreEqual(212, lido.NumeroContadorDocumentoEmitido);
        }

        [Test()]
        public void DeveLerCOO()
        {
            Assert.AreEqual(1702, lido.COO);
        }

        [Test()]
        public void DeveLerDataInicioEmissao()
        {
            Assert.AreEqual(DateTime.Parse("2015-01-09"), lido.DataInicioEmissao);
        }


        [Test()]
        public void DeveLerSubtotal()
        {
            Assert.AreEqual(143.33, lido.Subtotal);
        }

        [Test()]
        public void DeveLerDescontoSubtotal()
        {
            Assert.AreEqual(0d, lido.DescontoSubtotal);
        }

        [Test()]
        public void DeveLerTipoDescontoSubtotal()
        {
            Assert.AreEqual(TipoValor.Monetario, lido.TipoDescontoSubtotal);
        }

        [Test()]
        public void DeveLerAcrescimoSubtotal()
        {
            Assert.AreEqual(0d, lido.AcrescimoSubtotal);
        }

        [Test()]
        public void DeveLerTipoAcrescimoSubtotal()
        {
            Assert.AreEqual(TipoValor.Monetario, lido.TipoAcrescimoSubtotal);
        }

        [Test()]
        public void DeveLerValorTotalLiquido()
        {
            Assert.AreEqual(143.33d, lido.ValorTotalLiquido);
        }

        [Test()]
        public void DeveLerIndicadorCancelamento()
        {
            Assert.AreEqual(false, lido.IndicadorCancelamento);
        }

        [Test()]
        public void DeveLerCancelamentoAcrescimoSubtotal()
        {
            Assert.AreEqual(0d, lido.CancelamentoAcrescimoSubtotal);
        }

        [Test()]
        public void DeveLerOrdemPrimeiroAcrescimo()
        {
            Assert.AreEqual(TipoAplicacao.Nenhum, lido.OrdemPrimeiroAcrescimo);
        }

        [Test()]
        public void DeveLerNomeAdquirente()
        {
            Assert.AreEqual("a                                      z", lido.NomeAdquirente);
        }

        [Test()]
        public void DeveLerCPFCNPJAdquirente()
        {
            Assert.AreEqual("00000000000000", lido.CPFCNPJAdquirente);
        }
    }
}
