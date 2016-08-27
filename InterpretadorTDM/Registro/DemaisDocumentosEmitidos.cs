using System;

namespace InterpretadorTDM.Registro
{
    public class DemaisDocumentosEmitidos : RegistroAbstrato
    {
        private int numeroUsuario;
        private int coo, gnf, grg, cdc, crz;
        private string denominacao;
        private DateTime dataHoraFinalEmissao;

        public int NumeroUsuario => numeroUsuario;
        public int COO => coo;
        public int GNF => gnf;
        public int GRG => grg;
        public int CDC => cdc;
        public int CRZ => crz;
        public string Denominacao => denominacao;
        public DateTime DataHoraFinalEmissao => dataHoraFinalEmissao;

        public DemaisDocumentosEmitidos(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E16_DemaisDocumentosEmitidos;
            numeroUsuario = LerInteiro(45, 47);
            coo = LerInteiro6Digitos(47);
            gnf = LerInteiro6Digitos(53);
            grg = LerInteiro6Digitos(59);
            cdc = LerInteiro(65, 69);
            crz = LerInteiro6Digitos(69);
            denominacao = Ler(75, 77);
            dataHoraFinalEmissao = LerDataHora(77).Value;
        }

        public static DemaisDocumentosEmitidos InterpretaLinha(string linha)
        {
            return new DemaisDocumentosEmitidos(linha);
        }
    }
}

