using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work7
{
    /// <summary>
    /// Репозиторий
    /// </summary>
    struct Repository
    {
        /// <summary>
        /// Массив заголовков в файле
        /// </summary>
        string[] titles;

        /// <summary>
        /// Массив для ежедневника
        /// </summary>
        private Note[] note;

        /// <summary>
        ///  Путь к файлу 
        /// </summary>
        private string path;

        /// <summary>
        /// Индекс элемента в массиве
        /// </summary>
        int index;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Path">Путь в файлу с данными</param>
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.titles = new string[0];
            this.note = new Note[1];

            this.Load();
        }

        /// <summary>
        /// Метод увеличения текущего хранилища
        /// </summary>
        /// <param name="Flag">Условие увеличения</param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.note, this.note.Length * 2);
            }
        }

        /// <summary>
        /// Метод записи данных в хранилище
        /// </summary>
        /// <param name="NewNote">Новая запись</param>
        public void Add(Note NewNote)
        {
            this.Resize(index >= this.note.Length);
            this.note[index] = NewNote;
            this.index++;
        }


        /// <summary>
        /// Метод загрузки данных
        /// </summary>
        private void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                titles = sr.ReadLine().Split(',');


                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    Add(new Note(Convert.ToInt32(args[0]),
                                Convert.ToDateTime(args[1]),
                                args[2],
                                Convert.ToInt32(args[3]),
                                Convert.ToInt32(args[4]),
                                Convert.ToInt32(args[5])));
                }
            }
        }

        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        /// <param name="Path">Путь к файлу сохранения</param>
        public void Save(string Path)
        {
            string temp = String.Format("{0},{1},{2},{3},{4},{5}",
                                            this.titles[0],
                                            this.titles[1],
                                            this.titles[2],
                                            this.titles[3],
                                            this.titles[4],
                                            this.titles[5]);

            File.AppendAllText(Path, $"{temp}\n");

            for (int i = 0; i < this.index; i++)
            {
                temp = String.Format("{0},{1},{2},{3},{4},{5}",
                                        this.note[i].ID,
                                        this.note[i].Data,
                                        this.note[i].Name,
                                        this.note[i].Age,
                                        this.note[i].Height,
                                        this.note[i].Weight);
                File.AppendAllText(Path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Вывод данных в консоль
        /// </summary>
        public void PrintToConsole()
        {
            Console.WriteLine($"{this.titles[0],5} {this.titles[1],15} {this.titles[2],15} {this.titles[3],15} {this.titles[4],15} {this.titles[5],10}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.note[i].Print());
            }
        }



    }
}
