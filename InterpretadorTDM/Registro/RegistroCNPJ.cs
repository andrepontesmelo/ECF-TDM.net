using System;

namespace InterpretadorTDM
{
    public class RegistroCNPJ : RegistroAbstrato
    {
        protected string cnpjUsuario;
        public string CNPJUsuario => cnpjUsuario;

        protected RegistroCNPJ(string linha) : base(linha)
        {
            cnpjUsuario = Ler(45, 59);
        }
    }
}

