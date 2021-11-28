using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw7
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Note.txt";
            string savepath = "NewNote.txt";
            string importfile = "ImportNote.txt";
            int line;
            string date, date1, date2, name, id, age, height, weight;

            Repository rp = new Repository(new Note());

            while (true)
            {
                Console.WriteLine("Выберите действие:\n");
                Console.WriteLine("1 - загрузка данных из файла");
                Console.WriteLine("2 - сохранение данных в файл");
                Console.WriteLine("3 - создание записи");
                Console.WriteLine("4 - удаление записи");
                Console.WriteLine("5 - редактирование записи");
                Console.WriteLine("6 - импорт записей по диапазону дат");
                Console.WriteLine("7 - сортировка записей по полю");
                Console.WriteLine("8 - вывод ежедневника на экран");
                Console.WriteLine("0 - выход");
                int key;
                bool res = true;
                res = int.TryParse(Console.ReadLine(), out key);
                if (res == false)
                {
                    Console.WriteLine("Введите число от 1 до 8, 0 для выхода");
                }
                else
                {
                    switch (key)
                    {
                        case 1:
                            rp.Load(path);
                            Console.Clear();
                            Console.WriteLine("Файл загружен\n\n");
                            rp.PrintToConsole();
                            Console.ReadLine();
                            break;

                        case 2:
                            rp.Save(savepath);
                            Console.Clear();
                            Console.WriteLine("Файл сохранен\n\n");
                            rp.PrintToConsole();
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("Введите номер записи ");
                            id = Console.ReadLine();
                            Console.WriteLine("Введите дату(формат dd.mm.yyyy) ");
                            date = Console.ReadLine();
                            Console.WriteLine("Введите имя ");
                            name = Console.ReadLine();
                            Console.WriteLine("Введите возраст ");
                            age = Console.ReadLine();
                            Console.WriteLine("Введите рост ");
                            height = Console.ReadLine();
                            Console.WriteLine("Введите вес ");
                            weight = Console.ReadLine();
                            rp.AddItem(id, date, name, age, height, weight);
                            Console.Clear();
                            Console.WriteLine("Данные добавлены\n\n");
                            rp.PrintToConsole();
                            Console.ReadLine();
                            break;

                        case 4:
                            Console.WriteLine("Введите номер строки для удаления ");
                            line = int.Parse(Console.ReadLine());
                            bool result = rp.Delete(line); ;
                            if (result == true)
                            {
                                Console.Clear();
                                Console.WriteLine("Запись удалена\n\n");
                                rp.PrintToConsole();
                                Console.ReadLine();
                                break;
                            }
                            else  break; 
                            

                        case 5:
                            Console.WriteLine("Введите номер строки для редактирования ");
                            line = int.Parse(Console.ReadLine());
                            bool res5 = rp.Edit(line);
                            if (res5 == true)
                            {
                                Console.Clear();
                                Console.WriteLine("Данные отредактированы\n\n");
                                rp.PrintToConsole();
                                Console.ReadLine();
                                break;
                            }
                            else break;
                           

                        case 6:
                            Console.WriteLine("Введите начальную дату для импорта (формат dd.mm.yyyy) ");
                            date1 = Console.ReadLine();
                            Console.WriteLine("Введите конечную дату для импорта (формат dd.mm.yyyy) ");
                            date2 = Console.ReadLine();
                            rp.Import(date1, date2, importfile);
                            Console.Clear();
                            Console.WriteLine("Данные импортрованы\n\n");
                            rp.PrintToConsole();
                            Console.ReadLine();
                            break;

                        case 7:
                            Console.WriteLine("Введите номер поля, по которому сделать сортировку ");
                            Console.WriteLine("1 - Номер записи");
                            Console.WriteLine("2 - Дата");
                            Console.WriteLine("3 - Имя");
                            Console.WriteLine("4 - Возраст");
                            Console.WriteLine("5 - Рост");
                            Console.WriteLine("6 - Вес");
                            line = int.Parse(Console.ReadLine());
                            rp.Sort(line);
                            Console.Clear();
                            Console.WriteLine("Данные отсортированы\n\n");
                            rp.PrintToConsole();
                            Console.ReadLine();
                            break;

                        case 8:
                            Console.Clear();
                            rp.PrintToConsole();
                            Console.ReadLine();
                            break;

                        case 0:
                            return;
                        default: break;
                    }
                }
            }
        }
    }
}