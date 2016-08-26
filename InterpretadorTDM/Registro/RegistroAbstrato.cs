using System;
using System.Globalization;

namespace InterpretadorTDM.Registro
{
    public abstract class RegistroAbstrato
    {
        protected string linhaCrua;
        protected TipoRegistro tipoRegistro;
        private string numeroFabricacao;
        private char mfAdicional;
        protected string modeloECF;

        public string NumeroFabricacao => numeroFabricacao;
        public char MFAdicional => mfAdicional;
        public string ModeloECF => modeloECF;


        protected RegistroAbstrato(string linha)
        {
            this.linhaCrua = linha;
            numeroFabricacao = Ler(4, 23);
            mfAdicional = Ler(24);
            modeloECF = Ler(25, 45);
        }

        public TipoRegistro TipoRegistro => tipoRegistro;

        protected string Ler(int posInicial, int posFinal)
        {
            return linhaCrua.Substring(posInicial - 1, posFinal - posInicial);
        }

        protected DateTime? LerDataHora(int posInicial, int posFinal)
        {
            string texto = Ler(posInicial, posFinal);

            if (String.IsNullOrWhiteSpace(texto))
                return null;
            
            return DateTime.ParseExact(texto, "yyyyMMddHHmmss", 
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

        protected decimal LerDecimal(int posInicial, int posFinal, int casasDecimais)
        {
            string decimalComSeparacao = Ler(posInicial, posFinal - casasDecimais) + "," + 
                Ler(posFinal - casasDecimais, posFinal);

            return decimal.Parse(decimalComSeparacao);
        }

        protected bool LerBooleano(int posicao)
        {
            switch (linhaCrua[posicao - 1].ToString().ToUpper())
            {
                case "S":
                    return true;
                    break;

                case "N":
                    return false;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}

