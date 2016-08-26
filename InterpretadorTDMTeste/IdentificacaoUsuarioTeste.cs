using NUnit.Framework;
using System;
using InterpretadorTDM;
using System.IO;
using System.Reflection;

namespace InterpretadorTDMTeste
{
    [TestFixture()]
    public class IdentificacaoUsuarioTeste
    {
        private static readonly string ENTRADA = 
            "E02BE0306SC95510616430A MP-2000 TH FI       182193290001030621400540037         INDUSTRIA MINEIRA DE JOIAS LTDA        RUA POUSO ALEGRE, 546 - FLORESTA         BELO HORIZONTE - MINAS GERAIS                                           2008050817460000000200000000001234569801";
        
        private IdentificacaoUsuario lido;

        [SetUp()]
        public void Setup() 
        {
            lido = IdentificacaoUsuario.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E02_IdentificacaoUsuario, lido.TipoRegistro);
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
        public void DeveLerCNPJUsuario()
        {
            Assert.AreEqual("18219329000103", lido.CNPJUsuario);
        }

        [Test()]
        public void DeveLerInscricaoEstadual()
        {
            Assert.AreEqual("0621400540037", lido.InscricaoEstadual);
        }

        [Test()]
        public void DeveLerNomeContribuinte()
        {
            Assert.AreEqual("         INDUSTRIA MINEIRA DE JOIAS LTDA", lido.NomeContribuinte);
        }

        [Test()]
        public void DeveLerEndereco()
        {
            Assert.AreEqual("        RUA POUSO ALEGRE, 546 - FLORESTA         BELO HORIZONTE - MINAS GERAIS                                           ", lido.Endereco);
        }

        [Test()]
        public void DeveLerDataHoraCadastro()
        {
            Assert.AreEqual(DateTime.Parse("2008-05-08 17:46:00"), lido.DataHoraCadastro);
        }

        [Test()]
        public void DeveLerContadorReinicioOperacao()
        {
            Assert.AreEqual(2, lido.ContadorReinicioOperacao);
        }

        [Test()]
        public void DeveLerTotalizadorGeral()
        {
            Assert.AreEqual(123456.98d, lido.TotalizadorGeral);
        }

        [Test()]
        public void DeveLerNumeroUsuario()
        {
            Assert.AreEqual(1, lido.NumeroUsuario);
        }

    }
}
