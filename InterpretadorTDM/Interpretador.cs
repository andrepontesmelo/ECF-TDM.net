using System;
using System.IO;
using System.Collections.Generic;
using InterpretadorTDM.Registro;
using InterpretadorTDM.Registro.CNPJ;
using InterpretadorTDM.Registro.Relacao;
using InterpretadorTDM.Registro.Totalizadores;

namespace InterpretadorTDM
{
	public class Interpretador
	{
        private IdentificacaoECF identificacaoECF;
        private IdentificacaoUsuario identificacaoUsuario;
        private List<RelacaoCodificacoesGT> relacoesCodificacoesGT = new List<RelacaoCodificacoesGT>();
        private List<RelacaoSimbolosMoeda> relacoesSimbolosMoeda = new List<RelacaoSimbolosMoeda>();
        private List<RelacaoAlteracoesVersaoSoftwareBasico> relacoesAlteracoesVersaoSoftwareBasico = new List<RelacaoAlteracoesVersaoSoftwareBasico>();
        private List<RelacaoDispositivosMFD> relacoesDispositivosMFD = new List<RelacaoDispositivosMFD>();
        private List<RelacaoIntervencoesTecnicas> relacoesIntervencoesTecnicas = new List<RelacaoIntervencoesTecnicas>();
        private List<RelacaoFitasDetalheEmitidas> relacoesFitasDetalheEmitidas = new List<RelacaoFitasDetalheEmitidas>();
        private List<PosicaoAtualTotalizadores> posicoesAtuaisTotalizadores = new List<PosicaoAtualTotalizadores>();
        private List<RelacaoReducoesZ> relacoesReducoesZ = new List<RelacaoReducoesZ>();
        private List<TotalizadoresParciais> totalizadoresParciais = new List<TotalizadoresParciais>();
        private List<DemaisDocumentosEmitidos> demaisDocumentosEmitidos = new List<DemaisDocumentosEmitidos>();
        private List<CupomFiscal> cuponsFiscais = new List<CupomFiscal>();
        private List<DetalheCupomFiscal> detalheCuponsFiscais = new List<DetalheCupomFiscal>();
        private List<TotalizadoresNaoFiscais> totalizadoresNaoFiscais = new List<TotalizadoresNaoFiscais>();
        private List<MeioPagamento> meiosPagamento = new List<MeioPagamento>();
        private List<DetalheMeioPagamento> detalhesMeioPagamento = new List<DetalheMeioPagamento>();

        public IdentificacaoECF IdentificacaoECF => identificacaoECF;
        public IdentificacaoUsuario IdentificacaoUsuario => identificacaoUsuario;
        public List<RelacaoSimbolosMoeda> RelacoesSimbolosMoeda => relacoesSimbolosMoeda;
        public List<RelacaoAlteracoesVersaoSoftwareBasico> RelacoesAlteracoesVersaoSoftwareBasico => relacoesAlteracoesVersaoSoftwareBasico;
        public List<RelacaoDispositivosMFD> RelacoesDispositivosMFD => relacoesDispositivosMFD;
        public List<RelacaoIntervencoesTecnicas> RelacoesIntervencoesTecnicas => relacoesIntervencoesTecnicas;
        public List<RelacaoFitasDetalheEmitidas> RelacoesFitasDetalheEmitidas => relacoesFitasDetalheEmitidas;
        public List<PosicaoAtualTotalizadores> PosicoesAtuaisTotalizadores => posicoesAtuaisTotalizadores;
        public List<RelacaoReducoesZ> RelacoesReducoesZ => relacoesReducoesZ;
        public List<TotalizadoresParciais> TotalizadoresParciais => totalizadoresParciais;
        public List<DemaisDocumentosEmitidos> DemaisDocumentosEmitidos => demaisDocumentosEmitidos;
        public List<CupomFiscal> CuponsFiscais => cuponsFiscais;
        public List<DetalheCupomFiscal> DetalheCuponsFiscais => detalheCuponsFiscais;
        public List<TotalizadoresNaoFiscais> TotalizadoresNaoFiscais => totalizadoresNaoFiscais;
        public List<MeioPagamento> MeiosPagamento => meiosPagamento;
        public List<DetalheMeioPagamento> DetalhesMeioPagamento => detalhesMeioPagamento;

		private Interpretador(string caminho)
        {
            InterpretaEntidades(caminho);
            InterpretaRelacionamentos();
        }

        private void InterpretaRelacionamentos()
        {
            Dictionary<int, CupomFiscal> hashCupons = new Dictionary<int, CupomFiscal>();

            foreach (CupomFiscal cupom in cuponsFiscais)
                hashCupons[cupom.COO] = cupom;

            InterpretaDetalhes(hashCupons);
            InterpretaPagamentos(hashCupons);
        }

        private void InterpretaPagamentos(Dictionary<int, CupomFiscal> hashCupons)
        {
            foreach (DetalheMeioPagamento pagamento in DetalhesMeioPagamento)
            {
                CupomFiscal cupom;

                if (hashCupons.TryGetValue(pagamento.COO, out cupom))
                    cupom.DetalhesMeioPagamentos.Add(pagamento);
            }
        }

        private void InterpretaDetalhes(Dictionary<int, CupomFiscal> hashCupons)
        {
            foreach (DetalheCupomFiscal detalhe in detalheCuponsFiscais)
            {
                CupomFiscal cupom;

                if (hashCupons.TryGetValue(detalhe.COO, out cupom))
                    cupom.Detalhes.Add(detalhe);
            }
        }

        private void InterpretaEntidades(string caminho)
        {
            string[] linhas = File.ReadAllLines(caminho);

            for (int x = 0; x < linhas.Length; x++)
            {
                bool ultimaLinha = (x == linhas.Length - 1);

                if (!ultimaLinha)
                    InterpretaLinha(linhas[x]);
            }
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

                case TipoRegistro.E06_RelacaoSimbolosMoeda:
                    relacoesSimbolosMoeda.Add(RelacaoSimbolosMoeda.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E07_RelacaoAlteracoesVersaoSoftwareBasico:
                    relacoesAlteracoesVersaoSoftwareBasico.Add(RelacaoAlteracoesVersaoSoftwareBasico.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E08_RelacaoDispositivosMFD:
                    relacoesDispositivosMFD.Add(RelacaoDispositivosMFD.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E09_RelacaoIntervencoesTecnicas:
                    relacoesIntervencoesTecnicas.Add(RelacaoIntervencoesTecnicas.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E10_RelacaoFitasDetalheEmitidas:
                    relacoesFitasDetalheEmitidas.Add(RelacaoFitasDetalheEmitidas.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E11_PosicaoAtualTotalizadores:
                    posicoesAtuaisTotalizadores.Add(PosicaoAtualTotalizadores.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E12_RelacaoReducoesZ:
                    relacoesReducoesZ.Add(RelacaoReducoesZ.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E13_TotalizadoresParciais:
                    totalizadoresParciais.Add(Registro.Totalizadores.TotalizadoresParciais.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E14_CupomFiscal:
                    cuponsFiscais.Add(CupomFiscal.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E15_DetalheCupomFiscal:
                    detalheCuponsFiscais.Add(DetalheCupomFiscal.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E16_DemaisDocumentosEmitidos:
                    demaisDocumentosEmitidos.Add(Registro.DemaisDocumentosEmitidos.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E17_TotalizadoresNaoFiscais:
                    totalizadoresNaoFiscais.Add(Registro.Totalizadores.TotalizadoresNaoFiscais.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E18_MeioPagamento:
                    meiosPagamento.Add(MeioPagamento.InterpretaLinha(linha));
                    break;

                case TipoRegistro.E21_DetalheMeioPagamento:
                    detalhesMeioPagamento.Add(DetalheMeioPagamento.InterpretaLinha(linha));
                    break;

                default:
                    Console.WriteLine("Não implementado: " +
                        ObterTipoRegistro(linha).ToString());
                    break;
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