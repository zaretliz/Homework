using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw8
{
    /// <summary>
    /// Отдел
    /// </summary>
    public struct Department
        {
            public string departmentName;
            public string dateOfCreation;
            public List<Worker> workers;

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="departmentName">Имя отдела</param>
            /// <param name="dateOfCreation">Дата создания</param>
            public Department(string departmentName, string dateOfCreation)
            {
                this.departmentName = departmentName;
                this.dateOfCreation = dateOfCreation;
                this.workers = new List<Worker>();
            }

            /// <summary>
            /// Вывод отдела на консоль
            /// </summary>
            /// <returns></returns>
            public string PrintDepartment()
            {
                return $"{this.departmentName,10} {this.dateOfCreation,18}";
            }
        }


    }
