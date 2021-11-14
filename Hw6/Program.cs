using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

namespace Hw6
{
    class Program
    {
            
        /// <summary>
        /// Чтение номера из файла
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ReadNumber(string str)
        {
            try
            {
                string line;
                using (StreamReader streamReader = new StreamReader(str))
                {
                    line = streamReader.ReadLine();
                }
                return int.Parse(line); ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
        /// <summary>
        /// Вывод на консоль количества групп
        /// </summary>
        /// <param name="N"></param>
        public static void Group(int N)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            int count = 0;
            if (N > 0)
            {
                string path = @"number.txt";
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    int number = 1;

                    for (int i = 1; i <= N; i++)
                    {
                        if (i % number == 0)
                        {
                            count++;
                            number = i;
                            streamWriter.Write($"\nГруппа {count}: {i}");

                        }
                        else
                        {
                            streamWriter.Write($" {i}");
                        }
                    }
                }
            }
            Console.WriteLine($" Количество групп при N = {N}, равно {count}");

            time.Stop(); 
            Console.WriteLine($"Время работы {time.Elapsed} "); 

        }
        /// <summary>
        /// Создание групп в файле
        /// </summary>
        /// <param name="N"></param>
        public static void GroupFile(int N)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int count = 0;
            if (N > 0)
            {
                string path = @"number.txt";
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    int number = 1;
                    
                    for (int i = 1; i <= N; i++)
                    {
                        if (i % number == 0)
                        {
                            count++;
                            number = i;
                            streamWriter.Write($"\nГруппа {count}: {i}");

                        }
                        else
                        {
                            streamWriter.Write($" {i}");
                        }
                    }
                }

                Console.WriteLine($"\nФайл с группами записан в {path}.zip");

                timer.Stop();
                Console.WriteLine($"Время работы {timer.Elapsed} ");

                Console.WriteLine("Хотите заархивировать файл? \n y / n ? ");

                bool answer = Char.ToLower(Console.ReadKey().KeyChar) == 'y';
                if (answer)
                    CompressZip(path);
            }
        }
        /// <summary>
        /// Архивация
        /// </summary>
        /// <param name="path"></param>
        public static void CompressZip(string path)
        {
            string compressed = @"number.zip";


            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (FileStream zipfileStream = File.Create(compressed))
                {
                    using (GZipStream gZipStream = new GZipStream(zipfileStream, CompressionMode.Compress))
                    {
                        fileStream.CopyTo(gZipStream);
                        Console.WriteLine($"\nСжатие файла {path} завершено." +
                            $"\n Размер файла иходного : {fileStream.Length} " +
                            $"\n Размер файла сжатого :{zipfileStream.Length} ");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            string str = @"D:\number.txt";

            Console.WriteLine($"Файл с числом должен находится {str}");

            // Чтение из файла
            int N = ReadNumber(@"D:\number.txt");

            //Выбор действия
            Console.WriteLine($"Получено число из файла {N}\n Выберите дальнейший вариант работы" +
                "\n 1 - Для вывода количества групп " +
                "\n 2 - Для записи групп в файл и вывода их в консоль ");

            string read = Console.ReadLine();
            switch (read)
            {
                case "1":
                    Group(N);
                    break;
                case "2":
                    GroupFile(N);
                    break;
                   
            }
            Console.ReadKey();
        }
    }
}
