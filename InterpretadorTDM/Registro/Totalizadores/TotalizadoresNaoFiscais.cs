using System;

namespace InterpretadorTDM.Registro.Totalizadores
{
    public class TotalizadoresNaoFiscais : TotalizadoresAbstratos
    {
        public TotalizadoresNaoFiscais(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E17_TotalizadoresNaoFiscais;

            totalizador = Ler(53, 53+15);
            valorAcumulado = LerDecimal(68, 68+13, 2);
        }

        public static TotalizadoresNaoFiscais InterpretaLinha(string linha)
        {
            return new TotalizadoresNaoFiscais(linha);
        }
    }
}

