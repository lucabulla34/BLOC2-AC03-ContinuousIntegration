using System;
using xUnitTestLibrary;

namespace ProgramaArreglar
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando programa...");

            int resultado = TestsLibrary.SumNumbers(5, 5, 5);
            string descripcion = TestsLibrary.DescriptionResult(resultado);

            Console.WriteLine($"Resultado: {resultado} - {descripcion}");
            Console.WriteLine("Fin del programa.");
        }
    }
}