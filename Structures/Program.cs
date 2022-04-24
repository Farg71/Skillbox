using System;

using static System.Net.Mime.MediaTypeNames;

namespace Skillbox
{
    class Structures
    {
        //public const string FilePath = @"..\..\..\Staff.txt";

        //public static List<Employee> Employees = new List<Employee>();

        static void Main(string[] args)
        {
            string filePath = @"..\..\..\Staff.txt";

            Repository rep = new Repository(filePath);

            rep.Load();

            //rep.PrintDBToConsole();

            //Console.ReadLine();

            //Console.WriteLine(rep.Count);
            //for(int i = 0; i < rep.Count; i++)
            //{
            //    Console.WriteLine(rep[i].Id);
            //    Console.WriteLine(rep[i].ToFileString());
            //    rep[i].Print();
            //}

            //Console.ReadLine();

            //rep.Add(new Employee(rep.Count + 1, DateTime.Now, "aaa", new DateTime(1971, 01, 01), "Riga", 210));

            //rep.PrintDBToConsole();

            //Console.ReadLine();

            //rep.Save(@"..\..\..\StaffOut.txt");

            //Console.ReadLine();


            //rep.Adding(@"..\..\..\StaffOut.txt", rep[5].ToFileString(rep.Count + 1));


            //bool isCatalogExists = File.Exists(FilePath);

            string taskNumber = "6";

            int recordNumber = 1;

            Console.WriteLine("\t\tСправочник «Сотрудники»\n");

            //if (isCatalogExists)
            //{
            //    ReadingDataFromFile();
            //    recordNumber = Employees.Count;
            //}


            while (taskNumber != " ")
            {
                taskNumber = SelectMode();

                switch (taskNumber)
                {
                    // 1 - Просмотр записи
                    case "1":
                        {
                            Console.WriteLine("Введите номер записи:");

                            int id = Convert.ToInt32(Console.ReadLine());

                            if(id <= rep.Count)
                            {
                                Console.WriteLine(rep[id - 1].ToDBString());
                            }
                            else
                            {
                                Console.WriteLine("Нет такой записи!");
                            }

                            Console.ReadLine();

                            break;
                        }

                    // 2 - Создание записи
                    case "2":
                        {
                            string st = Files.AddNewEmployee(rep.Count);

                            Employee empl = new Employee(st);

                            rep.Add(empl);

                            break;
                        }

                    // 3 - Удаление записи

                                                            // Переделать!!!
                    case "3":
                        {
                            Console.WriteLine("Введите номер записи, которую надо удалить:");

                            int id = Convert.ToInt32(Console.ReadLine());

                            rep.Delete(id);

                            break;
                        }

                    // 4 - Редактирование записи
                    // ????? Убрать пустую строку!!!!

                    case "4":
                        {
                            Console.WriteLine("Введите номер записи, которую надо отредактировать:");

                            int id = Convert.ToInt32(Console.ReadLine());

                            string st = Files.AddNewEmployee(id);

                            rep.Edit(id, st);

                            //rep.Save(@"..\..\..\StaffOut.txt");

                            break;
                        }

                    // 5 - Загрузка записей в выбранном диапазоне дат
                    case "5":
                        {
                            Console.WriteLine("Введите начальную дату:");
                            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                            Console.WriteLine("Введите конечную дату:");
                            DateTime finishDate = Convert.ToDateTime(Console.ReadLine());

                            //LoadRecordsInDateRange(startDate, finishDate);

                            Console.WriteLine();

                            foreach(var e in rep.employees)
                            {
                                Console.WriteLine(e.DateBirth);
                            }

                            Console.ReadLine();
                            break;
                        }

                    // 6 - Сортировка по возрастанию даты
                    case "6":
                        {
                            SorttingAscending();

                            break;
                        }

                    // 7 - Сортировка по убыванию даты
                    case "7":
                        {
                            DateTime d1 = new DateTime(2010, 02, 15);
                            DateTime d2 = new DateTime(2010, 02, 16);


                            if (d1 < d2)
                            {
                                Console.WriteLine(d1);
                            }
                            else
                            {
                                Console.WriteLine(d2);
                            }

                            Console.ReadLine();
                            break;
                        }

                    //"8 - Сохранение данных в файл\n" +
                    case "8":
                        {
                            rep.Save(@"..\..\..\StaffOut.txt");

                            break;
                        }

                    default:

                        Console.WriteLine("Удачного дня!");

                        //break;
                        return;     // Выход из цикла
                }
            }
        }

        /// <summary>
        /// Список сотрудников в массив строк
        /// </summary>
        /// <param name="numberRecords">колличество сотрудников</param>
        /// <returns>массив строк</returns>
        //private static string[] ListToArray(int numberRecords)
        //{
        //    string[] lines = new string[numberRecords];

        //    for(int i = 0; i < numberRecords; i++)
        //    {
        //        Employee emp = Employees[i];

        //        lines[i] = emp.ToString();
        //    }

        //    return lines;
        //}

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

        ///// <summary>
        ///// Чтение данных из файла в список Employees
        ///// </summary>
        //private static void ReadingDataFromFile()
        //{
        //    Employees.Clear();

        //    string[] records = File.ReadAllLines(FilePath);

        //    foreach (string employee in records)
        //    {
        //        if (employee != "")
        //        {
        //            Employee empl = new Employee(employee);

        //            Employees.Add(empl);
        //        }
        //    }
        //}

        /// <summary>
        /// Загрузка записей в выбранном диапазоне дат.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        //private static async void LoadRecordsInDateRange(DateTime startDate, DateTime finishDate)
        //{
        //    Employees.Clear();

        //    using(StreamReader reader = new StreamReader(FilePath))
        //    {
        //        string? line;

        //        while((line = await reader.ReadLineAsync()) != null)
        //        {
        //            if (line != "")
        //            {
        //                Employee emp = new Employee(line);

        //                if (emp.DateBirth >= startDate && emp.DateBirth <= finishDate)
        //                {
        //                    Employees.Add(emp);
        //                }
        //            }
        //        }
        //    }
        //}

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
            //Repository rep = new Repository(FilePath);

            //foreach (var t in rep.titles)
            //{
            //    Console.WriteLine(t);
            //}

            //rep = new Repository(
            //    new Employee("1#20.12.2021 0:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва"),
            //    new Employee("2#15.12.2021 3:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск"),
            //    new Employee("3#03.04.2022 21:18#Петров Пётр Петрович#110#210#01.01.1970#город Тьмутаракань"),
            //    new Employee("4#03.04.2022 21:20#Сидоров Сидр Сидорович#12#147#01.02.2010#город Незаемо"),
            //    new Employee("5#03.04.2022 21:18#Петров Пётр Петрович#110#210#15.01.1999#город Тьмутаракань"),
            //    new Employee("6#03.04.2022 21:20#Сидоров Сидр Сидорович#12#147#01.01.2010#город Незаемо")
            //    );


            //Console.WriteLine(rep.employees[0].ToDBString());
            //Console.WriteLine();

            //Console.WriteLine(rep[0].ToDBString());
            //Console.WriteLine();

            //rep[0] = new Employee("1#20.12.2021 0:12#Иванов Иван Петрович#25#176#05.05.1992#город Москва");

            //Console.WriteLine(rep[0].ToDBString());
            //Console.WriteLine();

            //Console.WriteLine(rep["0"]);
            //Console.WriteLine();

            //rep.PrintDBToConsole();




            //Employee emp = new Employee(1, DateTime.Now, "Андреев Андрей Андреевич", new DateTime(1971, 11, 20), "Riga", 178);

            //Console.WriteLine(emp.ToDBString());
            //Console.WriteLine();
            //Console.WriteLine(emp.Txt());
            //Console.WriteLine();
            //emp.Print();





            Console.ReadLine();
        }

        /// <summary>
        /// Нумерация (Id) по порядку
        /// </summary>
        //private static void ConsecutiveNumbering()
        //{
        //    for (int i = 0; i < Employees.Count; i++)
        //    {
        //        Employee emp = Employees[i];

        //        emp.Id = i + 1;

        //        Employees[i] = emp;
        //    }

        //}
    }
}

