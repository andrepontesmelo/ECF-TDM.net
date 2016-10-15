using System;
using System.Collections.Generic;

namespace InterpretadorTDM.Registro.Relacao
{
    public class RelacaoReducoesZ : RegistroAbstratoIdentificado
    {
        private int crz, coo, cro;
        private DateTime dataMovimento;
        private decimal vendaBrutaDiaria;
        private bool incidenciaDescontoISSQN;
        private List<CupomFiscal> cupons;

        public int CRZ => crz;
        public int COO => coo;
        public int CRO => cro;
        public DateTime DataMovimento => dataMovimento;
        public decimal VendaBrutaDiaria => vendaBrutaDiaria;
        public bool IncidenciaDescontoISSQN => incidenciaDescontoISSQN;

        public List<CupomFiscal> Cupons => cupons;

        public RelacaoReducoesZ(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E12_RelacaoReducoesZ;

            crz = LerInteiro6Digitos(47);
            coo = LerInteiro6Digitos(53);
            cro = LerInteiro6Digitos(59);
            dataMovimento = LerData(65).Value;
            vendaBrutaDiaria = LerDecimal(87, 101, 2);
            incidenciaDescontoISSQN = LerBooleano(101);

            cupons = new List<Registro.CupomFiscal>();
        }

        public static RelacaoReducoesZ InterpretaLinha(string linha)
        {
            return new RelacaoReducoesZ(linha);
        }
    }
}

