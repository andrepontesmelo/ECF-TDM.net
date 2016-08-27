using InterpretadorTDM;
using InterpretadorTDM.Registro.CNPJ;
using NUnit.Framework;

namespace InterpretadorTDMTeste.Registro.CNPJ
{
    [TestFixture()]
    public class RelacaoFitasDetalheEmitidasTeste
    {
        private static readonly string ENTRADA = 
            "E10BE0306SC95510616430A MP-2000 TH FI       321555        11111122222233333333333333";

        private RelacaoFitasDetalheEmitidas lido;

        [SetUp()]
        public void Setup() 
        {
            lido = RelacaoFitasDetalheEmitidas.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E10_RelacaoFitasDetalheEmitidas, lido.TipoRegistro);
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
        public void DeveLerContadorFitaDetalhe()
        {
            Assert.AreEqual(321555, lido.ContadorFitaDetalhe);
        }

        [Test()]
        public void DeveLerDataEmissao()
        {
            Assert.IsNull(lido.DataEmissao);
        }

        [Test()]
        public void DeveLerCOOInicial()
        {
            Assert.AreEqual(111111, lido.COOInicial);
        }

        [Test()]
        public void DeveLerCOOFinal()
        {
            Assert.AreEqual(222222, lido.COOFinal);
        }

        [Test()]
        public void DeveLerCNPJ()
        {
            Assert.AreEqual("33333333333333", lido.CNPJUsuario);
        }
    }
}
