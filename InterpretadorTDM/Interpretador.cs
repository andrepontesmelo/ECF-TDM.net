using System;
using System.Collections.Generic;
using System.IO;

namespace InterpretadorTDM
{
	public class Interpretador
	{
        private IdentificacaoECF identificacaoECF;
        private IdentificacaoUsuario identificacaoUsuario;
        private List<RelacaoCodificacoesGT> relacoesCodificacoesGT = new List<RelacaoCodificacoesGT>();

        public IdentificacaoECF IdentificacaoECF => identificacaoECF;
        public IdentificacaoUsuario IdentificacaoUsuario => identificacaoUsuario;
        public List<RelacaoCodificacoesGT> RelacoesCodificacoesGT => relacoesCodificacoesGT;

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
                    identificacaoECF = IdentificacaoECF.InterpretaLinha(linha);
                    break;
                
                case TipoRegistro.E02_IdentificacaoUsuario:
                    identificacaoUsuario = IdentificacaoUsuario.InterpretaLinha(linha);
                    break;

                case TipoRegistro.E05_RelacaoCodificacoesGT:
                    relacoesCodificacoesGT.Add(RelacaoCodificacoesGT.InterpretaLinha(linha));
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private TipoRegistro ObterTipoRegistro(string linha)
        {
            return (TipoRegistro) int.Parse(linha.Substring(1, 2));
        }

		public static Interpretador InterpretaArquivo(string caminho)
		{
            return new Interpretador(caminho);
		}
	}
}

