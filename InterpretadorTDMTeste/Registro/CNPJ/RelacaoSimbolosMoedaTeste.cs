using InterpretadorTDM;
using InterpretadorTDM.Registro.CNPJ;
using NUnit.Framework;

namespace InterpretadorTDMTeste.Registro.CNPJ
{
    [TestFixture()]
    public class RelacaoSimbolosMoedaTeste
    {
        private static readonly string ENTRADA = 
            "E06BE0306SC95510616430A MP-2000 TH FI       18219329000103               R  ";

        private RelacaoSimbolosMoeda lido;

        [SetUp()]
        public void Setup() 
        {
            lido = RelacaoSimbolosMoeda.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E06_RelacaoSimbolosMoeda, lido.TipoRegistro);
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
        public void DeveLerDataHoraGravacao()
        {
            Assert.IsNull(lido.DataHoraGravacao);
        }

        [Test()]
        public void DeveLerCNPJ()
        {
            Assert.AreEqual("18219329000103", lido.CNPJUsuario);
        }

        [Test()]
        public void DeveLerSimboloMoeda()
        {
            Assert.AreEqual(" R  ", lido.SimboloMoeda);
        }
    }
}
