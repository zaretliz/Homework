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
        /// Проверка нак арифметическую прогрессию
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool IsProgressionAr(int[] nums)
        {
            int dif = nums[1] - nums[0];
            bool isArithmetic = true;

            for (int i = 1; i < nums.Length-1; i++)
            {
                if (nums[i] != nums[i -1] + (i -1) * dif)
                    isArithmetic = false;
                
            }
            return isArithmetic;
        }

        /// <summary>
        /// Проверка на геометрическую прогрессию
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool IsProgressionGeo(int[] nums)
        { 

            bool isGeometric = true;

            for (int i = 1; i < nums.Length-1; i++)
            {
                if (Math.Abs(nums[i]) != Math.Sqrt((nums[i - 1] * nums[i + 1])))
                    isGeometric = false;
     


            }
            return isGeometric;
        }

        /// <summary>
        /// Получение исходной информации
        /// </summary>
        /// <returns></returns>
        static int[] Data()
        {

            do
            {
                Console.WriteLine("Введите через пробел последовательность чисел: ");
                string test = Console.ReadLine();
                string[] temp = test.Split(' ');
                int[] nums = new int[temp.Length];
                bool res = Check(temp);
                if (res == true)
                {
                    for (int i = 0; i < nums.Length - 1; i++)
                    {
                        nums[i] = int.Parse(temp[i]);
                    }
                    return nums;

                }
            }
            while (true);
        }
        static bool Check(string[] temp)
        {
            bool res = true;
            for (int i = 0; i < temp.Length; i++)
            {
                int x;
                res = int.TryParse(temp[i], out x);
                if (res == false)
                 { 
                    Console.WriteLine("Последовательность не числовая");
                    return res; 
                 }
                
            }
            return res;

        }

        /// <summary>
        /// Вывод результата
        /// </summary>
        /// <param name="args"></param>
        static void PrintAl(bool result)
        {
            if (result == true)
            {
                Console.WriteLine("Последовательность является частью арифметической прогресcии");
            }
            else
            {
                Console.WriteLine("Последовательность не является частью арифметической прогрессии");
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
                Console.WriteLine("Последовательность является частью геометрической прогресcии");
            }
            else
            {
                Console.WriteLine("Последовательность не является частью геометрической прогресcии");
            }
            Console.ReadKey();
        }
static void Main(string[] args)
        {
            int[] numbers = Data();


            bool result1 = IsProgressionAr(numbers);               
            PrintAl(result1);
            if (result1 == false)
            {
                bool result2 = IsProgressionGeo(numbers);
                PrintGeo(result2);
            }
            


        }
    }
}
