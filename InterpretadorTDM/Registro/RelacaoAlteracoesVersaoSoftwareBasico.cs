using System;

namespace InterpretadorTDM
{
    public class RelacaoAlteracoesVersaoSoftwareBasico : Identificacao
    {
        private DateTime dataGravacao;
        private string versaoSB;

        public DateTime DataGravacao => dataGravacao;
        public string VersaoSB => versaoSB;

        public RelacaoAlteracoesVersaoSoftwareBasico(string linha) : base(linha)
        {
            tipoRegistro = TipoRegistro.E07_RelacaoAlteracoesVersaoSoftwareBasico;
            versaoSB = Ler(45, 55);
            dataGravacao = LerData(55, 63);
        }

        public static RelacaoAlteracoesVersaoSoftwareBasico InterpretaLinha(string linha)
        {
            return new RelacaoAlteracoesVersaoSoftwareBasico(linha);
        }
    }
}

