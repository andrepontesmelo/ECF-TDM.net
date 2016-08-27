using InterpretadorTDM;
using InterpretadorTDM.Registro.CNPJ;
using NUnit.Framework;
using System;

namespace InterpretadorTDMTeste.Registro.CNPJ
{
    [TestFixture()]
    public class RelacaoCodificacoesGTTeste
    {
        private static readonly string ENTRADA = 
            "E05BE0306SC95510616430A MP-2000 TH FI       1821932900010320080508172906QWERTYUIOP";

        private RelacaoCodificacoesGT lido;

        [SetUp()]
        public void Setup() 
        {
            lido = RelacaoCodificacoesGT.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E05_RelacaoCodificacoesGT, lido.TipoRegistro);
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
        public void DeveLerDataHoraGravacao()
        {
            Assert.AreEqual(DateTime.Parse("2008-05-08 17:29:06"), lido.DataHoraGravacao);
        }

        [Test()]
        public void DeveLerCodificador()
        {
            Assert.AreEqual("QWERTYUIOP", lido.Codificador);
        }

    }
}
