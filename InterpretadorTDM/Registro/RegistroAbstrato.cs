using System;
using System.Globalization;

namespace InterpretadorTDM
{
    public abstract class RegistroAbstrato
    {
        protected string linhaCrua;
        protected TipoRegistro tipoRegistro;

        protected RegistroAbstrato(string linha)
        {
            this.linhaCrua = linha;
        }

        public TipoRegistro TipoRegistro => tipoRegistro;

        protected string Ler(int posInicial, int posFinal)
        {
            return linhaCrua.Substring(posInicial - 1, posFinal - posInicial);
        }

        protected DateTime LerDataHora(int posInicial, int posFinal)
        {
            return DateTime.ParseExact(Ler(posInicial, posFinal), "yyyyMMddHHmmss", 
                CultureInfo.InvariantCulture);
        }

        protected DateTime LerData(int posInicial, int posFinal)
        {
            return DateTime.ParseExact(Ler(posInicial, posFinal), "yyyyMMdd", 
                CultureInfo.InvariantCulture);
        }

        protected char Ler(int pos)
        {
            return linhaCrua[pos - 2];
        }

        protected int LerInteiro(int posInicial, int posFinal)
        {
            return int.Parse(Ler(posInicial, posFinal));
        }
    }
}

