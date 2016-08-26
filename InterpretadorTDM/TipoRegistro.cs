using System;

namespace InterpretadorTDM
{
    public enum TipoRegistro : uint { 
        E01_IdentificacaoECF = 1,
        E02_IdentificacaoUsuario = 2,
        E03_IdentificacaoPrestadoresServico = 3,
        E04_RelacaoUsuariosAnteiores = 4,
        E05_RelacaoCodificacoesGT = 5,
        E06_RelacaoSimbolosMoeda = 6,
        E07_RelacaoAlteracoesVersaoSoftwareBasico = 7,
        E08_RelacaoDispositivosMFD = 8,
        E09_RelacaoIntervencoesTecnicas = 9,
        E10_RelacaoFitasDetalheEmitidas = 10,
        E11_PosicaoAtualTotalizadores = 11,
        E12_RelcaoReducoesZ = 12,
        E13_TotalizadoresParciais = 13,
        E14_CupomFiscal = 14,
        E15_DetalheCupomFiscal = 15,
        E16_DamisDocumentosEmitidos = 16,
        E17_TotalizadoresNaoFiscais = 17,
        E18_MeiosPagamentoETroco = 18,
        E19_DocumentoNaoFiscal = 19,
        E20_DetalheDocumentoNaoFiscal = 20,
        E21_DetalheMeioPagamento = 21
    }
}