using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw7
{
    struct Note
    {
        #region Свойства
        /// <summary>
        /// Номер записи
        /// </summary>
        public int ID { get { return this.id; } set { this.id = value; } }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime Data { get { return this.data; } set { this.data = value; } }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get { return this.name; } set { this.name = value; } }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get { return this.age; } set { this.age = value; } }

        /// <summary>
        /// Рост
        /// </summary>
        public int Height { get { return this.height; } set { this.height = value; } }

        /// <summary>
        /// Вес
        /// </summary>
        public int Weight { get { return this.weight; } set { this.weight = value; } }
        #endregion
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Data"></param>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="Weight"></param>
        public Note(int ID, DateTime Data, string Name, int Age, int Height, int Weight)
        {
            this.id = ID;
            this.data = Data;
            this.name = Name;
            this.age = Age;
            this.height = Height;
            this.weight = Weight;
        }

        /// <summary>
        /// Вывод данных в строке
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{this.ID,10} {this.Data,25} {this.Name,10} {this.Age,10} {this.Height,17} {this.Weight,10}";
        }

        #region Поля
        private int id;
        private DateTime data;
        private string name;
        private int age;
        private int height;
        private int weight;
        #endregion
    }
}