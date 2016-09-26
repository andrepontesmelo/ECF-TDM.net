using InterpretadorTDM;
using InterpretadorTDM.Registro;
using System;

class Exemplo
{
    static void Main(string[] args)
    {
        CupomFiscal cupom = Interpretador.InterpretaArquivo(@"c:\arquivo.tdm").CuponsFiscais[0];

        Console.WriteLine(string.Format(" ==== Cupom Fiscal Código {0} ==== ", cupom.COO));
        Console.WriteLine(string.Format("Data Emissão: {0}", cupom.DataInicioEmissao));
        Console.WriteLine(string.Format("Cupom cancelado: {0}", cupom.IndicadorCancelamento));
        Console.WriteLine(cupom.ValorTotalLiquido.ToString("C"));

        Console.WriteLine(" ==== Itens do Cupom Fiscal == ");

        foreach (DetalheCupomFiscal detalhe in cupom.Detalhes)
        {
            Console.WriteLine(string.Format("Item #{0}", detalhe.NumeroItem));
            Console.WriteLine(detalhe.CodigoProdutoOuServico);
            Console.WriteLine(detalhe.Unidade);
            Console.WriteLine(detalhe.Descricao);
            Console.WriteLine(detalhe.Quantidade);
            Console.WriteLine(detalhe.ValorUnitario.ToString("C"));
            Console.WriteLine(detalhe.ValorTotalLiquido.ToString("C"));
        }

        Console.WriteLine(" ==== Pagamentos do Cupom Fiscal == ");
        foreach (DetalheMeioPagamento pagamento in cupom.DetalhesMeioPagamentos)
            Console.WriteLine(string.Format("R$ #{0} {1}", pagamento.ValorPago, pagamento.MeioPagamento));

        Console.ReadLine();
    }
}

