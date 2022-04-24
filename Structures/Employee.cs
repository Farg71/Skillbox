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
        private int id;

        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        private DateTime entryTime;

        /// <summary>
        /// Ф.И.О. сотрудника
        /// </summary>
        private string fullName;

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        private int age;

        /// <summary>
        /// Рост сотрудника
        /// </summary>
        private int growth;

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        private DateTime dateBirth;

        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        private string placeBirth;

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

        public string ToDBString()
        {
            //this.titles[0],15} {this.titles[1],20} {this.titles[2],15} {this.titles[3],15} {this.titles[4],10} " +
            //    $"{this.titles[5],15} {this.titles[6],20}");
            return $"{Id} {EntryTime.ToString("g")} {FullName} {Age} {Growth} {DateBirth.ToString("d")} {PlaceBirth}";
        }


        public string ToFileString()
        {
            return Id.ToString() + "#" + EntryTime.ToString("g") + "#" + FullName + "#" + Age.ToString() + "#" + Growth.ToString() + "#" +
                DateBirth.ToString("d") + "#" + PlaceBirth;
        }

        public string ToFileString(int id)
        {
            return id.ToString() + "#" + EntryTime.ToString("g") + "#" + FullName + "#" + Age.ToString() + "#" + Growth.ToString() + "#" +
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
            //  age = Convert.ToInt32(DateTime.Now.Subtract(dBirth).TotalDays / 365.25);
            this.placeBirth = PlaceBirth;       // 5
            this.growth = Growth;               // 6

            // 4#03.04.2022 21:20#Сидоров Сидр Сидорович#12#147#01.01.2010#город Незаемо
            // 0        1                   2             3   4      5          6
        }

        public Employee(int Id, DateTime EntryTime, string FullName, DateTime DateBirth, string PlaceBirth, int Growth) :
            this(Id, DateTime.UtcNow, FullName, DateBirth, 0, PlaceBirth, Growth)
        {
            age = Convert.ToInt32(DateTime.Now.Subtract(DateBirth).TotalDays / 365.25);
        }

        public Employee(int Id, string str)
        {
            string[] record = str.Split('#', StringSplitOptions.RemoveEmptyEntries);

            id = Id;
            entryTime = Convert.ToDateTime(record[1]);
            fullName = record[2];
            dateBirth = Convert.ToDateTime(record[5]);
            age = Convert.ToInt32(record[3]);
            placeBirth = record[6];
            growth = Convert.ToInt32(record[4]);
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


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime EntryTime
        {
            get { return entryTime; }
            set { entryTime = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value;}
        }

        public int Age
        {
            get { return age; }
            set { age = value;}
        }

        public int Growth
        {
            get { return growth; }
            set { growth = value;}
        }

        public DateTime DateBirth
        {
            get { return dateBirth; }
            set { dateBirth = value; }
        }

        public string PlaceBirth
        {
            get { return placeBirth; }
            set { placeBirth = value;}
        }


        #endregion
    }
}
