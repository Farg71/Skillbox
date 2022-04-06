using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    /// <summary>
    /// Описание сотрудника
    /// </summary>
    struct Employee
    {
        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// Ф.И.О. сотрудника
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Рост сотрудника
        /// </summary>
        public int Growth { get; set; }

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime DateBirth { get; set; }

        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        public string PlaceBirth { get; set; }

        /// <summary>
        /// Вывод данных о сотрунике
        /// </summary>
        public string Print()
        {
            return $"ID сотрудника: {Id} Дата и время добавления записи: {EntryTime} Ф.И.О.: {FullName} Возраст: {Age} " +
                $"Рост: {Growth} Дата рождения: {DateBirth.ToShortDateString()} Место рождения: {PlaceBirth}";
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Id">ID сотрудника</param>
        /// <param name="EntryTime">Дата и время добавления записи</param>
        /// <param name="FullName">Ф.И.О. сотрудника</param>
        /// <param name="Age">Возраст сотрудника</param>
        /// <param name="Growth">Рост сотрудника</param>
        /// <param name="DateBirth">Дата рождения сотрудника</param>
        /// <param name="PlaceBirth">Место рождения сотрудника</param>
        public Employee(int Id, DateTime EntryTime, string FullName, int Age, int Growth, DateTime DateBirth, string PlaceBirth)

        {
            this.Id = Id;
            this.EntryTime = EntryTime;
            this.FullName = FullName;
            this.Age = Age;
            this.Growth = Growth;
            this.DateBirth = DateBirth;
            this.PlaceBirth = PlaceBirth;
        }



    }
}
