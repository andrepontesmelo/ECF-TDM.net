using System;
using System.Collections.Generic;

namespace InterpretadorTDM.Registro
{
    public class CupomFiscal : RegistroAbstratoIdentificado
    {
        private int numeroContadorDocumentoEmitido;
        private int coo;
        private DateTime dataInicioEmissao;
        private decimal subtotal, descontoSubtotal, acrescimoSubtotal;
        private TipoValor tipoDescontoSubtotal, tipoAcrescimoSubtotal;
        private decimal valorTotalLiquido, cancelamentoAcrescimoSubtotal;
        private bool indicadorCancelamento;
        private TipoAplicacao ordemPrimeiroAcrescimo;
        private string nomeAdquirente, cpfCnpjAdquirente;

        public int NumeroContadorDocumentoEmitido => numeroContadorDocumentoEmitido;
        public int COO => coo;
        public DateTime DataInicioEmissao => dataInicioEmissao;
        public decimal Subtotal => subtotal;
        public decimal DescontoSubtotal => descontoSubtotal;
        public TipoValor TipoDescontoSubtotal => tipoDescontoSubtotal;
        public decimal AcrescimoSubtotal => acrescimoSubtotal;
        public TipoValor TipoAcrescimoSubtotal => tipoAcrescimoSubtotal;
        public decimal ValorTotalLiquido => valorTotalLiquido;
        public bool IndicadorCancelamento => indicadorCancelamento;
        public decimal CancelamentoAcrescimoSubtotal => cancelamentoAcrescimoSubtotal;
        public TipoAplicacao OrdemPrimeiroAcrescimo => ordemPrimeiroAcrescimo;
        public string NomeAdquirente => nomeAdquirente;
        public string CPFCNPJAdquirente => cpfCnpjAdquirente;

        private List<DetalheCupomFiscal> detalhes = new List<DetalheCupomFiscal>();
        private List<DetalheMeioPagamento> detalhesMeioPagamentos = new List<DetalheMeioPagamento>();

        public List<DetalheCupomFiscal> Detalhes => detalhes;
        public List<DetalheMeioPagamento> DetalhesMeioPagamentos => detalhesMeioPagamentos;

        public CupomFiscal(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E14_CupomFiscal;
            numeroContadorDocumentoEmitido = LerInteiro6Digitos(47);
            coo = LerInteiro6Digitos(53);
            dataInicioEmissao = LerData(59).Value;
            subtotal = LerDecimal(67, 81, 2);
            descontoSubtotal = LerDecimal(81, 94, 2);
            tipoDescontoSubtotal = LerTipoValor(94);
            acrescimoSubtotal = LerDecimal(95, 108, 2);
            tipoAcrescimoSubtotal = LerTipoValor(108);
            valorTotalLiquido = LerDecimal(109, 123, 2);
            indicadorCancelamento = LerBooleano(123);
            cancelamentoAcrescimoSubtotal = LerDecimal(124, 137, 2);
            ordemPrimeiroAcrescimo = LerTipoAplicacao(137);
            nomeAdquirente = Ler(138, 138+40);
            cpfCnpjAdquirente = Ler(178, 178+14);
        }

        public static CupomFiscal InterpretaLinha(string linha)
        {
            return new CupomFiscal(linha);
        }
    }
}

