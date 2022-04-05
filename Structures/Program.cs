using System;

namespace Skillbox
{
    class Structures
    {
        static void Main(string[] args)
        {
            string? taskNumber = "1";

            string filePath = @"..\..\..\Staff.txt";
            bool isCatalogExists = File.Exists(filePath);
            int lastRecord = 1;


            Console.WriteLine("\t\tСправочник «Сотрудники»\n");

            while (taskNumber == "1" || taskNumber == "2")
            {

                Console.Clear();
                Console.Write("Выберите режим работы (1 -вывести данные на экран, 2 - заполнить данные и добавить в справочник, " +
                    "другие - завершение работы):\n");

                taskNumber = Console.ReadLine();
                Console.WriteLine("\n\n");

                switch (taskNumber)
                {
                    case "1":
                        {
                            //if (!isCatalogExists)
                            //{
                            //    Console.WriteLine("Справочник отсутствует!");
                            //}
                            //else
                            //{
                            //    string[] records = File.ReadAllLines(filePath);

                            //    foreach (string employee in records)
                            //    {
                            //        string[] record = employee.Split('#');
                            //        foreach (string cell in record)
                            //        {
                            //            Console.Write(cell + "\t");
                            //            //Console.Write($"{cell,30}");
                            //        }

                            //        Console.WriteLine();
                            //    }
                            //}
                        }
                        break;

                    case "2":
                        {
                            //if (!isCatalogExists)
                            //{
                            //    lastRecord = 1;
                            //}
                            //else
                            //{
                            //    string[] records = File.ReadAllLines(filePath);

                            //    lastRecord = int.Parse(records[records.Length - 1].Split('#')[0]);
                            //}

                            //AddNewEmployees(filePath, lastRecord);

                        }
                        break;

                    default:

                        Console.WriteLine("Удачного дня!");

                        break;
                }

                Console.ReadLine();
            }
        }
    }
}