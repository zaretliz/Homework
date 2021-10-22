using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5
{
    class Program
    {
       /// <summary>
       /// Вывод на экран умножение на число
       /// </summary>
       /// <param name="matrix"></param>
       /// <param name="number"></param>
       static void PrintMul(int [,] matrix, int number)
        {
            Console.WriteLine($"Умножение матрицы на число {number}  ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write((i == (int)(matrix.GetLength(0) / 2)) ? $" {number} * | " : "     | ");
                for (int k = 0; k < matrix.GetLength(1); k++) { Console.Write($"{matrix[i, k]} "); }
                Console.WriteLine("|");
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Вывод на экран матрицы результата
        /// </summary>
        /// <param name="matrix"></param>
        static void PrintMul(int[,] matrix)
        {
            Console.WriteLine("Результат умножения: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("|");
                for (int m = 0; m < matrix.GetLength(1); m++) { Console.Write($"{matrix[i, m]} "); }
                Console.WriteLine("|");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="number"></param>
        /// <param name="matrix"></param>
        static int[,] MulMatrixNumber(int number, int[,] matrix)
        {
            int[,] newmatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newmatrix[i, j] = matrix[i, j] * number;
                }
            }
            return newmatrix;
        }

        /// <summary>
        /// Вывод на экран матрицы
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="number"></param>
        static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("|");
                for (int k = 0; k < matrix.GetLength(1); k++) { Console.Write($" {matrix[i, k]} "); }
                Console.WriteLine("|");
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Вывод на экран матрицы результата
        /// </summary>
        /// <param name="matrix"></param>
        static void PrintSum(int[,] matrix)
        {
            Console.WriteLine("Результат сложения: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("|");
                for (int m = 0; m < matrix.GetLength(1); m++) { Console.Write($" {matrix[i, m]} "); }
                Console.WriteLine("|");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Сумма матриц
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        static int [,] SumMatrix(int[,] matrixA, int[,] matrixB)
        {
            while (matrixA.GetLength(1) != matrixB.GetLength(1) || matrixA.GetLength(0) != matrixB.GetLength(0))
            {
                Console.Write("Сложение и вычитание матриц с разным размером невозможно!. Попробуйте ещё раз\n ");
                matrixB = SecondMatrix();
                Print(matrixB);
            }
            int[,] MatrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    MatrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }
            return MatrixC;
        }

        /// <summary>
        /// Умножение двух матриц
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        static int [,] MulMatrix(int[,] matrixA, int[,] matrixB)
        {
            //Проверка можно ли умножать матрицы
            while (matrixA.GetLength(1) != matrixB.GetLength(0) || matrixA.GetLength(0) > matrixB.GetLength(0))
            {
                Console.Write("Умножение матриц невозможно! Количество столбцов первой матрицы не равно количеству строк второй. Попробуйте ещё раз\n ");
                matrixB = SecondMatrix();
                Print(matrixB);
            }

            while (matrixA.GetLength(0) > matrixB.GetLength(0) && matrixA.GetLength(1) > matrixB.GetLength(1))
            {
                Console.Write("Умножение матриц невозможно");
                Console.ReadKey();
            }
            int[,] MatrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    for (int k = 0; k < matrixA.GetLength(1); k++)
                    {
                        MatrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
 
                }
            }

            return MatrixC;
        }
     
        /// <summary>
        /// Получение первой матрицы
        /// </summary>
        static int[,] FirstMatrix()
        {
            Random rand = new Random();
            Console.WriteLine("Введите количество строк для первой матрицы: ");
            int row1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество столбцов для первой матрицы: ");
            int col1 = int.Parse(Console.ReadLine());

            while (row1 <= 0 || col1 <= 0)
            {
                Console.Write("Неверная размерность матрицы. Попробуйте ещё раз\n ");
                Console.WriteLine("Введите количество строк для первой матрицы: ");
                row1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите количество столбцов для первой матрицы: ");
                col1 = int.Parse(Console.ReadLine());
            }

            int[,] MatrixA = new int[row1, col1];
            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col1; j++)
                {
                    MatrixA[i, j] = rand.Next(10);
                }

            }
            return MatrixA;
        }
        /// <summary>
        /// Получение второй матрицы
        /// </summary>
        static int[,] SecondMatrix()
        {
            Random rand = new Random();
            Console.WriteLine("Введите количество строк для второй матрицы: ");
            int row2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество столбцов для второй матрицы: ");
            int col2 = int.Parse(Console.ReadLine());

            while (row2 <= 0 || col2 <= 0)
            {
                Console.Write("Неверная размерность матрицы. Попробуйте ещё раз\n ");
                Console.WriteLine("Введите количество строк для второй матрицы: ");
                row2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите количество столбцов для второй матрицы: ");
                col2 = int.Parse(Console.ReadLine());
            }

            int[,] MatrixB = new int[row2, col2];
            for (int i = 0; i < row2; i++)
            {
                for (int j = 0; j < col2; j++)
                {
                    MatrixB[i, j] = rand.Next(10);
                }

            }
            return MatrixB;
        }




        /// <summary>
        /// Вызов всех функций
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            int[,] matrix = FirstMatrix();

            Console.WriteLine("Введите число для умножения: ");
            int number = int.Parse(Console.ReadLine());

            PrintMul(matrix, number);

            int[,] newmatrix = MulMatrixNumber(number, matrix);
            PrintMul(newmatrix);
            Console.Clear();

            int[,] MatrixA = FirstMatrix();
            Print(MatrixA);
            int [,] MatrixB = SecondMatrix();
            Print(MatrixB);
         
            
            int [,] matrixC = SumMatrix(MatrixA, MatrixB);
            PrintSum(matrixC);
            Console.Clear();

            int[,] MatrixC = FirstMatrix();
            Print(MatrixC);
            int[,] MatrixD = SecondMatrix();
            Print(MatrixD);
   

            int [,] MatrixE = MulMatrix(MatrixC, MatrixD);
            PrintMul(MatrixE);
            




        }
    }
}
