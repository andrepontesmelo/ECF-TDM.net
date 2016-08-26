using System;

namespace InterpretadorTDM
{
    public class RelacaoSimbolosMoeda : RegistroCNPJ
    {
        private DateTime? dataHoraGravacao;
        private string simboloMoeda;

        public DateTime? DataHoraGravacao => dataHoraGravacao;
        public string SimboloMoeda => simboloMoeda;

        public RelacaoSimbolosMoeda(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E06_RelacaoSimbolosMoeda;
            dataHoraGravacao = LerDataHora(59, 73);
            simboloMoeda = Ler(73, 77);
        }

        public static RelacaoSimbolosMoeda InterpretaLinha(string linha)
        {
            return new RelacaoSimbolosMoeda(linha);
        }
    }
}

