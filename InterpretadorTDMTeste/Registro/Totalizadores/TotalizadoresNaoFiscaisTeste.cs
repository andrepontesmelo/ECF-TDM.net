using NUnit.Framework;
using System;
using InterpretadorTDM;
using System.IO;
using System.Reflection;
using InterpretadorTDM.Registro.Totalizadores;

namespace InterpretadorTDMTeste.Registro.Totalizadores
{
    [TestFixture()]
    public class TotalizadoresNaoFiscaisTeste
    {
        private static readonly string ENTRADA = 
            "E17BE0306SC95510616430A MP-2000 TH FI       01000239Suprimento     0000000000000";

        private TotalizadoresNaoFiscais lido;

        [SetUp()]
        public void Setup() 
        {
            lido = TotalizadoresNaoFiscais.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E17_TotalizadoresNaoFiscais, lido.TipoRegistro);
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
            Assert.AreEqual(239, lido.CRZ);
        }

        [Test()]
        public void DeveLerTotalizador()
        {
            Assert.AreEqual("Suprimento     ", lido.Totalizador);
        }

        [Test()]
        public void DeveLerValorAcumulado()
        {
            Assert.AreEqual(0d, lido.ValorAcumulado);
        }

    }
}
