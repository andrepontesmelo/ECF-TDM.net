using System;

namespace InterpretadorTDM.Registro
{
    public class RegistroAbstratoIdentificado : RegistroAbstrato
    {
        private int numeroUsuario;

        public int NumeroUsuario => numeroUsuario;

        public RegistroAbstratoIdentificado(string linha) : base(linha)
        {
            numeroUsuario = LerInteiro(45, 47);
        }
    }
}

