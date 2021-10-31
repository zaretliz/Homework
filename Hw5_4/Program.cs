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
            int n = nums.Length;
            if (n <= 2)
            {
                return false;
            }
            else
            {
                int dif = nums[1] - nums[0];
                

                for (int i = 1; i < nums.Length - 1; i++)
                {
                    if (nums[i] != nums[i - 1] + (i - 1) * dif)
                        return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Проверка на геометрическую прогрессию
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool IsProgressionGeo(int[] nums)
        {
            int n = nums.Length;
            if (n <= 2)
            {
                return false;
            }   
            else
            {
                int q = nums[1] / (nums[0]);

                for (int i = 1; i < n; i++)
                {
                    if (nums[i] == 0) return false;
                    else if ((nums[i] / (nums[i - 1])) != q) return false;
                }

                return true;
            }
                

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
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] = int.Parse(temp[i]);
                    }
                    return nums;

                }
            }
            while (true);
        }
        /// <summary>
        /// Проверка ввода данных
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
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
                Console.WriteLine("Последовательность является арифметической прогресcией");
            }
            else
            {
                Console.WriteLine("Последовательность не является арифметической прогрессией");
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
                Console.WriteLine("Последовательность является геометрической прогресcией");
            }
            else
            {
                Console.WriteLine("Последовательность не является геометрической прогресcией");
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
