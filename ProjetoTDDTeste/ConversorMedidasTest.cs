using JetBrains.Annotations;
using ProjetoTDD;

namespace ProjetoTDDTeste;

[TestClass]
[TestSubject(typeof(ConversorMedidas))]
public class ConversorMedidasTest
{
    [TestMethod]
    public void DeveConverterDeMetroParaMilimetro()
    {
        var metro = new Random().NextDouble();

        var resultadoEsperado = metro * 1000;
        var resultado = ConversorMedidas.ConverterMetroParaMilimetro(metro);

        Assert.AreEqual(resultadoEsperado, resultado);
    }
}