using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5_3
{
    class Program
    {
        /// <summary>
        /// Очистка текста
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string ClearText(string text)
        {
            string outClearText = "";

            text += " ";

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] != text[i + 1])
                {
                    outClearText += $"{text[i]}";
                }
            }

            return outClearText;
        }
        /// <summary>
        /// Получение текста
        /// </summary>
        /// <returns></returns>
        static string DataText()
        {
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();
            return text;
        }
        /// <summary>
        /// Вывод на экран результата
        /// </summary>
        /// <param name="text"></param>
        static void Print(string text)
        {
            Console.WriteLine($"Отформатированный текст: {text}");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
             string text = DataText();
             string cleartext = ClearText(text.ToLower());
            Print(cleartext);
             
        }
    }
}
