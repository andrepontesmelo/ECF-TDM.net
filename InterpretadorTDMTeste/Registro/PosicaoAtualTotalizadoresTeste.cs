using InterpretadorTDM;
using InterpretadorTDM.Registro;
using NUnit.Framework;
using System;

namespace InterpretadorTDMTeste.Registro
{
    [TestFixture()]
    public class PosicaoAtualTotalizadoresTeste
    {
        private static readonly string ENTRADA = 
            "E11BE0306SC95510616430A MP-2000 TH FI       00024300000500186000063900028800000000000000050700000000000000000000003332221120150202110119";

        private PosicaoAtualTotalizadores lido;

        [SetUp()]
        public void Setup() 
        {
            lido = PosicaoAtualTotalizadores.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E11_PosicaoAtualTotalizadores, lido.TipoRegistro);
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
        public void DeveLerCRZ()
        {
            Assert.AreEqual(243, lido.CRZ);
        }

        [Test()]
        public void DeveLerCRO()
        {
            Assert.AreEqual(5, lido.CRO);
        }

        [Test()]
        public void DeveLerCOO()
        {
            Assert.AreEqual(1860, lido.COO);
        }

        [Test()]
        public void DeveLerGNF()
        {
            Assert.AreEqual(639, lido.GNF);
        }

        [Test()]
        public void DeveLerCCF()
        {
            Assert.AreEqual(288, lido.CCF);
        }

        [Test()]
        public void DeveLerCVC()
        {
            Assert.AreEqual(0, lido.CVC);
        }

        [Test()]
        public void DeveLerCBP()
        {
            Assert.AreEqual(0, lido.CBP);
        }

        [Test()]
        public void DeveLerGRG()
        {
            Assert.AreEqual(507, lido.GRG);
        }

        [Test()]
        public void DeveLerCMV()
        {
            Assert.AreEqual(0, lido.CMV);
        }

        [Test()]
        public void DeveLerCFD()
        {
            Assert.AreEqual(0, lido.CFD);
        }

        [Test()]
        public void DeveLerTotalizadorGeral()
        {
            Assert.AreEqual(333222.11d, lido.TotalizadorGeral);
        }

        [Test()]
        public void DeveLerDataHoraCaptura()
        {
            Assert.AreEqual(DateTime.Parse("2015-02-02 11:01:19"), lido.DataHoraCaptura);
        }
    }
}
