using System;

namespace InterpretadorTDM.Registro
{
    public class DetalheCupomFiscal : RegistroAbstratoIdentificado
    {
        private int coo;
        private int numeroContadorDocumento;
        private int numeroItem;
        private string codigoProdutoOuServico, descricao;
        private int casasDecimaisQuantidade, casasDecimaisValorUnitario;
        private decimal quantidade;
        private string unidade;
        private decimal valorUnitario;
        private decimal descontoItem;
        private decimal acrescimoItem;
        private decimal valorTotalLiquido;
        private string totalizadorParcial;
        private TipoPagamento indicadorCancelamento;
        private decimal quantidadeCancelada;
        private decimal valorCancelado;
        private decimal cancelamentoAcrescimoItem;
        private char indicadorArredondamentoTruncamento;

        public int COO => coo;
        public int NumeroContadorDocumento => numeroContadorDocumento;
        public int NumeroItem => numeroItem;
        public string CodigoProdutoOuServico => codigoProdutoOuServico;
        public string Descricao => descricao;
        public int CasasDecimaisQuantidade => casasDecimaisQuantidade;
        public int CasasDecimaisValorUnitario => casasDecimaisValorUnitario;
        public decimal Quantidade => quantidade;
        public string Unidade => unidade;
        public decimal ValorUnitario => valorUnitario;
        public decimal DescontoItem => descontoItem;
        public decimal AcrescimoItem => acrescimoItem;
        public decimal ValorTotalLiquido => valorTotalLiquido;
        public string TotalizadorParcial => totalizadorParcial;
        public TipoPagamento IndicadorCancelamento => indicadorCancelamento;
        public decimal QuantidadeCancelada => quantidadeCancelada;
        public decimal ValorCancelado => valorCancelado;
        public decimal CancelamentoAcrescimoItem => cancelamentoAcrescimoItem;
        public char IndicadorArredondamentoTruncamento => indicadorArredondamentoTruncamento;


        public DetalheCupomFiscal(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E15_DetalheCupomFiscal;
            coo = LerInteiro6Digitos(47);
            numeroContadorDocumento = LerInteiro6Digitos(53);
            numeroItem = LerInteiro(59, 62);
            codigoProdutoOuServico = Ler(61, 61+14);
            descricao = Ler(76, 176);

            casasDecimaisQuantidade = LerInteiro(266, 267);
            casasDecimaisValorUnitario = LerInteiro(267, 268);

            quantidade = LerDecimal(176, 176+7, casasDecimaisQuantidade);
            unidade = Ler(183, 185);

            valorUnitario = LerDecimal(186, 186+8, casasDecimaisValorUnitario);
            descontoItem = LerDecimal(194, 194+8, 2);
            acrescimoItem = LerDecimal(202, 202+8, 2);
            valorTotalLiquido = LerDecimal(210, 210+14, 2);
            totalizadorParcial = Ler(224, 224+7);
            indicadorCancelamento = LerTipoPagamento(231);
            quantidadeCancelada = LerDecimal(232, 232+7, casasDecimaisQuantidade);
            valorCancelado = LerDecimal(239, 239+13, 2);
            cancelamentoAcrescimoItem = LerDecimal(252, 252+13, 2);
            indicadorArredondamentoTruncamento = Ler(265);
        }

        public static DetalheCupomFiscal InterpretaLinha(string linha)
        {
            return new DetalheCupomFiscal(linha);
        }
    }
}

