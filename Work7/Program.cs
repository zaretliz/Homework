using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work7
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Note.txt";
            Repository rp = new Repository(path);

            Console.WriteLine("Записи из ежедневника");
            rp.PrintToConsole();

            Console.WriteLine("Добавление новой записи завершено");
            Note newNote = new Note(123,
                                    DateTime.Now,
                                    "test",
                                    20,
                                    178,
                                    65);
            rp.Add(newNote);
            Console.WriteLine("Изменения");
            rp.PrintToConsole();

            Console.WriteLine("Сохранение завершено");
            rp.Save(@"D:\Note1.txt");

            Console.ReadKey();

        }
    }
}
