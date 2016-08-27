using System;

namespace InterpretadorTDM.Registro.Relacao
{
    public class RelacaoReducoesZ : RegistroAbstrato
    {
        private int numeroUsuario;
        private int crz, coo, cro;
        private DateTime dataMovimento;
        private decimal vendaBrutaDiaria;
        private bool incidenciaDescontoISSQN;

        public int NumeroUsuario => numeroUsuario;
        public int CRZ => crz;
        public int COO => coo;
        public int CRO => cro;
        public DateTime DataMovimento => dataMovimento;
        public decimal VendaBrutaDiaria => vendaBrutaDiaria;
        public bool IncidenciaDescontoISSQN => incidenciaDescontoISSQN;

        public RelacaoReducoesZ(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E12_RelacaoReducoesZ;

            numeroUsuario = LerInteiro(45, 47);
            crz = LerInteiro6Digitos(47);
            coo = LerInteiro6Digitos(53);
            cro = LerInteiro6Digitos(59);
            dataMovimento = LerData(65).Value;
            vendaBrutaDiaria = LerDecimal(87, 101, 2);
            incidenciaDescontoISSQN = LerBooleano(101);
        }

        public static RelacaoReducoesZ InterpretaLinha(string linha)
        {
            return new RelacaoReducoesZ(linha);
        }
    }
}

