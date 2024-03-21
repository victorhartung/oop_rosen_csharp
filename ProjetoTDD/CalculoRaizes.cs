using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTDD
{
    public class CalculoRaizes
    {
        public static List<double> calcularRaizes(int a, int b, int c)
        {
            VerificarValorCoeficienteQuadratico(a);

            var x1 = (-b + Math.Sqrt(calcularDelta(a, b, c))) / (2 * a);
            var x2 = (-b - Math.Sqrt(calcularDelta(a, b, c))) / (2 * a);

            List<double> result = [x1, x2];

            return [.. result.OrderBy(x => x)];
        }

        public static double calcularDelta(int a, int b, int c) {
            var res = Math.Pow(b, 2) - 4 * a * c;

            if( res < 0)
            {
                throw new ArgumentException("Não existe solução");
            }
            return res;
        }

        public static void VerificarValorCoeficienteQuadratico(int a)
        {
            if ( a < 0 ) {
                throw new ArgumentException("Termo quadrático não pode ser zero");
                   
            }
        }
    }
}
