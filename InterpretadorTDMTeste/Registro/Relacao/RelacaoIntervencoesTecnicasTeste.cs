using InterpretadorTDM;
using InterpretadorTDM.Registro.Relacao;
using NUnit.Framework;
using System;

namespace InterpretadorTDMTeste.Registro.Relacao
{
    [TestFixture()]
    public class RelacaoIntervencoesTecnicasTeste
    {
        private static readonly string ENTRADA = 
            "E09BE0306SC95510616430A MP-2000 TH FI       00000520141203092644S";

        private RelacaoIntervencoesTecnicas lido;

        [SetUp()]
        public void Setup() 
        {
            lido = RelacaoIntervencoesTecnicas.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E09_RelacaoIntervencoesTecnicas, lido.TipoRegistro);
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
        public void DeveLerContadorReinicioOperacao()
        {
            Assert.AreEqual(5, lido.ContadorReinicioOperacao);
        }

        [Test()]
        public void DeveLerDataHoraGravacao()
        {
            Assert.AreEqual(DateTime.Parse("2014-12-03 09:26:44"), lido.DataHoraGravacao);
        }

        [Test()]
        public void DeveLerSimboloMoeda()
        {
            Assert.AreEqual(true, lido.IndicadorPerdaDadosMT);
        }
    }
}
