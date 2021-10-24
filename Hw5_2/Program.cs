using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5_2
{
    class Program
    {
        static string Text()
        {
            Console.WriteLine("Введите текст:");
            string txt = Console.ReadLine();
            return txt;
        }

        static void Print(string wordmin, string wordmax)
        {
            Console.WriteLine("Самое короткое слово : {0}", wordmin);
            Console.WriteLine("Самое длинное слово : {0}", wordmax);
            Console.ReadKey();
        }
        static string MinWord(string text)
        {
            string outText = "";

            string[] t = text.Split(' ', '.', ',');

            int min = t[0].Length;
            int minI = 0;

            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] != "")
                {
                    if (min >= t[i].Length)
                    {
                        min = t[i].Length;
                        minI = i;
                        if (min == 1) { break; }
                    }
                }
            }
            outText = t[minI];

            return outText;
        }


        static string MaxWord(string text)
        {
            string[] t = text.Split(' ', '.', ',');

            string outText = "";

            int max = t[0].Length, maxI = 0, maxC = 0;

            for (int i = 0; i < t.Length; i++)
            {
                if (t[i].Length >= max)
                {
                    max = t[i].Length;
                    maxI = i;
                }
            }
            maxC++;

            for (int i = 0; i < t.Length; i++)
            {
                if (t[maxI].Length == t[i].Length && i != maxI)
                {
                    maxC++;
                }
            }

            string[] texts = new string[maxC];

            texts[0] = $"{t[maxI]}";

            int j = 1;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[maxI].Length == t[i].Length && i != maxI)
                {
                    texts[j] = $"{t[i]}, ";
                    j++;
                }
            }

            Array.Sort(texts);

            foreach (var item in texts)
            {
                outText += item;
            }

            return outText;
        }


        static void Main(string[] args)
        {
            string text = Text();
            string wordmin = MinWord(text);
            string wordmax= MaxWord(text);

            Print(wordmin, wordmax);
            
        }
    }
}
