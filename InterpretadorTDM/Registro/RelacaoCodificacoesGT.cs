using System;

namespace InterpretadorTDM
{
    public class RelacaoCodificacoesGT : Identificacao
    {
        private DateTime dataHoraGravacao;
        private string codificador;

        public DateTime DataHoraGravacao => dataHoraGravacao;
        public string Codificador => codificador;

        public RelacaoCodificacoesGT(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E05_RelacaoCodificacoesGT;

            dataHoraGravacao = LerDataHora(59, 73).Value;
            codificador = Ler(73, 83);
        }

        public static RelacaoCodificacoesGT InterpretaLinha(string linha)
        {
            return new RelacaoCodificacoesGT(linha);
        }
    }
}
