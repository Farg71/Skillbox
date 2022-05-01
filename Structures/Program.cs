using System;
using System.Collections.Generic;


namespace Skillbox
{
    class Structures
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\..\Staff.txt";

            Repository rep = new Repository(filePath);

            rep.Load();

            string taskNumber = "1";

            Console.WriteLine("\t\tСправочник «Сотрудники»\n");

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
                    case "3":
                        {
                            Console.WriteLine("Введите номер записи, которую надо удалить:");

                            int id = Convert.ToInt32(Console.ReadLine());

                            rep.Delete(id);

                            break;
                        }

                    // 4 - Редактирование записи
                    case "4":
                        {
                            Console.WriteLine("Введите номер записи, которую надо отредактировать:");

                            int id = Convert.ToInt32(Console.ReadLine());

                            string st = Files.AddNewEmployee(id - 1);

                            rep.employees[id - 1] = new Employee(id, st);

                            break;
                        }

                    // 5 - Загрузка записей в выбранном диапазоне дат
                    case "5":
                        {
                            Console.WriteLine("Введите начальную дату:");
                            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                            Console.WriteLine("Введите конечную дату:");
                            DateTime finishDate = Convert.ToDateTime(Console.ReadLine());

                            for(int i = 0; i < rep.Count; i++)
                            {
                                if (rep[i].DateBirth > startDate && rep[i].DateBirth < finishDate)
                                {
                                    Console.WriteLine(rep[i].ToDBString());
                                }
                            }

                            Console.ReadLine();
                            break;
                        }

                    // 6 - Сортировка по возрастанию даты
                    case "6":
                        {
                            rep.SortDateBirthAscending();

                            break;
                        }

                    // 7 - Сортировка по убыванию даты
                    case "7":
                        {
                            rep.SortDateBirthDescending();

                            break;
                        }

                    // 8 - Сохранение данных в файл
                    case "8":
                        {
                            rep.Save(@"..\..\..\StaffOut.txt");

                            break;
                        }

                    // Удачного дня!
                    default:
                        {
                            Console.WriteLine("Удачного дня!");

                            //break;
                            return;     // Выход из цикла
                        }
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

            return Console.ReadLine();
        }

    }
}

