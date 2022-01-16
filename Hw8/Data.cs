using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hw8
{
    public class Data
    {
        public List<Department> departments = new List<Department>();
        public List<Worker> workers = new List<Worker>();
        public string[] workersTitles = new string[] { "Индивидуальный номер сотрудника", "Фамилия", "Имя", "Возраст", "№ Отдела", "Зарплата", "Количество проектов" };
        public string[] departmentTitles = new[] { "№",  "Название отдела", "Дата создания", "Количество сотрудников" };
        private string json;
        private XmlSerializer xmlSerializer;

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="id">Номер сотрудника</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="department">№ отдела</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="projects">Количество проектов</param>
        public void AddWorker(string id, string lastName, string firstName, int age, int department, int salary, int projects)
        {
            
            departments[department - 1].workers.Add(new Worker(id, lastName, firstName, age, department, salary, projects));
        }

        /// <summary>
        /// Удаление работника
        /// </summary>
        /// <param name="idWorkers">Номер сотрудника</param>
        public void RemoveWorker(string surname, string firstname)
        {
            for (int i = 0; i < departments.Count; i++)
            {
                for (int j = 0; j < departments[i].workers.Count; j++)
                {
                    if (departments[i].workers[j].lastName == surname && departments[i].workers[j].firstName == firstname)
                    {
                        departments[i].workers.Remove(departments[i].workers[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Сортировка по полю
        /// </summary>
        /// <param name="num">Номер поля</param>
        public void SortWorkers(int num)
        {
            workers = new List<Worker>();
            for (int i = 0; i < departments.Count; i++)
            {
                for (int j = 0; j < departments[i].workers.Count; j++)
                {
                    workers.Add(departments[i].workers[j]);
                }
            }

            switch (num)
            {
                case 1:
                    workers = workers.OrderBy(e => e.id)
                        .ThenBy(e => e.lastName)
                        .ThenBy(e => e.firstName)
                        .ThenBy(e => e.age)
                        .ThenBy(e => e.department)
                        .ThenBy(e => e.salary)
                        .ThenBy(e => e.projects)
                        .ToList();
                    Console.Clear();
                    PrintSorteredWorkers();
                    Console.ReadLine();
                    break;
                case 2:
                    workers = workers.OrderBy(e => e.age)
                        .ThenBy(e => e.id)
                        .ThenBy(e => e.lastName)
                        .ThenBy(e => e.firstName)
                        .ThenBy(e => e.department)
                        .ThenBy(e => e.salary)
                        .ThenBy(e => e.projects)
                        .ToList();
                    Console.Clear();
                    PrintSorteredWorkers();
                    Console.ReadLine();
                    break;
                case 3:
                    workers = workers.OrderBy(e => e.salary)
                        .ThenBy(e => e.id)
                        .ThenBy(e => e.lastName)
                        .ThenBy(e => e.firstName)
                        .ThenBy(e => e.age)
                        .ThenBy(e => e.department)
                        .ThenBy(e => e.projects)
                        .ToList();
                    Console.Clear();
                    PrintSorteredWorkers();
                    Console.ReadLine();
                    break;
                
            }
        }

        /// <summary>
        /// Добавление отдела
        /// </summary>
        /// <param name="departmentName">Имя отдела</param>
        /// <param name="dateOfCreation">Дата создания</param>
        public void AddDepartment(string departmentName, string dateOfCreation)
        {
            departments.Add(new Department(departmentName, dateOfCreation));
        }

        /// <summary>
        /// Удаление отдела
        /// </summary>
        /// <param name="depNum">Номер отдела</param>
        public void RemoteDepartment(int depNum)
        {
            departments.Remove(departments[depNum - 1]);
        }

        
        /// <summary>
        /// Вывод массива сотрудников
        /// </summary>
        public void PrintWorkers()
        {
            Console.WriteLine($"{workersTitles[0],10} {workersTitles[1],15} {workersTitles[2],10} {workersTitles[3],10}" +
                              $"{workersTitles[4],10} {workersTitles[5],10} {workersTitles[6],15}");

            for (int i = 0; i < departments.Count; i++)
            {
                for (int j = 0; j < departments[i].workers.Count; j++)
                {
                    Console.WriteLine($"{departments[i].workers[j].id} {departments[i].workers[j].lastName,13}" +
                                      $"{departments[i].workers[j].firstName,13} {departments[i].workers[j].age,8}" +
                                      $"{departments[i].workers[j].department,10} {departments[i].workers[j].salary,10} {departments[i].workers[j].projects,10}");
                }
            }
        }

        /// <summary>
        /// Вывод массива после сортировки
        /// </summary>
        public void PrintSorteredWorkers()
        {
            Console.WriteLine($"{workersTitles[0],10} {workersTitles[1],10} {workersTitles[2],10} {workersTitles[3],10}" +
                              $"{workersTitles[4],10} {workersTitles[5],10} {workersTitles[6],10}");

            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine($"{workers[i].id,10} {workers[i].lastName,10} {workers[i].firstName,10} " +
                                  $"{workers[i].age,10} {workers[i].department,10} {workers[i].salary,10} {workers[i].projects,10}");
            }

        }

        /// <summary>
        /// Вывод массива отделов
        /// </summary>
        public void PrintDepartment()
        {
            int num = 0;
            Console.WriteLine($" {departmentTitles[0]} {departmentTitles[1],10} {departmentTitles[2],15} {departmentTitles[3],10}");
            foreach (var dep in departments)
            {
                ++num;
                Console.WriteLine($"{num} " + dep.PrintDepartment() + $"{dep.workers.Count,10}");
            }
        }

        /// <summary>
        /// Запись в json
        /// </summary>
        /// <param name="path">Файл</param>
        public void SerializeJson(string path)
        {
            json = JsonConvert.SerializeObject(departments);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Расшифровка из json
        /// </summary>
        /// <param name="path">Файл</param>
        public void DeserializeJson(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден");
                Console.ReadLine();
                return;
            }
            departments.Clear();
            json = File.ReadAllText(path);
            departments = JsonConvert.DeserializeObject<List<Department>>(json);
        }

        /// <summary>
        /// Запись в xml
        /// </summary>
        /// <param name="path">Файл</param>
        public void SerializeXml(string path)
        {
            xmlSerializer = new XmlSerializer(typeof(List<Department>));
            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                xmlSerializer.Serialize(streamWriter, departments);
            }
        }

        /// <summary>
        /// Расшифровка из xml
        /// </summary>
        /// <param name="path">Файл</param>
        public void DeserializeXml(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден");
                Console.ReadLine();
            }

            using (StreamReader streamReader = new StreamReader(path))
            {
                xmlSerializer = new XmlSerializer(typeof(List<Department>));
                departments = (List<Department>)xmlSerializer.Deserialize(streamReader);
            }
        }
    }
}
    
