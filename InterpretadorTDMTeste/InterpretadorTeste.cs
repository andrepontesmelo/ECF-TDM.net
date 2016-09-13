using InterpretadorTDM;
using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace InterpretadorTDMTeste
{
    [TestFixture()]
    public class InterpretadorTeste
    {
        private static string ARQUIVO_ENTRADA = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)).FullName).FullName + @"\arquivo.tdm";

        [Test()]
        public void DeveDetalharCupons()
        {
            Interpretador interpretador = Interpretador.InterpretaArquivo(ARQUIVO_ENTRADA);

            Assert.AreEqual(1, interpretador.CuponsFiscais[0].Detalhes.Count);
        }
    }
}
