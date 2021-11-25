using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hw7
{
    /// <summary>
    /// Репозиторий
    /// </summary>
    struct Repository
    {
        /// <summary>
        /// Массив для ежедневника
        /// </summary>
        private List<Note> note;

        /// <summary>
        /// Массив заголовков в файле
        /// </summary>
        string[] titles;



        /// <summary>
        /// Конструктор
        /// </summary>
        public Repository(params Note[] args)
        {
            note = args.ToList();
            titles = new string[] { "Идентификатор", "Дата", "Имя", "Возраст", "Рост", "Вес" };
        }

        /// <summary>
        /// Метод создания/добавление записей
        /// </summary>
        /// <param name="NewNote">Новая запись</param>
        public void AddLine(Note NewNote)
        {
            note.Add(NewNote);
        }
        /// <summary>
        /// Метод загрузки данных
        /// </summary>
        public void Load(string path)
        {
            note.Clear();

            using (StreamReader read = new StreamReader(path))
            {
                while (!read.EndOfStream)
                {
                    string[] arg = read.ReadLine().Split(',');
                    AddLine(new Note(Convert.ToInt32(arg[0]),
                                     Convert.ToDateTime(arg[1]),
                                     arg[2],
                                     Convert.ToInt32(arg[3]),
                                     Convert.ToInt32(arg[4]),
                                     Convert.ToInt32(arg[5])));
                }
            }
        }
        public void AddItem(params string[] arg)
        {
            AddLine(new Note(Convert.ToInt32(arg[0]),
                                     Convert.ToDateTime(arg[1]),
                                     arg[2],
                                     Convert.ToInt32(arg[3]),
                                     Convert.ToInt32(arg[4]),
                                     Convert.ToInt32(arg[5])));
        }
        /// <summary>
        /// Добавление данных из файла
        /// </summary>
        public void FromFile(string addfile)
        {
            note.Clear();

            using (StreamReader read = new StreamReader(addfile))
            {
                while (!read.EndOfStream)
                {
                    string[] arg = read.ReadLine().Split(',');
                    AddLine(new Note(Convert.ToInt32(arg[0]),
                                     Convert.ToDateTime(arg[1]),
                                     arg[2],
                                     Convert.ToInt32(arg[3]),
                                     Convert.ToInt32(arg[4]),
                                     Convert.ToInt32(arg[5])));
                }
            }
        }
        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        /// <param name="savepath"></param>
        public void Save(string savepath)
        {
            File.Delete(savepath);
            string temp = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                        this.titles[0],
                                        this.titles[1],
                                        this.titles[2],
                                        this.titles[3],
                                        this.titles[4],
                                        this.titles[5]);

            File.AppendAllText(savepath, $"{temp}\n");

            for (int i = 0; i < note.Count; i++)
            {
                temp = String.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                            this.note[i].ID,
                                            this.note[i].Data,
                                            this.note[i].Name,
                                            this.note[i].Age,
                                            this.note[i].Height,
                                            this.note[i].Weight);

                File.AppendAllText(savepath, $"{temp}\n");

            }
        }
        /// <summary>
        /// Вывод данных на консоль
        /// </summary>
        public void PrintToConsole()
        {
            Console.WriteLine($"{this.titles[0],5} {this.titles[1],15} {this.titles[2],15} {this.titles[3],15} {this.titles[4],15} {this.titles[5],10}");

            for (int i = 0; i < note.Count; i++)
            {
                Console.WriteLine(this.note[i].Print());
            }
        }
        /// <summary>
        /// Метод удаления записей
        /// </summary>
        /// <param name="line">Номер строки для удаления</param>
        public void Delete(int line)
        {
            note.RemoveAt(line - 1);
        }
        /// <summary>
        /// Метод импорта записей по диапазону дат
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="importfile"></param>
        public void Import(string date1, string date2, string importfile)
        {
            DateTime startDate = Convert.ToDateTime(date1);
            DateTime endDate = Convert.ToDateTime(date2);

            using (StreamReader read = new StreamReader(importfile))
            {
                while (!read.EndOfStream)
                {
                    string[] arg = read.ReadLine().Split(',');
                    DateTime arg0 = Convert.ToDateTime(arg[1]);

                    if (arg0 >= startDate && arg0 <= endDate)
                    {
                        AddLine(new Note(Convert.ToInt32(arg[0]),
                                                             Convert.ToDateTime(arg[1]),
                                                             arg[2],
                                                             Convert.ToInt32(arg[3]),
                                                             Convert.ToInt32(arg[4]),
                                                             Convert.ToInt32(arg[5])));
                    }
                }
            }
        }
        /// <summary>
        /// Сортировка по полю
        /// </summary>
        /// <param name="line"></param>
        public void Sort(int line)
        {
            switch (line)
            {
                case 1:
                    note = note.OrderBy(e => e.ID)
                        .ThenBy(e => e.Data)
                        .ThenBy(e => e.Name)
                        .ThenBy(e => e.Age)
                        .ThenBy(e => e.Height)
                        .ThenBy(e => e.Weight)
                        .ToList();
                    break;

                case 2:
                    note = note.OrderBy(e => e.Data)
                        .ThenBy(e => e.ID)
                        .ThenBy(e => e.Name)
                        .ThenBy(e => e.Age)
                        .ThenBy(e => e.Height)
                        .ThenBy(e => e.Weight)
                        .ToList();
                    break;

                case 3:
                    note = note.OrderBy(e => e.Name)
                        .ThenBy(e => e.ID)
                        .ThenBy(e => e.Data)
                        .ThenBy(e => e.Age)
                        .ThenBy(e => e.Height)
                        .ThenBy(e => e.Weight)
                        .ToList();
                    break;

                case 4:
                    note = note.OrderBy(e => e.Age)
                        .ThenBy(e => e.ID)
                        .ThenBy(e => e.Data)
                        .ThenBy(e => e.Name)
                        .ThenBy(e => e.Height)
                        .ThenBy(e => e.Weight)
                        .ToList();
                    break;

                case 5:
                    note = note.OrderBy(e => e.Height)
                        .ThenBy(e => e.ID)
                        .ThenBy(e => e.Data)
                        .ThenBy(e => e.Name)
                        .ThenBy(e => e.Age)
                        .ThenBy(e => e.Weight)
                        .ToList();
                    break;

                case 6:
                    note = note.OrderBy(e => e.Weight)
                        .ThenBy(e => e.ID)
                        .ThenBy(e => e.Data)
                        .ThenBy(e => e.Name)
                        .ThenBy(e => e.Age)
                        .ThenBy(e => e.Height)
                        .ToList();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Редактирование записей
        /// </summary>
        /// <param name="line"></param>
        public void Edit(int line)
        {
            Note temp = new Note();
            Console.WriteLine("Введите новую дату: ");
            temp.Data = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Введите новое имя: ");
            temp.Name = Console.ReadLine();
            Console.WriteLine("Введите новый возраст: ");
            temp.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новый рост: ");
            temp.Height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новый вес: ");
            temp.Weight = Convert.ToInt32(Console.ReadLine());

            note[line - 1] = temp;
        }
    }
}