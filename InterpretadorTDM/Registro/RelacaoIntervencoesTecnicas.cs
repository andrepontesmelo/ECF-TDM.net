using System;

namespace InterpretadorTDM.Registro
{
    public class RelacaoIntervencoesTecnicas : RegistroAbstrato
    {
        private DateTime dataHoraGravacao;
        private int contadorReinicioOperacao;
        private bool indicadorPerdaDadosMT;

        public DateTime DataHoraGravacao => dataHoraGravacao;
        public int ContadorReinicioOperacao => contadorReinicioOperacao;
        public bool IndicadorPerdaDadosMT => indicadorPerdaDadosMT;

        public RelacaoIntervencoesTecnicas(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E09_RelacaoIntervencoesTecnicas;
            dataHoraGravacao = LerDataHora(51, 65).Value;
            indicadorPerdaDadosMT = LerBooleano(65);
            contadorReinicioOperacao = LerInteiro(45, 51);
        }

        public static RelacaoIntervencoesTecnicas InterpretaLinha(string linha)
        {
            return new RelacaoIntervencoesTecnicas(linha);
        }
    }
}

