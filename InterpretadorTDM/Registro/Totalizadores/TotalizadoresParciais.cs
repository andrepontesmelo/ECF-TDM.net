using System;

namespace InterpretadorTDM.Registro.Totalizadores
{
    public class TotalizadoresParciais : TotalizadoresAbstratos
    {
        public TotalizadoresParciais(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E13_TotalizadoresParciais;

            totalizador = Ler(53, 60);
            valorAcumulado = LerDecimal(60, 73, 2);
        }

        public static TotalizadoresParciais InterpretaLinha(string linha)
        {
            return new TotalizadoresParciais(linha);
        }
    }
}

