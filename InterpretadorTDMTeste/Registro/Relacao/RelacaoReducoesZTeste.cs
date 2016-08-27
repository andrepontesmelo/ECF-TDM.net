using InterpretadorTDM;
using InterpretadorTDM.Registro.Relacao;
using NUnit.Framework;
using System;

namespace InterpretadorTDMTeste.Registro.Relacao
{
    [TestFixture()]
    public class RelacaoReducoesZTeste
    {
        private static readonly string ENTRADA = 
            "E12BE0306SC95510616430A MP-2000 TH FI       01000224001663000005201501052015010516384398765432123456S";

        private RelacaoReducoesZ lido;

        [SetUp()]
        public void Setup() 
        {
            lido = RelacaoReducoesZ.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E12_RelacaoReducoesZ, lido.TipoRegistro);
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
            Assert.AreEqual(224, lido.CRZ);
        }

        [Test()]
        public void DeveLerCOO()
        {
            Assert.AreEqual(1663, lido.COO);
        }

        [Test()]
        public void DeveLerCRO()
        {
            Assert.AreEqual(5, lido.CRO);
        }

        [Test()]
        public void DeveLerDataMovimento()
        {
            Assert.AreEqual(DateTime.Parse("2015-01-05"), lido.DataMovimento);
        }

        [Test()]
        public void DeveLerVendaBrutaDiaria()
        {
            Assert.AreEqual(987654321234.56d, lido.VendaBrutaDiaria);
        }

        [Test()]
        public void DeveLerIncidenciaDescontoISSQN()
        {
            Assert.AreEqual(true, lido.IncidenciaDescontoISSQN);
        }

    }
}
