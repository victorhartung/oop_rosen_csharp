using JetBrains.Annotations;
using ProjetoTDD;

namespace ProjetoTDDTeste;

[TestClass]
[TestSubject(typeof(Calculadora))]
public class CalculadoraTest
{

    [TestMethod]
    public void DeveSomarNumeros()
    {
        var menorValorSeguro = Int32.MinValue / 2;
        var maiorValorSeguro = Int32.MaxValue / 2;
        var numero1 = new Random().Next(menorValorSeguro, maiorValorSeguro);
        var numero2 = new Random().Next(menorValorSeguro, maiorValorSeguro);
        
        var resultadoEsperado = numero1 + numero2;
        var resultado = Calculadora.Somar(numero1, numero2);
        
        Assert.AreEqual(resultadoEsperado, resultado);
    }
}