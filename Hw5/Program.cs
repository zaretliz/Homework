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
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            Console.WriteLine($"Умножение матрицы на число {number}  ");
            for (int i = 0; i < row; i++)
            {
                Console.Write((i == (int)(row / 2)) ? $" {number} * | " : "     | ");
                for (int k = 0; k < col; k++) { Console.Write($"{matrix[i, k]} "); }
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
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            Console.WriteLine("Результат умножения: ");
            for (int i = 0; i < row; i++)
            {
                Console.Write("|");
                for (int m = 0; m < col; m++) { Console.Write($"{matrix[i, m]} "); }
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
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int[,] newmatrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
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
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                Console.Write("|");
                for (int k = 0; k < col; k++) { Console.Write($" {matrix[i, k]} "); }
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
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            Console.WriteLine("Результат сложения: ");
            for (int i = 0; i < row; i++)
            {
                Console.Write("|");
                for (int m = 0; m < col; m++) { Console.Write($" {matrix[i, m]} "); }
                Console.WriteLine("|");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        
        static bool CheckSum(int row1, int col1, int row2, int col2)
        {

            if (col1 != col2 || row1 != row2)
            {
                Console.Write("Сложение и вычитание матриц с разным размером невозможно!. Попробуйте ещё раз\n ");

                return false;
                 
            }
            return true;
        }
        /// <summary>
        /// Сумма матриц
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        static int [,] SumMatrix(int[,] matrixA, int[,] matrixB)
        {
            int row1 = matrixA.GetLength(0);
            int col1 = matrixA.GetLength(1);
            int row2 = matrixB.GetLength(0);
            int col2 = matrixB.GetLength(1);
            
            int[,] MatrixC = new int[row1, col2];
            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col2; j++)
                {
                    MatrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }
            return MatrixC;
        }

        static bool CheckMul(int row1, int col1, int row2, int col2)
        {
            //Проверка можно ли умножать матрицы
            if (col1 != row2 || row1 > row2)
            {
                Console.Write("Умножение матриц невозможно! Количество столбцов первой матрицы не равно количеству строк второй. Попробуйте ещё раз\n ");
                return false;
            }

            if (row1 > row2 && col1 > col2)
            {
                Console.Write("Умножение матриц невозможно");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Умножение двух матриц
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        static int [,] MulMatrix(int[,] matrixA, int[,] matrixB)
        {
            int row1 = matrixA.GetLength(0);
            int col1 = matrixA.GetLength(1);
            int row2 = matrixB.GetLength(0);
            int col2 = matrixB.GetLength(1);
            
            int[,] MatrixC = new int[row1, col2];
            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col2; j++)
                {
                    for (int k = 0; k < col1; k++)
                    {
                        MatrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
 
                }
            }

            return MatrixC;
        }

        /// <summary>
        /// Ввод строк
        /// </summary>
        /// <returns></returns>
        static int DataRow()
        {
            int row = 0;
            do
            {
                Console.WriteLine("Введите количество строк для матрицы: ");
                string text = Console.ReadLine();
                bool res = int.TryParse(text, out row);
                if (res)
                {
                    row = int.Parse(text);
                    return row;
                }
                else { Console.WriteLine("Не удалось распознать число, попробуйте еще раз."); }
 
            }
            while (true);
        }
        /// <summary>
        /// Ввод столбцов
        /// </summary>
        /// <returns></returns>
        static int DataCol()
        {
            int col = 0;
            do
            {
                Console.WriteLine("Введите количество столбцов для матрицы: ");
                string text = Console.ReadLine();
                bool res = int.TryParse(text, out col);
                if (res)
                {
                    col = int.Parse(text);
                    return col;
                }
                else { Console.WriteLine("Не удалось распознать число, попробуйте еще раз."); }

            }
            while (true);
        }
        /// <summary>
        /// Проверка ввода числа
        /// </summary>
        /// <returns></returns>
        static int DataNumber()
        {
            int num = 0;
            do
            {
                Console.WriteLine("Введите число для умножения: ");
                string text = Console.ReadLine();
                bool res = int.TryParse(text, out num);
                if (res)
                {
                    num = int.Parse(text);
                    return num;
                }
                else { Console.WriteLine("Не удалось распознать число, попробуйте еще раз."); }

            }
            while (true);
        }

        /// <summary>
        /// Проверка правильности ввода данных
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        static bool CheckRowCol( int row, int col)
        {
            if (row <= 0 || col <= 0)
            {
                Console.Write("Неверная размерность матрицы. Попробуйте ещё раз\n ");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Получение первой матрицы
        /// </summary>
        static int[,] FirstMatrix(int row, int col)
        {
            Random rand = new Random();

            int[,] MatrixA = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    MatrixA[i, j] = rand.Next(10);
                }

            }
            return MatrixA;
        }
        /// <summary>
        /// Получение второй матрицы
        /// </summary>
        static int[,] SecondMatrix(int row, int col)
        {
            Random rand = new Random();

            int[,] MatrixB = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    MatrixB[i, j] = rand.Next(10);
                }

            }
            return MatrixB;
        }

        static int[] NullMatrix()
        {
            int[] matrix = new int[1];
            matrix[0] = 0;
            return matrix;
        }


        /// <summary>
        /// Вызов всех функций
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            for (; ; )
            {
                int row = DataRow();
                int col = DataCol();
                bool res = CheckRowCol(row, col);
                if (res == true)
                {
                    int[,] matrix = FirstMatrix(row, col);

                    int number = DataNumber();

                    PrintMul(matrix, number);

                    int[,] newmatrix = MulMatrixNumber(number, matrix);
                    PrintMul(newmatrix);
                    break;
                }
                else
                {
                    NullMatrix();
                    continue;
                }
            }

            Console.Clear();

            for (; ; )
            {
                int row1 = DataRow();
                int col1 = DataCol();
                bool res1 = CheckRowCol(row1, col1);

                int row2 = DataRow();
                int col2 = DataCol();
                bool res2 = CheckRowCol(row2, col2);

                if (res1 == true && res2 == true)
                {
                    bool res = CheckSum(row1, col1, row2, col2);
                    if (res == true)
                    {
                        int[,] MatrixA = FirstMatrix(row1, col1);
                        int[,] MatrixB = SecondMatrix(row2, col2);
                        Console.WriteLine("Первая матрица: ");
                        Print(MatrixA);
                        Console.WriteLine("Вторая матрица: ");
                        Print(MatrixB);
                        int[,] matrixC = SumMatrix(MatrixA, MatrixB);
                        PrintSum(matrixC);
                        break;
                    }
                    else
                    {
                        NullMatrix();
                        continue;
                    }
                }
                else
                {
                    NullMatrix();
                    continue;
                }
            }

            Console.Clear();

            for (; ; )
            {
                int row1 = DataRow();
                int col1 = DataCol();
                bool res1 = CheckRowCol(row1, col1);

                int row2 = DataRow();
                int col2 = DataCol();
                bool res2 = CheckRowCol(row2, col2);

                if (res1 == true && res2 == true)
                {
                    bool res = CheckMul(row1, col1, row2, col2);
                    if (res == true)
                    {
                        int[,] MatrixC = FirstMatrix(row1, col1);
                        int[,] MatrixD = SecondMatrix(row2, col2);
                        Console.WriteLine("Первая матрица: ");
                        Print(MatrixC);
                        Console.WriteLine("Вторая матрица: ");
                        Print(MatrixD);
                        int[,] MatrixE = MulMatrix(MatrixC, MatrixD);
                        PrintMul(MatrixE);
                        break;
                    }

                    else
                    {
                        NullMatrix();
                        continue;
                    }
                }
                else
                {
                    NullMatrix();
                    continue;
                }

            }
        }
    }
}
