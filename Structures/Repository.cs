using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillbox
{
    internal class Repository
    {
        #region Поля

        /// <summary>
        /// База данных сотрудников
        /// </summary>
        public Employee[] employees;

        private string path;

        int index;
        public string[] titles;    // зоголовки полей сотрудника

        #endregion

        #region Конструкторы

        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.titles = new string[7]
            {
                "ID сотрудника",
                "Дата и время добавления записи",
                "Ф.И.О.",
                "Возраст",
                "Рост",
                "Дата рождения",
                "Место рождения"

            };
            this.employees = new Employee[2];
        }

        public Repository(params Employee[] employees)
        {
            this.employees = employees;  // ?? throw new ArgumentNullException(nameof(employees));
        }

        #endregion

        #region Методы


        /// <summary>
        /// метод для увеличения пространства хранения
        /// </summary>
        /// <param name="flag"></param>
        private void Resize(bool flag)
        {
            if(flag)
            {
                Array.Resize(ref this.employees, this.employees.Length + 10);    // добавляет по 10 элементов (можно и умножать
            }
        }

        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="newEmp"></param>
        public void Add(Employee newEmp)
        {
            this.Resize(index >= this.employees.Length);
            this.employees[index] = newEmp;
            this.index++;
        }

        /// <summary>
        /// Теоретически: удаление сотрудника из БД
        /// </summary>
        /// <param name="indexString">индекс сотрудника</param>
        public void Delete(int indexString)
        {
            if(indexString < index) this.employees[indexString - 1] = this.employees[index];
            this.index--;
        }

        /// <summary>
        /// Загрузка списка сотрудников из файла
        /// </summary>
        public void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    //string[] args = sr.ReadLine().Split('#');
                    string line = sr.ReadLine();

                    Add(new Employee(line));
                }
            }
        }

        /// <summary>
        /// Перезапись файла
        /// </summary>
        /// <param name="pathOut">Путь выходного файла</param>
        public async void Save(string pathOut)
        {
            using (StreamWriter sw = new StreamWriter(pathOut, false))
            {
                for(int i = 0; i < this.Count; i++)
                {
                    await sw.WriteLineAsync(this.employees[i].ToFileString());
                }
            }
        }

        /// <summary>
        /// Редактирование данных о сотруднике
        /// </summary>
        /// <param name="indexString"></param>
        /// <param name="line"></param>
        public void Edit(int indexString, string line)
        {
            this[indexString - 1] = new Employee(indexString, line);
        }

        /// <summary>
        /// Добавление записей к существующему файлу
        /// </summary>
        /// <param name="pathOut">Путь выходного файла</param>
        /// <param name="line">Строка сотрудника</param>
        public async void Adding(string pathOut, string line)
        {
            using (var sw = new StreamWriter(pathOut, true))
            {
                await sw.WriteLineAsync(line);
            }
        }

        public void PrintDBToConsole()
        {
            Console.WriteLine($"{this.titles[0],15} {this.titles[1],30} {this.titles[2],15} {this.titles[3],15} {this.titles[4],10} " +
                $"{this.titles[5],15} {this.titles[6],20}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.employees[i].ToDBString());
            }
        }

        #endregion

        #region Индексаторы

        public Employee this[int index]
        {
            get { return employees[index]; }
            set { employees[index] = value; }
        }

        /// <summary>
        /// Выводит данные о сотруднике в виде строки
        /// </summary>
        /// <param name="ind">индекс массива в string</param>
        /// <returns></returns>
        public string this[string index]
        {
            get { return this[Convert.ToInt32(index)].ToDBString(); }
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Колличество сотрудников
        /// </summary>
        public int Count { get { return this.index; } }

        #endregion


    }
}
