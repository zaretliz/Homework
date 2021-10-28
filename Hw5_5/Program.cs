using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5_5
{
    class Program
    {
        /// <summary>
        /// Функция Аккермана
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static int A(int n, int m)
        {
            if (n == 0)
            {
                return m + 1;
            }
            else if (n != 0 && m == 0)
            {
                return A(n - 1, 1);
            }
            else if (n > 0 && m > 0)
            {
                return A(n - 1, A(n,m - 1));
            }
            return 0;
        }
        /// <summary>
        /// Получение значения
        /// </summary>
        /// <returns></returns>
        static int DataN()
        {
            Console.Write("Введите значение N: ");
            int n = int.Parse(Console.ReadLine());
            return n;
        }
        /// <summary>
        /// Получение значения
        /// </summary>
        /// <returns></returns>
        static int DataM()
        {
            Console.Write("Введите значение M: ");
            int m = int.Parse(Console.ReadLine());
            return m;
        }
        /// <summary>
        /// Вывод результата
        /// </summary>
        /// <param name="result"></param>
        static void Print(int result)
        {
            Console.WriteLine($"Результат: {result}");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            int n = DataN();
            int m = DataM();
            int result = A(n, m);
            Print(result);
            
           
        }
    }
}
