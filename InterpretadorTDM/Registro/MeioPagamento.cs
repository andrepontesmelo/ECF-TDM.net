using System;

namespace InterpretadorTDM.Registro
{
    public class MeioPagamento : RegistroAbstratoIdentificado
    {
        private int crz;
        private string descricao;
        private decimal valorAcumulado;

        public int CRZ => crz;
        public string Descricao => descricao;
        public decimal ValorAcumulado => valorAcumulado;

        public MeioPagamento(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E18_MeioPagamento;
            crz = LerInteiro6Digitos(47);
            descricao = Ler(53, 53+15);
            valorAcumulado = LerDecimal(68, 68+13, 2);
        }

        public static MeioPagamento InterpretaLinha(string linha)
        {
            return new MeioPagamento(linha);
        }
    }
}

