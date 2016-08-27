using System;
using InterpretadorTDM.Registro;

namespace InterpretadorTDM
{
    public abstract class TotalizadoresAbstratos : RegistroAbstrato
    {
        private int crz, numeroUsuario;
        protected string totalizador;
        protected decimal valorAcumulado;

        public int NumeroUsuario => numeroUsuario;
        public int CRZ => crz;
        public string Totalizador => totalizador;
        public decimal ValorAcumulado => valorAcumulado;

        public TotalizadoresAbstratos(string linha) : base(linha)
        {
            numeroUsuario = LerInteiro(45, 47);
            crz = LerInteiro6Digitos(47);
        }
    }
}

