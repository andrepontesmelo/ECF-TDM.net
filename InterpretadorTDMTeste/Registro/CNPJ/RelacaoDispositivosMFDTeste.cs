using InterpretadorTDM;
using InterpretadorTDM.Registro.CNPJ;
using NUnit.Framework;

namespace InterpretadorTDMTeste.Registro.CNPJ
{
    [TestFixture()]
    public class RelacaoDispositivosMFDTeste
    {
        private static readonly string ENTRADA = 
            "E08BE0306SC95510616430A MP-2000 TH FI       182193290001038751080365654       ";

        private RelacaoDispositivosMFD lido;

        [SetUp()]
        public void Setup() 
        {
            lido = RelacaoDispositivosMFD.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E08_RelacaoDispositivosMFD, lido.TipoRegistro);
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
        public void DeveLerCNPJ()
        {
            Assert.AreEqual("18219329000103", lido.CNPJUsuario);
        }

        [Test()]
        public void DeveLerNumeroSerieMFD()
        {
            Assert.AreEqual("8751080365654       ", lido.NumeroSerieMFD);
        }
    }
}
