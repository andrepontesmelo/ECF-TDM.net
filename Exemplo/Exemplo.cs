using InterpretadorTDM;
using InterpretadorTDM.Registro;
using System;

class Exemplo
{
    static void Main(string[] args)
    {
        Interpretador x = Interpretador.InterpretaArquivo(@"c:\arquivo.tdm");

        DetalheCupomFiscal primeiroItem = x.DetalheCuponsFiscais[0];

        Console.WriteLine(primeiroItem.Descricao);
        Console.WriteLine(primeiroItem.Quantidade);
        Console.WriteLine(primeiroItem.ValorTotalLiquido.ToString("C"));
        Console.ReadLine();
    }
}

