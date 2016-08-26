using System;

namespace InterpretadorTDM.Registro
{
    public class PosicaoAtualTotalizadores : RegistroAbstrato
    {
        private int crz, cro, coo, gnf, ccf, cvc, cbp, grg, cmv, cfd;
        private decimal totalizadorGeral;
        private DateTime dataHoraCaptura;

        public int CRZ => crz;
        public int CRO => cro;
        public int COO => coo;
        public int GNF => gnf;
        public int CCF => ccf;
        public int CVC => cvc;
        public int CBP => cbp;
        public int GRG => grg;
        public int CMV => cmv;
        public int CFD => cfd;

        public decimal TotalizadorGeral => totalizadorGeral;
        public DateTime DataHoraCaptura => dataHoraCaptura;

        public PosicaoAtualTotalizadores(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E11_PosicaoAtualTotalizadores;

            crz = LerInteiro6Digitos(45);
            cro = LerInteiro6Digitos(51);
            coo = LerInteiro6Digitos(57);
            gnf = LerInteiro6Digitos(63);
            ccf = LerInteiro6Digitos(69);
            cvc = LerInteiro6Digitos(75);
            cbp = LerInteiro6Digitos(81);
            grg = LerInteiro6Digitos(87);
            cmv = LerInteiro6Digitos(93);
            cfd = LerInteiro6Digitos(99);

            totalizadorGeral = LerDecimal(105, 123, 2);
            dataHoraCaptura = LerDataHora(123, 137).Value;
        }

        public static PosicaoAtualTotalizadores InterpretaLinha(string linha)
        {
            return new PosicaoAtualTotalizadores(linha);
        }
    }
}

