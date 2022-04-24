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
                            //SorttingAscending();

                            break;
                        }

                    // 7 - Сортировка по убыванию даты
                    case "7":
                        {

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

        }

    }
}

