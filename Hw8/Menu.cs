using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw8
{
    /// <summary>
    /// Меню программы
    /// </summary>
    public class Menu
    {
        bool isShowMenu = true;
        string title, lastName, firstName, id, surname, name;
        int input, salary, age,  number, num, projects;
        Data data = new Data();
        private DateTime dateTime = new DateTime(2022, 2, 22); 
        string pathJson = "data.json";
        string pathXml = "data.xml";
        
        /// <summary>
        /// Вывод меню
        /// </summary>
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавление информации");
                Console.WriteLine("2 - Сортировка информации");
                Console.WriteLine("3 - Удаление информации");
                Console.WriteLine("4 - Вывод информации на экран");
                Console.WriteLine("5 - Загрузить из файла");
                Console.WriteLine("6 - Сохранить в файл");
                Console.WriteLine("0 - Выход");

                CheckInput(ref input);
                switch (input)
                {
                    case 1:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            AddData();
                        }
                        break;
                    
                    case 2:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            SortData();
                        }
                        break;
                    case 3:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            RemoteData();
                        }
                        break;
                    case 4:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            PrintData();
                            isShowMenu = false;
                        }
                        break;
                    case 5:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            LoadData();
                        }
                        break;
                    case 6:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            SaveData();
                        }
                        break;

                    default:
                        return;
                } 
            }
        }
        private void CheckInput(ref int input)
        {
            while (!Int32.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Необходимо ввести число");
            }
        }

        private void CheckDateInput(ref DateTime dateTime)
        {
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.WriteLine("Неверный формат даты (необходимо dd.mm.yyyy)");
            }
        }
        
        private void AddData()
        {
            Console.Clear();
            Console.WriteLine("Доступные действия:");
            Console.WriteLine("1 - Добавить отдел");
            Console.WriteLine("2 - Добавить работника");
            Console.WriteLine("0 - Выход в главное меню");

            CheckInput(ref input);

            switch (input)
            {
                case 1:
                    Console.WriteLine("Введите имя отдела");
                    title = Console.ReadLine();
                    Console.WriteLine("Введите дату (dd.mm.yyyy)");
                    CheckDateInput(ref dateTime);
                    data.AddDepartment(title, dateTime.ToString("dd.mm.yyyy"));
                    Console.Clear();
                    data.PrintDepartment();
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    if (data.departments.Count > 0)
                    {
                        Console.WriteLine("Введите Фамилию:");
                        lastName = Console.ReadLine();
                        Console.WriteLine("Введите Имя:");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Введите Возраст:");
                        CheckInput(ref age);  
                        Console.WriteLine("Введите индивидуальный номер сотрудника: (32 цифры)");
                        id = Console.ReadLine();
                        //CheckInput(ref id);
                        Console.WriteLine("Введите значение зарплаты:");
                        CheckInput(ref salary);
                        Console.WriteLine("Введите количество проектов у сотрудника:");
                        CheckInput(ref projects);
                        Console.WriteLine("Введите номер отдела:");
                        CheckInput(ref num);
                        if (num <= 0 || num < data.departments.Count - 1)
                        {
                            Console.WriteLine("Необходимо ввести число:");
                            num = int.Parse(Console.ReadLine());
                        }
                        number = num;
                        data.AddWorker(id, lastName, firstName, age, number, salary, projects);
                    }
                    else
                    {
                        Console.WriteLine("Нужно добавить отдел");
                    }
                    Console.Clear();
                    data.PrintDepartment();
                    Console.WriteLine();
                    data.PrintWorkers();
                    Console.ReadLine();
                    break;
                case 0:
                    isShowMenu = false;
                    break;
            }
        }

        

        

        private void SortData()
        {
            Console.Clear();
            Console.WriteLine("Сортировка сотрудников:");
            Console.WriteLine("1 - По индивидуальному номеру");
            Console.WriteLine("2 - По возрасту");
            Console.WriteLine("3 - По зарплате");;
            Console.WriteLine("0 - Выход в главное меню");
            
            CheckInput(ref input);

            switch (input)
            {
                case 1:
                case 2:
                case 3:
                data.SortWorkers(input);
                Console.Clear();
                    break;
                case 0:
                    isShowMenu = false;
                    break;
            }
        }

        private void RemoteData()
        {
            Console.Clear();
            Console.WriteLine("1 - Удалить отдел");
            Console.WriteLine("2 - Удалить сотрудника");
            Console.WriteLine("0 - Выход в главное меню");

            CheckInput(ref input);

            switch (input)
            {
                case 1:
                    data.PrintDepartment();
                    Console.WriteLine();
                    Console.WriteLine("Введите номер отдела");
                    CheckInput(ref num);
                    data.RemoteDepartment(num);
                    Console.Clear();
                    data.PrintDepartment();
                    Console.ReadLine();
                    break;
                case 2:
                    data.PrintWorkers();
                    Console.WriteLine();
                    Console.WriteLine("Введите фамилию сотрудника");
                    surname = Console.ReadLine();
                    Console.WriteLine("Введите имя сотрудника");
                    name = Console.ReadLine();
                    data.RemoveWorker(surname,name);
                    Console.Clear();
                    data.PrintWorkers();
                    Console.ReadLine();
                    break;
                case 0:
                    isShowMenu = false;
                    break;
            }
        }

        private void PrintData()
        {
            if (data.departments.Count > 0)
            {
                data.PrintDepartment();
                data.PrintWorkers(); 
            }
            else
            {
                Console.WriteLine("Нет ни одного отдела");
            }
        }

        private void SaveData()
        {
            Console.WriteLine("Формат для сохранения:");
            Console.WriteLine("1 - Json");
            Console.WriteLine("2 - Xml");
            Console.WriteLine("0 - Выход в главное меню");
            
            CheckInput(ref input);

            switch (input)
            {
                case 1:
                    data.SerializeJson(pathJson);
                    Console.WriteLine("Успешное сохранение в формате json");
                    break;
                case 2:
                    data.SerializeXml(pathXml);
                    Console.WriteLine("Успешное сохранение в формате xml");
                    break;
                case 0:
                    isShowMenu = false;
                    break;
            }
        }

        private void LoadData()
        {
            Console.WriteLine("Загрузить из файла с форматом:");
            Console.WriteLine("1 - Json");
            Console.WriteLine("2 - Xml");
            Console.WriteLine("0 - Выход в главное меню");
            
            CheckInput(ref input);

            switch (input)
            {
                case 1:
                    data.DeserializeJson(pathJson);
                    Console.WriteLine("Успешная загрузка из формата json");
                    break;
                case 2:
                    data.DeserializeXml(pathXml);
                    Console.WriteLine("Успешная загрузка из формата xml");
                    break;
                case 0:
                    isShowMenu = false;
                    break;
            }
        }
    }
}
