using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillbox
{
    /// <summary>
    /// Описание сотрудника
    /// </summary>
    struct EmployeeOld
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
        public string Txt()
        {
            return $"ID сотрудника: {Id} Дата и время добавления записи: {EntryTime} Ф.И.О.: {FullName} Возраст: {Age} " +
                $"Рост: {Growth} Дата рождения: {DateBirth.ToShortDateString()} Место рождения: {PlaceBirth}";
        }

        public string ToString()
        {
            return Id.ToString() + "#" + EntryTime.ToString("g") + "#" + FullName + "#" + Age.ToString() + "#" + Growth.ToString() + "#" +
                DateBirth.ToString("d") + "#" + PlaceBirth;
        }

        public void Print()
        {
            Console.WriteLine($"Порядковый номер сотрудника: {Id}\n" +
               $"Время добавления записи: {EntryTime}\n" +
               $"Ф.И.О. сотрудника: {FullName}\n" +
               $"Дата рождения сотрудника: {DateBirth}\n" +
               $"Возраст сотрудника: {Age}\n" +
               $"Место рождения сотрудника: {PlaceBirth}\n" +
               $"Рост сотрудника: {Growth}\n\n");
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
        public EmployeeOld(int Id, DateTime EntryTime, string FullName, DateTime DateBirth, int Age, string PlaceBirth, int Growth)
        {
            this.Id = Id;                       // 0
            this.EntryTime = EntryTime;         // 1
            this.FullName = FullName;           // 2
            this.DateBirth = DateBirth;         // 3
            this.Age = Age;                     // 4
            this.PlaceBirth = PlaceBirth;       // 5
            this.Growth = Growth;               // 6

            // 4#03.04.2022 21:20#Сидоров Сидр Сидорович#12#147#01.01.2010#город Незаемо
            // 0        1                   2             3   4      5          6
        }

        public EmployeeOld(int Id, string FullName, DateTime DateBirth, int Age, string PlaceBirth, int Growth) :
            this(Id, DateTime.UtcNow, FullName, DateBirth, Age, PlaceBirth, Growth)
        {

        }

        public EmployeeOld(int Id, string FullName, int Age, DateTime DateBirth, string PlaceBirth ) :
            this(Id, DateTime.UtcNow, FullName, DateBirth, Age, PlaceBirth, 160)
        {

        }

        public EmployeeOld(int Id, string FullName, int Age, DateTime DateBirth) :
            this(Id, DateTime.UtcNow, FullName, DateBirth, Age, "", 160)
        {

        }

        public EmployeeOld(int Id, string FullName, DateTime DateBirth) :
            this(Id, DateTime.UtcNow, FullName, DateBirth, DateTime.UtcNow.Year - DateBirth.Year, "", 160)
        {

        }

        public EmployeeOld(int Id, string FullName) :
            this(Id, DateTime.UtcNow, FullName, new DateTime(2000, 1, 1), 22, "", 160)
        {

        }

        public EmployeeOld(string str)
        {
            string[] record = str.Split('#', StringSplitOptions.RemoveEmptyEntries);

            Id = Convert.ToInt32(record[0]);
            EntryTime = Convert.ToDateTime(record[1]);
            FullName = record[2];
            DateBirth = Convert.ToDateTime(record[5]);
            Age = Convert.ToInt32(record[3]);
            PlaceBirth = record[6];
            Growth = Convert.ToInt32(record[4]);
        }

    }
}
