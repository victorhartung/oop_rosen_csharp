using Microsoft.VisualBasic.CompilerServices;
using ProjetoTDD;

bool queroFicar = true;

do
{
    Console.WriteLine("Escolha uma opção do menu:");
    Console.WriteLine("0) Sair\n1) Somar números\n2) Converter de metros para milímetros\n3) Baskara");

    try
    {
        var escolha = LerInteiro();

        switch (escolha)
        {
            case 0:
                queroFicar = false;
                break;

            case 1:
                Console.WriteLine("Digite o primeiro número: ");
                var numero1 = LerInteiro();

                Console.WriteLine("Digite o segundo número: ");
                var numero2 = LerInteiro();

                var soma = Calculadora.Somar(numero1, numero2);
                Console.WriteLine("A soma é: " + soma);
                break;

            case 2:
                Console.WriteLine("Insira o valor em metros: ");
                var metro = LerDecimal();

                var milimetro = ConversorMedidas.ConverterMetroParaMilimetro(metro);
                Console.WriteLine($"{metro:F2}m é igual a {milimetro:F2}mm");
                break;

            case 3:
                Console.WriteLine("\nax² + bx + c = 0");
                Console.WriteLine("Digite o termo que será elevado ao quadrado (a): ");
                var a = LerInteiro();

                Console.WriteLine("Digite o valor de b: ");
                var b = LerInteiro();

                Console.WriteLine("Agora, o termo independente (c): ");
                var c = LerInteiro();

                var raizes = Bhaskara.CalcularRaizes(a, b, c);

                Console.WriteLine($"As raízes são {raizes[0]:F2} e {raizes[1]:F2}");
                break;

            default:
                Console.WriteLine("Desculpa, não entendi o que foi digitado. Por favor, escolha um número de 0 a 3");
                break;
        }
    }
    catch (InvalidCastException)
    {
        Console.WriteLine("Não foi possível ler número");
    }
    catch (ArithmeticException arithmeticException)
    {
        Console.WriteLine(arithmeticException.Message);
    }

    Console.WriteLine();
} while (queroFicar);

static int LerInteiro()
{
    return IntegerType.FromString(Console.ReadLine());
}

static double LerDecimal()
{
    return DoubleType.FromString(Console.ReadLine());
}