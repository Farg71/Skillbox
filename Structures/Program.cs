using System;

using static System.Net.Mime.MediaTypeNames;

namespace Skillbox
{
    class Structures
    {
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


            //DateTime startDate = new DateTime(2000, 1, 1);
            //DateTime finishDate = DateTime.UtcNow;

            //LoadRecordsInDateRange(startDate, finishDate);

            //SorttingAscending();
            //SorttingDescending();


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

                            if(id <= Employees.Count)
                            {
                                Employee employee = Employees[id -1];

                                employee.Print();
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
                            string st = Files.AddNewEmployee(Employees.Count);

                            Employee empl = new Employee(st);

                            Employees.Add(empl);

                            File.AppendAllText(FilePath, st);

                            break;
                        }

                    // 3 - Удаление записи
                    case "3":
                        {
                            Console.WriteLine("Введите номер записи, которую надо удалить:");

                            int id = Convert.ToInt32(Console.ReadLine());

                            Employees.RemoveAt(id - 1);

                            ConsecutiveNumbering();

                            string[] lines = ListToArray(Employees.Count);

                            File.WriteAllLines(FilePath, lines);

                            break;
                        }

                    // 4 - Редактирование записи
                    case "4":
                        {
                            Console.WriteLine("Введите номер записи, которую надо отредактировать:");

                            int id = Convert.ToInt32(Console.ReadLine());

                            Employees.RemoveAt(id - 1);

                            string st = Files.AddNewEmployee(Employees.Count);

                            Employee empl = new Employee(st);

                            Employees.Add(empl);

                            ConsecutiveNumbering();

                            string[] lines = ListToArray(Employees.Count);

                            File.WriteAllLines(FilePath, lines);

                            //File.AppendAllText(FilePath, st);


                            //EditingEntry(id);

                            //string[] lines = ListToArray(Employees.Count);

                            //File.WriteAllLines(FilePath, lines);

                            break;
                        }

                    // 5 - Загрузка записей в выбранном диапазоне дат
                    case "5":
                        {
                            Console.WriteLine("Введите начальную дату:");
                            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                            Console.WriteLine("Введите конечную дату:");
                            DateTime finishDate = Convert.ToDateTime(Console.ReadLine());

                            LoadRecordsInDateRange(startDate, finishDate);

                            Console.WriteLine();

                            foreach(var emp in Employees)
                            {
                                Console.WriteLine(emp.DateBirth);
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
                            string[] lines = ListToArray(Employees.Count);

                            File.WriteAllLines(FilePath, lines);

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
        private static string[] ListToArray(int numberRecords)
        {
            string[] lines = new string[numberRecords];

            for(int i = 0; i < numberRecords; i++)
            {
                Employee emp = Employees[i];

                lines[i] = emp.ToString();
            }

            return lines;
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
                if (employee != "")
                {
                    Employee empl = new Employee(employee);

                    Employees.Add(empl);
                }
            }
        }

        /// <summary>
        /// Загрузка записей в выбранном диапазоне дат.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        private static async void LoadRecordsInDateRange(DateTime startDate, DateTime finishDate)
        {
            Employees.Clear();

            using(StreamReader reader = new StreamReader(FilePath))
            {
                string? line;

                while((line = await reader.ReadLineAsync()) != null)
                {
                    if (line != "")
                    {
                        Employee emp = new Employee(line);

                        if (emp.DateBirth >= startDate && emp.DateBirth <= finishDate)
                        {
                            Employees.Add(emp);
                        }
                    }
                }
            }
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


            //Dictionary<int, Employee> employesDict = new Dictionary<int, Employee>();

            //for (int i = 0; i < Employees.Count; i++)
            //{
            //    employesDict.Add(i + 1, Employees[i]);
            //}

            //foreach (var dic in employesDict)
            //{
            //    Console.WriteLine($"{dic.Key}  -  {dic.Value.Id}  -  {dic.Value.DateBirth}");
            //}

            //Console.ReadLine();



            //for (int key = 1; key < employesDict.Count - 2; key++)
            //{
            //    Employee empMin = employesDict[key];

            //    for (int i = key; i < employesDict.Count - 1; i++)
            //    {
            //        if (empMin.DateBirth > employesDict[i + 1].DateBirth)
            //        {
            //            employesDict[i] = employesDict[i + 1];
            //            employesDict[i + 1] = empMin;
            //            empMin = employesDict[i];
            //        }
            //    }
            //}

            //foreach(var dic in employesDict)
            //{
            //    Console.WriteLine($"{dic.Key}  -  {dic.Value.Id}  -  {dic.Value.DateBirth}");
            //}

            Console.ReadLine();
        }

        /// <summary>
        /// Нумерация (Id) по порядку
        /// </summary>
        private static void ConsecutiveNumbering()
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                Employee emp = Employees[i];

                emp.Id = i + 1;

                Employees[i] = emp;
            }

        }
    }
}

