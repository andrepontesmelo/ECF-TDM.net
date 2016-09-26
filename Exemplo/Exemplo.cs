using InterpretadorTDM;
using InterpretadorTDM.Registro;
using System;

class Exemplo
{
    static void Main(string[] args)
    {
        foreach (CupomFiscal cupom in Interpretador.InterpretaArquivo(@"c:\arquivo.tdm").CuponsFiscais)
        {
            MostrarCupom(cupom);
            MostrarItens(cupom);
            MostrarPagamentos(cupom);
        }

        Console.ReadLine();
    }

    private static void MostrarPagamentos(CupomFiscal cupom)
    {
        Console.WriteLine(" ==== Pagamentos do Cupom Fiscal == ");
        foreach (DetalheMeioPagamento pagamento in cupom.DetalhesMeioPagamentos)
            Console.WriteLine(string.Format("R$ #{0} {1}", pagamento.ValorPago, pagamento.MeioPagamento));
    }

    private static void MostrarItens(CupomFiscal cupom)
    {
        Console.WriteLine(" ==== Itens do Cupom Fiscal == ");
        foreach (DetalheCupomFiscal detalhe in cupom.Detalhes)
        {
            Console.WriteLine(string.Format("Item #{0}", detalhe.NumeroItem));
            Console.WriteLine(string.Format("Código: {0}", detalhe.CodigoProdutoOuServico));
            Console.WriteLine(string.Format("Unidade: {0}", detalhe.Unidade));
            Console.WriteLine(string.Format("Descrição: {0}", detalhe.Descricao.Trim()));
            Console.WriteLine(string.Format("Qtd: {0}", detalhe.Quantidade));
            Console.WriteLine(string.Format("Valor Unitário: {0}", detalhe.ValorUnitario.ToString("C")));
            Console.WriteLine(string.Format("Valor Total: {0}", detalhe.ValorTotalLiquido.ToString("C")));
        }
        Console.WriteLine();
    }

    private static void MostrarCupom(CupomFiscal cupom)
    {
        Console.WriteLine(string.Format(" ==== Cupom Fiscal Código {0} ==== ", cupom.COO));
        Console.WriteLine(string.Format("Data Emissão: {0}", cupom.DataInicioEmissao));
        Console.WriteLine(string.Format("Cupom cancelado: {0}", cupom.IndicadorCancelamento));
        Console.WriteLine(cupom.ValorTotalLiquido.ToString("C"));
        Console.WriteLine();
    }
}

