
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
    Interpretador tdm = Interpretador.InterpretaArquivo("arquivo.tdm");

    Console.WriteLine(tdm.IdentificacaoECF.VersaoBiblioteca);
    Console.WriteLine(tdm.IdentificacaoUsuario.TotalizadorGeral);
  }
}
```

## Requisitos
 * .NET framework 4.5
 * Nuget - gerenciamento de pacotes.
 * NUnit 2.6.4 - testes unitários
