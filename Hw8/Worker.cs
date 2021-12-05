using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw8
{
   public struct Worker
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="LastName">Фамилия</param>
        /// <param name="FirstName">Имя</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Department">Отдел</param>
        /// <param name="Number">Уникальный номер</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="Projects">Количество проектов</param>
        public Worker(int ID,string LastName, string FirstName, int Age, int Department, int Salary, int Projects)
        {
            this.lastName = LastName;
            this.firstName = FirstName;
            this.age = Age;
            this.department = Department;
            this.id = ID;
            this.salary = Salary;
            this.projects = Projects;
        }

        #endregion

        #region Методы
        /// <summary>
        /// Вывод на консоль
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{this.lastName,10} {this.firstName,25} {this.age,10} {this.department,10} {this.department,17} {this.salary,10} {this.projects,10}";
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get { return this.age; } set { this.age = value; } }

        /// <summary>
        /// Отдел
        /// </summary>
        public int Department { get { return this.department; } set { this.department = value; } }

        /// <summary>
        /// Номер
        /// </summary>
        public int ID { get { return this.id; } set { this.id = value; } }

        /// <summary>
        /// Оплата труда
        /// </summary>
        public int Salary { get { return this.salary; } set { this.salary = value; } }

        /// <summary>
        /// Количество проектов
        /// </summary>
        public int Projects { get { return this.projects; } set { this.projects = value; } }


        #endregion

        #region Поля

        public string lastName;
        public string firstName;
        public int age;
        public int department;
        public int id;
        public int salary;
        public int projects;
        #endregion
    }
}
