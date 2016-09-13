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
            mfAdicional = Ler(23);
            modeloECF = Ler(25, 45);
        }

        public TipoRegistro TipoRegistro => tipoRegistro;

        protected string Ler(int posInicial, int posFinal)
        {
            return linhaCrua.Substring(posInicial - 1, posFinal - posInicial);
        }

        protected DateTime? LerDataHora(int posInicial)
        {
            return LerDataHora(posInicial, posInicial + 14);
        }

        protected DateTime? LerDataHora(int posInicial, int posFinal)
        {
            string texto = Ler(posInicial, posFinal);

            if (texto == null || texto.Trim().Length == 0)
                return null;
            
            return DateTime.ParseExact(texto, "yyyyMMddHHmmss", 
                CultureInfo.InvariantCulture);
        }

        protected DateTime? LerData(int posInicial)
        {
            return LerData(posInicial, posInicial + 8);
        }

        protected DateTime? LerData(int posInicial, int posFinal)
        {
            string texto = Ler(posInicial, posFinal);

            if (texto == null || texto.Trim().Length == 0)
                return null;
            
            return DateTime.ParseExact(texto, "yyyyMMdd", 
                CultureInfo.InvariantCulture);
        }

        protected char Ler(int pos)
        {
            return linhaCrua[pos - 1];
        }

        private string ObterLetra(int posicao)
        {
            return Ler(posicao).ToString().ToUpper();;
        }

        protected TipoPagamento LerTipoPagamento(int posicao)
        {
            switch (ObterLetra(posicao))
            {
                case "N":
                    return TipoPagamento.Vazio;
                case "S":
                    return TipoPagamento.Total;
                case "P":
                    return TipoPagamento.Parcial;

                default:
                    throw new NotImplementedException(ObterLetra(posicao));
            }
        }

        protected TipoValor LerTipoValor(int posicao)
        {
            switch (ObterLetra(posicao))
            {
                case "V":
                    return TipoValor.Monetario;
                case "P":
                    return TipoValor.Percentual;

                default:
                    throw new NotImplementedException(ObterLetra(posicao));
            }
        }

        protected TipoAplicacao LerTipoAplicacao(int posicao)
        {
            switch (ObterLetra(posicao))
            {
                case "D":
                    return TipoAplicacao.DescontoPrimeiro;
                case "A":
                    return TipoAplicacao.AcrescimoPrimeiro;
                case " ":
                    return TipoAplicacao.Nenhum;

                default:
                    throw new NotImplementedException(ObterLetra(posicao));
            }
        }

        protected int LerInteiro(int posInicial, int posFinal)
        {
            return int.Parse(Ler(posInicial, posFinal));
        }

        protected int LerInteiro6Digitos(int posInicial)
        {
            return int.Parse(Ler(posInicial, posInicial + 6));
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

                case "N":
                    return false;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}

