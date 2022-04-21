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
        public int Id;

        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime EntryTime;

        /// <summary>
        /// Ф.И.О. сотрудника
        /// </summary>
        public string FullName;

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age;

        /// <summary>
        /// Рост сотрудника
        /// </summary>
        public int Growth;

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime DateBirth;

        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        public string PlaceBirth;

        /// <summary>
        /// Вывод данных о сотрунике
        /// </summary>
        public string Print()
        {
            return $"ID сотрудника: {Id} Дата и время добавления записи: {EntryTime} Ф.И.О.: {FullName} Возраст: {Age} " +
                $"Рост: {Growth} Дата рождения: {DateBirth.ToShortDateString()} Место рождения: {PlaceBirth}";
        }

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="Id">ID сотрудника</param>
        /// <param name="EntryTime">Дата и время добавления записи</param>
        /// <param name="FullName">Ф.И.О. сотрудника</param>
        /// <param name="Age">Возраст сотрудника</param>
        /// <param name="Growth">Рост сотрудника</param>
        /// <param name="DateBirth">Дата рождения сотрудника</param>
        /// <param name="PlaceBirth">Место рождения сотрудника</param>
        public Employee(int Id, DateTime EntryTime, string FullName, DateTime DateBirth, int Age, string PlaceBirth, int Growth)
        {
            this.Id = Id;
            this.EntryTime = EntryTime;
            this.FullName = FullName;
            this.DateBirth = DateBirth;
            this.Age = Age;
            this.PlaceBirth = PlaceBirth;
            this.Growth = Growth;
        }

        public Employee(int Id, string FullName, DateTime DateBirth, int Age, string PlaceBirth, int Growth) :
            this(Id, DateTime.UtcNow, FullName, DateBirth, Age, PlaceBirth, Growth)
        {

        }

        public Employee(int Id, string FullName, int Age, DateTime DateBirth, string PlaceBirth ) :
            this(Id, DateTime.UtcNow, FullName, DateBirth, Age, PlaceBirth, 160)
        {

        }

        public Employee(int Id, string FullName, int Age, DateTime DateBirth) :
            this(Id, DateTime.UtcNow, FullName, DateBirth, Age, "", 160)
        {

        }

        public Employee(int Id, string FullName, DateTime DateBirth) :
            this(Id, DateTime.UtcNow, FullName, DateBirth, DateTime.UtcNow.Year - DateBirth.Year, "", 160)
        {

        }

        public Employee(int Id, string FullName) :
            this(Id, DateTime.UtcNow, FullName, new DateTime(2000, 1, 1), 22, "", 160)
        {

        }


    }
}
