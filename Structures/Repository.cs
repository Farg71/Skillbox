using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillbox
{
    internal class Repository
    {
        /// <summary>
        /// База данных сотрудников
        /// </summary>
        public Employee[] Employees;

        public Employee this[int index]
        {
            get { return Employees[index]; }
            set { Employees[index] = value; }
        }

        /// <summary>
        /// Выводит данные о сотруднике в виде строки
        /// </summary>
        /// <param name="ind">индекс массива в string</param>
        /// <returns></returns>
        public string this[string ind]
        {
            get { return this[Convert.ToInt32(ind)].ToDBString(); }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="employees">Массив сотрудников</param>
        public Repository(params Employee[] employees)
        {
            Employees = employees;  // ?? throw new ArgumentNullException(nameof(employees));
        }
    }
}
