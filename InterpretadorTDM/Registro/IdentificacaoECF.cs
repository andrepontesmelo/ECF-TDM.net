﻿using System;

namespace InterpretadorTDM
{
    public class IdentificacaoECF : RegistroAbstrato
    {
        private string numeroFabricacao;
        private char mfAdicional;
        private string tipoECF;
        private string marcaECF;
        private string modeloECF;
        private string versaoSB;
        private DateTime dataHoraGravacaoSB;
        private int numeroSequencialECF;
        private string cnpjUsuario;
        private string comandoGeracao;
        private int crzInicial;
        private int crzFinal;
        private DateTime dataInicial;
        private DateTime dataFinal;
        private string versaoBiblioteca;
        private string versaoAto;

        public string NumeroFabricacao => numeroFabricacao;
        public char MFAdicional => mfAdicional;
        public string TipoECF => tipoECF;
        public string MarcaECF => marcaECF;
        public string ModeloECF => modeloECF;
        public string VersaoSB => versaoSB;
        public DateTime DataHoraGravacaoSB => dataHoraGravacaoSB;
        public int NumeroSequencialECF => numeroSequencialECF;
        public string CNPJUsuario => cnpjUsuario;
        public string ComandoGeracao => comandoGeracao;
        public int CRZInicial => crzInicial;
        public int CRZFinal => crzFinal;
        public DateTime DataInicial => dataInicial;
        public DateTime DataFinal => dataFinal;
        public string VersaoBiblioteca => versaoBiblioteca;
        public string VersaoAto => versaoAto;

        private IdentificacaoECF(string linha)
        {
            linhaCrua = linha;
            tipoRegistro = TipoRegistro.E01_IdentificacaoECF;
            numeroFabricacao = Ler(4, 23);
            mfAdicional = Ler(24);
            tipoECF = Ler(25, 31);
            marcaECF = Ler(32, 52);
            modeloECF = Ler(52, 72);
            versaoSB = Ler(72, 82);
            dataHoraGravacaoSB = LerDataHora(82, 96);
            numeroSequencialECF = LerInteiro(96, 99);
            cnpjUsuario = Ler(99, 113);
            comandoGeracao = Ler(113, 116);
            crzInicial = LerInteiro(116, 122);
            crzFinal = LerInteiro(122, 128);
            dataInicial = LerData(128, 136);
            dataFinal = LerData(136, 144);
            versaoBiblioteca = Ler(144, 152);
            versaoAto = Ler(152, 167);
        }

        public static IdentificacaoECF InterpretaLinha(string linha)
        {
            return new IdentificacaoECF(linha);
        }
     }
}


