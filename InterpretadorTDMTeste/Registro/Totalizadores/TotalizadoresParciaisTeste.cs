using NUnit.Framework;
using System;
using InterpretadorTDM;
using System.IO;
using System.Reflection;
using InterpretadorTDM.Registro;
using InterpretadorTDM.Registro.Totalizadores;

namespace InterpretadorTDMTeste.Registro.Totalizadores
{
    [TestFixture()]
    public class TotalizadoresParciaisTeste
    {
        private static readonly string ENTRADA = 
            "E13BE0306SC95510616430A MP-2000 TH FI       01000225DT     9998887776655";

        private TotalizadoresParciais lido;

        [SetUp()]
        public void Setup() 
        {
            lido = TotalizadoresParciais.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E13_TotalizadoresParciais, lido.TipoRegistro);
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
            Assert.AreEqual(225, lido.CRZ);
        }

        [Test()]
        public void DeveLerTotalizador()
        {
            Assert.AreEqual("DT     ", lido.Totalizador);
        }

        [Test()]
        public void DeveLerValorAcumulado()
        {
            Assert.AreEqual(99988877766.55d, lido.ValorAcumulado);
        }

    }
}
