using InterpretadorTDM;
using InterpretadorTDM.Registro;
using NUnit.Framework;

namespace InterpretadorTDMTeste.Registro
{
    [TestFixture()]
    public class MeioPagamentoTeste
    {
        private static readonly string ENTRADA = "E18BE0306SC95510616430A " +
            "MP-2000 TH FI       01000243TROCO          0000000000000";

        private MeioPagamento lido;

        [SetUp()]
        public void Setup()
        {
            lido = MeioPagamento.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E18_MeioPagamento,
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
        public void DeveLerCRZ()
        {
            Assert.AreEqual(243, lido.CRZ);
        }

        [Test()]
        public void DeveLerDescricao()
        {
            Assert.AreEqual("TROCO          ", lido.Descricao);
        }

        [Test()]
        public void DeveLerValorAcumulado()
        {
            Assert.AreEqual(0d, lido.ValorAcumulado);
        }
    }
}
