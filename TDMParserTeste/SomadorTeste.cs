using NUnit.Framework;
using System;
using TDMParser;

namespace TDMParserTeste
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			Assert.AreEqual (3, Somador.Soma (1, 2));
		}
	}
}

