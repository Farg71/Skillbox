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
    struct Employee
    {
        #region Поля

        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int id;

        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime entryTime;

        /// <summary>
        /// Ф.И.О. сотрудника
        /// </summary>
        public string fullName;

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int age;

        /// <summary>
        /// Рост сотрудника
        /// </summary>
        public int growth;

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime dateBirth;

        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        public string placeBirth;

        #endregion

        #region Методы

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

        #endregion

        #region Конструкторы

        public Employee(int Id, DateTime EntryTime, string FullName, DateTime DateBirth, int Age, string PlaceBirth, int Growth)
        {
            this.id = Id;                       // 0
            this.entryTime = EntryTime;         // 1
            this.fullName = FullName;           // 2
            this.dateBirth = DateBirth;         // 3
            this.age = Age;                     // 4
            this.placeBirth = PlaceBirth;       // 5
            this.growth = Growth;               // 6

            // 4#03.04.2022 21:20#Сидоров Сидр Сидорович#12#147#01.01.2010#город Незаемо
            // 0        1                   2             3   4      5          6
        }

        public Employee(string str)
        {
            string[] record = str.Split('#', StringSplitOptions.RemoveEmptyEntries);

            id = Convert.ToInt32(record[0]);
            entryTime = Convert.ToDateTime(record[1]);
            fullName = record[2];
            dateBirth = Convert.ToDateTime(record[5]);
            age = Convert.ToInt32(record[3]);
            placeBirth = record[6];
            growth = Convert.ToInt32(record[4]);
        }

        #endregion

        #region Свойства



        #endregion
    }
}
