using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5_4
{
    class Program
    {
        /// <summary>
        /// Проверка на арифметическую прогрессию
        /// </summary>
        /// <param name="numbers"></param>
        static bool ProgressionAlgebra(params int[] numbers)
        {
            bool progression = false;

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == ((numbers[i - 1] + numbers[i + 1]) / 2))
                {
                    progression = true;
                    return progression;
                }
                else
                {
                    progression = false;
                    return progression;
                }
            }
            return progression;
            
        }
        /// <summary>
        /// Проверка на геометрическую прогрессию
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        static bool ProgressionGeometry(params int[] numbers)
        {
            bool progression = false;

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (Math.Abs(numbers[i]) == Math.Sqrt((numbers[i - 1] * numbers[i + 1])))
                {
                   progression = true;
                    return progression;
                }
                else
                {
                    progression = false;
                    return progression;

                }
            }
            return progression;

        }
        /// <summary>
        /// Получение исходной информации
        /// </summary>
        /// <returns></returns>
        static string Data()
        {
            Console.Write("Введите через пробел последовательность чисел: ");
            string numbers = Console.ReadLine();
            return numbers;
        }
        /// <summary>
        /// Разделение текста и перевод в числа
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        static int[] Split(string numbers)
        {
            int[] nums = numbers.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            return nums;
        }
        /// <summary>
        /// Вывод результата
        /// </summary>
        /// <param name="args"></param>
        static void PrintAl(bool result)
        {
            if (result == true)
            {
                Console.WriteLine("Последовательность является частью арифметической прогресии");
            }
            else
            {
                Console.WriteLine("Последовательность неявляется частью прогресии");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Вывод результата
        /// </summary>
        /// <param name="result"></param>
        static void PrintGeo(bool result)
        {
             if (result == true)
            {
                Console.WriteLine("Последовательность является частью геометрической прогресии");
            }
            else
            {
                Console.WriteLine("Последовательность неявляется частью прогресии");
            }
            Console.ReadKey();
        }
static void Main(string[] args)
        {
            string text = Data();
            int[] numbers = Split(text);

            bool result1 = ProgressionAlgebra(numbers);
            if (result1 == true)
            {
                PrintAl(result1);
            }
            else
            {
                bool result2 = ProgressionGeometry(numbers);
                PrintGeo(result2);
            }

            
        }
    }
}
