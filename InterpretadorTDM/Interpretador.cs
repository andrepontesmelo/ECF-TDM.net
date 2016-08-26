using System;
using System.Collections.Generic;
using System.IO;

namespace InterpretadorTDM
{
	public class Interpretador
	{
        private List<IdentificacaoECF> identificacoesECF = new List<IdentificacaoECF>();

        public List<IdentificacaoECF> IdentificacoesECF
        {
            get
            {
                return  identificacoesECF;
            }
        }

		private Interpretador(string caminho)
		{
            IEnumerable<string> linhas = File.ReadLines(caminho);   

            foreach (string linha in linhas)
                InterpretaLinha(linha);
		}

        private void InterpretaLinha(string linha)
        {
            switch (ObterTipoRegistro(linha))
            {
                case TipoRegistro.E01_IdentificacaoECF:
                    identificacoesECF.Add(IdentificacaoECF.InterpretaLinha(linha));
                    break;
            }
        }

        private TipoRegistro ObterTipoRegistro(string linha)
        {
            return TipoRegistro.E01_IdentificacaoECF;
        }

		public static Interpretador InterpretaArquivo(string caminho)
		{
            return new Interpretador(caminho);
		}
	}
}

