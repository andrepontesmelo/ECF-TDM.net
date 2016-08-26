using System;

namespace InterpretadorTDM
{
    public class Identificacao : RegistroAbstrato
    {
        private string numeroFabricacao;
        private char mfAdicional;
        protected string modeloECF;
        protected string cnpjUsuario;

        public string NumeroFabricacao => numeroFabricacao;
        public char MFAdicional => mfAdicional;
        public string ModeloECF => modeloECF;
        public string CNPJUsuario => cnpjUsuario;

        protected Identificacao(string linha) : base(linha)
        {
            numeroFabricacao = Ler(4, 23);
            mfAdicional = Ler(24);
        }
    }
}

