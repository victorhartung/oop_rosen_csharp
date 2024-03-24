namespace ProjetoTDD
{
    public static class Bhaskara
    {
        public static List<double> CalcularRaizes(int a, int b, int c)
        {
            VerificarValorCoeficienteQuadratico(a);

            var x1 = (-b + Math.Sqrt(CalcularDiscriminante(a, b, c))) / (2 * a);
            var x2 = (-b - Math.Sqrt(CalcularDiscriminante(a, b, c))) / (2 * a);

            List<double> result = [x1, x2];

            return [.. result.OrderBy(x => x)];
        }

        private static double CalcularDiscriminante(int a, int b, int c)
        {
            var res = Math.Pow(b, 2) - 4 * a * c;

            if (res < 0)
            {
                throw new ArithmeticException("Não existe solução real");
            }

            return res;
        }

        private static void VerificarValorCoeficienteQuadratico(int a)
        {
            if (a == 0)
            {
                throw new ArithmeticException("Termo quadrático não pode ser zero");
            }
        }
    }
}