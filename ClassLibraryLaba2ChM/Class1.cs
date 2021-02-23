using System;
namespace ClassLibraryLaba2ChM
{
    public class Class1
    {
        public static void ComplMatrix(ref double[,] MatrixBig, double[,] matrixA) //повна матриця
        {
            int n = matrixA.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrixBig[i, j] = matrixA[i, j];
                    MatrixBig[i, i + n] = 1;
                }
            }
        }
        public static bool IsSymetric(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] != matrix[j,i])
                    {
                        return false;
                    }
                }
            }
            return true; 
        }
        public static void MatrixPrint(double[,] matrix) 
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) // вивести вектор
                {
                    string result = $"{matrix[i, j]:f6}";
                    Console.Write(result+"\t");
                }
                Console.WriteLine();
            }
        }
        public static void ArrayPrint(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                string result = $"{array[i]:f6}";
                Console.WriteLine(result);
            }
        }
        public static void GaussaMethod(ref double[,] MatrixNew, double[,] MatrixBig)
        {
            int n = MatrixBig.GetLength(0);
            double a, d;
            //прямий хід
            for (int i = 0; i < n; i++)
            {
                a = MatrixBig[i, i];
                for (int j = 0; j < 2 * n; j++)
                {
                    MatrixBig[i, j] /= a;
                }
                for (int k = i + 1; k < n; k++)
                {
                    d = MatrixBig[k, i];
                    for (int j = 0; j < 2 * n; j++)
                        MatrixBig[k, j] = MatrixBig[k, j] - MatrixBig[i, j] * d;
                }
            }
            Console.WriteLine("                                          ~~~ Промiжна матриця ~~~");
            MatrixPrint(MatrixBig);
            //зворотний хід 
            for (int i = n - 1; i >= 0; i--)
            {
                a = MatrixBig[i, i];
                for (int j = 2 * n - 1; j >= 0; j--)
                {
                    MatrixBig[i, j] /= a;
                }
                for (int k = i - 1; k >= 0; k--)
                {
                    d = MatrixBig[k, i];
                    for (int j = 2 * n - 1; j >= 0; j--)
                        MatrixBig[k, j] = MatrixBig[k, j] - MatrixBig[i, j] * d;
                }
            }
            Console.WriteLine("                                          ~~~ Кiнцева матриця ~~~");
            MatrixPrint(MatrixBig);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrixNew[i, j] = MatrixBig[i, j + n];
        }
        public static void TheX(double[,] matrix, double[] array, ref double[] x) //знаходження невідомого вектора
        {
            int n = matrix.GetLength(0);
            Console.WriteLine("                                          ~~~ Вектор невідомих ~~~");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    x[i] += matrix[i, j] * array[j];
                }
                Console.Write("{0:f6}\t", x[i]);
            }
            Console.WriteLine();
           
        }
        public static void VectorNeviazki(double[] arrayB, double[,] matrix, double[] arrayX)
        {
            double[] newArray = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newArray[i] += matrix[i, j] * arrayX[j]; //множення матриці на вектор
                }
            }
            double[] result = new double[arrayB.Length];
            for (int i = 0; i < arrayB.Length; i++)
            {
                result[i] = arrayB[i] - newArray[i]; // знаходження вектора нев'язки
            }
            for (int i = 0; i < result.Length; i++)
            {
                string resultStr = $"{result[i]:f20}";
                Console.WriteLine(resultStr);
            }
        }
    }
}
