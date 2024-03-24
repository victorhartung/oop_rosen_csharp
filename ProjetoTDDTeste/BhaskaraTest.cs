using ProjetoTDD;

namespace ProjetoTDDTeste;

[TestClass]
public class BhaskaraTest
{
    private double variacao = 0.1d;

    [TestMethod]
    public void DeveCalcularEquacaoCompleta()
    {
        var resultado = Bhaskara.CalcularRaizes(2, -6, -56);

        var esperado = new List<double>
        {
            -4,
            7
        };

        Assert.AreEqual(esperado[0], resultado[0], variacao);
        Assert.AreEqual(esperado[1], resultado[1], variacao);
    }

    [TestMethod]
    public void DeveCalcularEquacaoSemTermoIndependente()
    {
        var resultado = Bhaskara.CalcularRaizes(4, 8, 0);

        var esperado = new List<double>
        {
            -2,
            0
        };

        Assert.AreEqual(esperado[0], resultado[0], variacao);
        Assert.AreEqual(esperado[1], resultado[1], variacao);
    }

    [TestMethod]
    public void DeveCalcularEquacaoSemTermoB()
    {
        var resultado = Bhaskara.CalcularRaizes(1, 0, -4);

        var esperado = new List<double>
        {
            -2,
            2
        };

        Assert.AreEqual(esperado[0], resultado[0], variacao);
        Assert.AreEqual(esperado[1], resultado[1], variacao);
    }

    [TestMethod]
    public void DeveCalcularEquacaoSomenteComTermoQuadratico()
    {
        var resultado = Bhaskara.CalcularRaizes(16, 0, 0);

        var esperado = 0;

        Assert.AreEqual(esperado, resultado[0], variacao);
        Assert.AreEqual(esperado, resultado[1], variacao);
    }

    [TestMethod]
    public void DeveLancarExcecaoQuandoTermoQuadraticoIgualAZero()
    {
        var x = Assert.ThrowsException<ArithmeticException>(() => Bhaskara.CalcularRaizes(0, -7, 2));

        var mensagemEsperada = "Termo quadrático não pode ser zero";
        var mensagemRecebida = x.Message;

        Assert.AreEqual(mensagemEsperada, mensagemRecebida);
    }

    [TestMethod]
    public void DeveLancarExcecaoQuandoDiscriminanteForMenorQueZero()
    {
        var x = Assert.ThrowsException<ArithmeticException>(() => Bhaskara.CalcularRaizes(-3, 2, -5));

        var mensagemEsperada = "Não existe solução real";
        var mensagemRecebida = x.Message;

        Assert.AreEqual(mensagemEsperada, mensagemRecebida);
    }
}