using System;

namespace InterpretadorTDM.Registro.CNPJ
{
    public class RelacaoFitasDetalheEmitidas : RegistroCNPJ
    {
        private int contadorFitaDetalhe;
        private DateTime? dataEmissao;
        private int cooInicial;
        private int cooFinal;

        public int ContadorFitaDetalhe => contadorFitaDetalhe;
        public DateTime? DataEmissao => dataEmissao;
        public int COOInicial => cooInicial;
        public int COOFinal => cooFinal;

        public RelacaoFitasDetalheEmitidas(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E10_RelacaoFitasDetalheEmitidas;

            contadorFitaDetalhe = LerInteiro(45, 51);
            dataEmissao = LerData(51, 59);
            cooInicial = LerInteiro(59, 65);
            cooFinal = LerInteiro(65, 71);
            cnpjUsuario = Ler(71, 85);
        }

        public static RelacaoFitasDetalheEmitidas InterpretaLinha(string linha)
        {
            return new RelacaoFitasDetalheEmitidas(linha);
        }
    }
}

