using System;

namespace InterpretadorTDM.Registro
{
    public class TotalizadoresParciais : RegistroAbstrato
    {
        private int crz, numeroUsuario;
        private string totalizadorParcial;
        private decimal valorAcumulado;

        public int NumeroUsuario => numeroUsuario;
        public int CRZ => crz;
        public string TotalizadorParcial => totalizadorParcial;
        public decimal ValorAcumulado => valorAcumulado;

        public TotalizadoresParciais(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E13_TotalizadoresParciais;

            numeroUsuario = LerInteiro(45, 47);
            crz = LerInteiro6Digitos(47);
            totalizadorParcial = Ler(53, 60);
            valorAcumulado = LerDecimal(60, 73, 2);
        }

        public static TotalizadoresParciais InterpretaLinha(string linha)
        {
            return new TotalizadoresParciais(linha);
        }
    }
}

