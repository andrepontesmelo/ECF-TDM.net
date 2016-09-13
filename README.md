
# EFC-TDM.net

Interpretador de [arquivo fiscal TDM](https://www.confaz.fazenda.gov.br/legislacao/atos/2007/ac008_07) em C#.

## Instalação

Execute o seguinte código no console NuGet (Visual Studio -> Tools -> NuGet Package Manager -> Package Manager Console)
```
PM> Install-Package InterpretadorTDM
```

## Exemplo de uso

```
using InterpretadorTDM;

public class Exemplo
{
  public static void Main()
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

		Console.WriteLine(detalhe.Descricao);
		Console.WriteLine(detalhe.Quantidade);
		Console.WriteLine(detalhe.ValorTotalLiquido.ToString("C"));
	}

	Console.ReadLine();
  }
}
```

## Requisitos
 * .NET framework 2.0 (versão mínima)
 * Nuget - gerenciamento de pacotes.
 * NUnit 2.6.4 - testes unitários
