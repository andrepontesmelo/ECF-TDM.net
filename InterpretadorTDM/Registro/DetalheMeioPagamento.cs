using System;

namespace InterpretadorTDM.Registro
{
    public class DetalheMeioPagamento : RegistroAbstratoIdentificado
    {
        private int coo, ccf, gnf;
        private decimal valorPago;
        private decimal valorEstornado;
        private string meioPagamento;
        private TipoPagamento indicadorEstorno;

        public int COO => coo;
        public int CCF => ccf;
        public int GNF => gnf;
        public decimal ValorPago => valorPago;
        public decimal ValorEstornado => valorEstornado;
        public string MeioPagamento => meioPagamento;
        public TipoPagamento IndicadorEstorno => indicadorEstorno;

        public DetalheMeioPagamento(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E21_DetalheMeioPagamento;

            coo = LerInteiro6Digitos(47);
            ccf = LerInteiro6Digitos(53);
            gnf = LerInteiro6Digitos(59);
            meioPagamento = Ler(65, 65+15);
            valorPago = LerDecimal(80, 80+13, 2);
            indicadorEstorno = LerTipoPagamento(93);
            valorEstornado = LerDecimal(94, 94+13, 2);
        }

        public static DetalheMeioPagamento InterpretaLinha(string linha)
        {
            return new DetalheMeioPagamento(linha);
        }
    }
}


