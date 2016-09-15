using InterpretadorTDM;
using InterpretadorTDM.Registro;
using NUnit.Framework;

namespace InterpretadorTDMTeste.Registro
{
    [TestFixture()]
    public class DetalheCupomFiscalTeste
    {
        private static readonly string ENTRADA = "E15BE0306SC95510616430A " + 
            "MP-2000 TH FI       010016560001870010201011009406 Alian     " +
            "                                                             " +
            "                             0004900GR 0001680400000000000000" + 
            "000000000008233901T1800N000000000000000000000000000000000T32";

        private DetalheCupomFiscal lido;

        [SetUp()]
        public void Setup() 
        {
            lido = DetalheCupomFiscal.InterpretaLinha(ENTRADA);
        }

        [Test()]
        public void DeveLerTipoRegistro()
        {
            Assert.AreEqual(TipoRegistro.E15_DetalheCupomFiscal, 
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
        public void DeveLerCOO()
        {
            Assert.AreEqual(1656, lido.COO);
        }

        [Test()]
        public void DeveLerNumeroContadorDocumento()
        {
            Assert.AreEqual(187, lido.NumeroContadorDocumento);
        }

        [Test()]
        public void DeveLerNumeroItem()
        {
            Assert.AreEqual(1, lido.NumeroItem);
        }

        [Test()]
        public void DeveLerCodigoProdutoOuServico()
        {
            Assert.AreEqual("0201011009406 ", lido.CodigoProdutoOuServico);
        }

        [Test()]
        public void DeveLerDescricao()
        {
            Assert.AreEqual("Alian                                       " + 
                "                                                        ", 
                lido.Descricao);
        }

        [Test()]
        public void DeveLerQuantidade()
        {
            Assert.AreEqual(4.900d, lido.Quantidade);
        }

        [Test()]
        public void DeveLerValorUnitario()
        {
            Assert.AreEqual(168.04d, lido.ValorUnitario);
        }

        [Test()]
        public void DeveLerDescontoItem()
        {
            Assert.AreEqual(0d, lido.DescontoItem);
        }

        [Test()]
        public void DeveLerAcrescimoItem()
        {
            Assert.AreEqual(0d, lido.AcrescimoItem);
        }

        [Test()]
        public void DeveLerValorTotalLiquido()
        {
            Assert.AreEqual(823.39d, lido.ValorTotalLiquido);
        }

        [Test()]
        public void DeveLerTotalizadorParcial()
        {
            Assert.AreEqual("01T1800", lido.TotalizadorParcial);
        }

        [Test()]
        public void DeveLerIndicadorCancelamento()
        {
            Assert.AreEqual(TipoPagamento.Vazio, lido.IndicadorCancelamento);
        }

        [Test()]
        public void DeveLerQuantidadeCancelada()
        {
            Assert.AreEqual(0, lido.QuantidadeCancelada);
        }

        [Test()]
        public void DeveLerValorCancelado()
        {
            Assert.AreEqual(0d, lido.ValorCancelado);
        }

        [Test()]
        public void DeveLerCancelamentoAcrescimoItem()
        {
            Assert.AreEqual(0d, lido.CancelamentoAcrescimoItem);
        }

        [Test()]
        public void DeveLerIndicadorArredondamentoTruncamento()
        {
            Assert.AreEqual('T', lido.IndicadorArredondamentoTruncamento);
        }

        [Test()]
        public void DeveLerCasasDecimaisQuantidade()
        {
            Assert.AreEqual(3, lido.CasasDecimaisQuantidade);
        }

        [Test()]
        public void DeveLerCasasDecimaisValorUnitario()
        {
            Assert.AreEqual(2, lido.CasasDecimaisValorUnitario);
        }
    }
}
