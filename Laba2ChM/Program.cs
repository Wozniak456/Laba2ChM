using System;
using ClassLibraryLaba2ChM;
namespace Laba2ChM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vozniak Sofiia is-01");
            double[,] matrixA = { { 8.30, 3.02, 4.10, 1.90 }, { 3.92, 8.45, 8.38, 2.46 }, 
                { 3.77, 7.61, 8.04, 2.28 },{ 2.21, 3.25, 1.69, 6.99 } };
            double[] arrayB = { -10.25, 12.21, 15.05, -8.35 };

            if (!Class1.IsSymetric(matrixA))
            {
                int n = matrixA.GetLength(0);
                double[] newArray = new double[arrayB.Length];
                double[,] newMatrix = new double[matrixA.GetLength(0), matrixA.GetLength(1)];
                double[,] bigMatrix = new double[n, 2 * n];
                Class1.ComplMatrix(ref bigMatrix, matrixA);
                Console.WriteLine("                                          ~~~ Початкова матриця ~~~");
                Class1.MatrixPrint(bigMatrix);
                Class1.GaussaMethod(ref newMatrix, bigMatrix);
                Class1.TheX(newMatrix, arrayB, ref newArray); //newArray - вектор невідомих
                Console.WriteLine("Вектор нев'язки ");
                Class1.VectorNeviazki(arrayB, matrixA, newArray);
            }
        }
    }
}
