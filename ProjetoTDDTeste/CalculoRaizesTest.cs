using ProjetoTDD;

namespace ProjetoTDDTeste
{
    [TestClass]
    public class CalculoRaizesTest
    {
        [TestMethod]
        public void Caso1()
        {
            var res = CalculoRaizes.calcularRaizes(2, -6, -56);

            var expected = new List<double>
            {
                -4,
                7
            };

            expected.OrderBy(expected => expected).ToList();

            Assert.AreEqual(expected[0], res[0], 1d);
            Assert.AreEqual(expected[1], res[1], 1d);
        }
    }
}