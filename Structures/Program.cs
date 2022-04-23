using System;

namespace Skillbox
{
    class Structures
    {
        //public const string FilePath = @"E:\VS Projects\Skillbox\Files\Staff.txt";
        public const string FilePath = @"..\..\..\Staff.txt";


        public static List<Employee> Employees = new List<Employee>();

        static void Main(string[] args)
        {
            bool isCatalogExists = File.Exists(FilePath);

            string taskNumber = "";

            int recordNumber = 1;

            Console.WriteLine("\t\tСправочник «Сотрудники»\n");

            if (isCatalogExists)
            {
                ReadingDataFromFile();
                recordNumber = Employees.Count;
            }


            //CreateEntry();

            //DeletingEntry(id);
            //DeletingEntry(fullName);

            //EditingEntry(id);
            //EditingEntry(fullName);

            //DateTime startDate = new DateTime(2000, 1, 1);
            //DateTime finishDate = DateTime.UtcNow;

            //LoadRecordsInDateRange(startDate, finishDate);

            //SorttingAscending();
            //SorttingDescending();

            //ReadingDataFromFile();


            while (taskNumber != " ")
            {
                taskNumber = SelectMode();

                switch (taskNumber)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите номер записи:");

                            int id = Convert.ToInt32(Console.ReadLine());

                            if(id <= Employees.Count)
                            {
                                ViewingRecord(id);
                            }
                            else
                            {
                                Console.WriteLine("Нет такой записи!");
                            }

                            break;
                        }

                    case "2":
                        {
                            //"2 - Создание записи\n" +

                            Files.AddNewEmployees(FilePath, Employees.Count);

                            break;
                        }

                    case "3":
                        {
                            //                 "3 - Удаление записи\n" +

                            break;
                        }

                    case "4":
                        {
                            //"4 - Редактирование записи\n" +

                            break;
                        }

                    case "5":
                        {
                            //"5 - Загрузка записей в выбранном диапазоне дат\n" +

                            break;
                        }

                    case "6":
                        {
                            //"6 - Сортировка по возрастанию даты\n" +

                            break;
                        }

                    case "7":
                        {
                            //"7 - Сортировка по убыванию даты\n" +

                            break;
                        }

                    case "8":
                        {
                            //"8 - Сохранение данных в файл\n" +

                            break;
                        }


                    default:

                        Console.WriteLine("Удачного дня!");

                        //break;
                        return;     // Выход из цикла
                }

                Console.ReadLine();
            }
        }

        private static string SelectMode()
        {
            Console.Clear();
            Console.Write("\t\tВыберите режим работы:\n\n" +
                "1 - Просмотр записи\n" +
                "2 - Создание записи\n" +
                "3 - Удаление записи\n" +
                "4 - Редактирование записи\n" +
                "5 - Загрузка записей в выбранном диапазоне дат\n" +
                "6 - Сортировка по возрастанию даты\n" +
                "7 - Сортировка по убыванию даты\n" +
                "8 - Сохранение данных в файл\n" +
                "другие - завершение работы:\n\n");

            string taskNumber = Console.ReadLine();
           
            return taskNumber;
        }

        /// <summary>
        /// Чтение данных из файла в список Employees
        /// </summary>
        private static void ReadingDataFromFile()
        {
            Employees.Clear();

            string[] records = File.ReadAllLines(FilePath);

            foreach (string employee in records)
            {
                //Employee empl = new Employee();

                string[] record = employee.Split('#');

                Employee empl = new Employee(Convert.ToInt32(record[0]), Convert.ToDateTime(record[1]),
                    record[2], Convert.ToDateTime(record[5]), Convert.ToInt32(record[3]), record[6], Convert.ToInt32(record[4]));

                Employees.Add(empl);
            }
        }




        /// <summary>
        /// Загрузка записей в выбранном диапазоне дат.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        private static void LoadRecordsInDateRange(DateTime startDate, DateTime finishDate)
        {
            //  С диска загружаются записи в выбранном диапазоне дат.

        }

        /// <summary>
        /// Сортировка записей по убываниюю
        /// </summary>
        private static void SorttingDescending()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Сортировка записей по возрастаниюю
        /// </summary>
        private static void SorttingAscending()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Редактирование записи.
        /// </summary>
        /// <param name="fullName">Поное имя работника</param>
        private static void EditingEntry(string fullName)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Редактирование записи.
        /// </summary>
        /// <param name="id">Номер записи</param>
        private static void EditingEntry(int id)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="fullName">Поное имя работника</param>
        private static void DeletingEntry(string fullName)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="id">Номер записи</param>
        private static void DeletingEntry(int id)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Создание записи.
        /// </summary>
        private static void CreateEntry()
        {

            //throw new NotImplementedException();
        }

        /// <summary>
        /// Просмотр записи
        /// </summary>
        /// <param name="id">Номер записи</param>
        private static void ViewingRecord(int id)
        {
            Print(Employees[id - 1]);
        }

        /// <summary>
        /// Печать одного сотрудника
        /// </summary>
        /// <param name="emp">Экземпляр класса "Сотрудник"</param>
        private static void Print(Employee emp)
        {
            Console.WriteLine($"Порядковый номер сотрудника: {emp.Id}\n" +
                           $"Время добавления записи: {emp.EntryTime}\n" +
                           $"Ф.И.О. сотрудника: {emp.FullName}\n" +
                           $"Дата рождения сотрудника: {emp.DateBirth}\n" +
                           $"Возраст сотрудника: {emp.Age}\n" +
                           $"Место рождения сотрудника: {emp.PlaceBirth}\n" +
                           $"Рост сотрудника: {emp.Growth}\n\n");
        }
    }
}

