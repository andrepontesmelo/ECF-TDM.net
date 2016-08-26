﻿using System;

namespace InterpretadorTDM
{
    public class RelacaoDispositivosMFD : Identificacao
    {
        private string numeroSerieMFD;

        public string NumeroSerieMFD => numeroSerieMFD;

        public RelacaoDispositivosMFD(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E08_RelacaoDispositivosMFD;

            numeroSerieMFD = Ler(59, 79);
        }

        public static RelacaoDispositivosMFD InterpretaLinha(string linha)
        {
            return new RelacaoDispositivosMFD(linha);
        }
    }
}

