using System;
using InterpretadorTDM.Registro;

namespace InterpretadorTDM
{
    public abstract class TotalizadoresAbstratos : RegistroAbstratoIdentificado
    {
        private int crz;
        protected string totalizador;
        protected decimal valorAcumulado;

        public int CRZ => crz;
        public string Totalizador => totalizador;
        public decimal ValorAcumulado => valorAcumulado;

        public TotalizadoresAbstratos(string linha) : base(linha)
        {
            crz = LerInteiro6Digitos(47);
        }
    }
}

