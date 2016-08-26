using System;

namespace InterpretadorTDM
{
    public class IdentificacaoUsuario : Identificacao
    {
        private string inscricaoEstadual;
        private string nomeContribuinte;
        private string endereco;
        private DateTime dataHoraCadastro;
        private int contadorReinicioOperacao;
        private decimal totalizadorGeral;
        private int numeroUsuario;

        public string InscricaoEstadual => inscricaoEstadual;
        public string NomeContribuinte => nomeContribuinte;
        public string Endereco => endereco;
        public DateTime DataHoraCadastro => dataHoraCadastro;
        public int ContadorReinicioOperacao => contadorReinicioOperacao;
        public decimal TotalizadorGeral => totalizadorGeral;
        public int NumeroUsuario => numeroUsuario;

        private IdentificacaoUsuario(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E02_IdentificacaoUsuario;

            inscricaoEstadual = Ler(59, 72);
            nomeContribuinte = Ler(72, 112);
            endereco = Ler(112, 233);
            dataHoraCadastro = LerDataHora(233, 247);
            contadorReinicioOperacao = LerInteiro(247, 253);
            totalizadorGeral = LerDecimal(253, 271, 2);
            numeroUsuario = LerInteiro(271, 273);
        }

        public static IdentificacaoUsuario InterpretaLinha(string linha)
        {
            return new IdentificacaoUsuario(linha);
        }
    }
}

