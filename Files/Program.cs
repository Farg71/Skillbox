using System;
using System.Text.RegularExpressions;

using static System.Net.Mime.MediaTypeNames;

namespace Skillbox
{
    public class Files
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
                            if (!isCatalogExists)
                            {
                                Console.WriteLine("Справочник отсутствует!");
                            }
                            else
                            {
                                string[] records = File.ReadAllLines(filePath);

                                foreach (string employee in records)
                                {
                                    string[] record = employee.Split('#');
                                    foreach(string cell in record )
                                    {
                                        Console.Write(cell + "\t");
                                        //Console.Write($"{cell,30}");
                                    }

                                    Console.WriteLine();
                                }
                            }
                        }
                        break;

                    case "2":
                        {
                            if (!isCatalogExists)
                            {
                                lastRecord = 1;
                            }
                            else
                            {
                                string[] records = File.ReadAllLines(filePath);

                                lastRecord = int.Parse(records[records.Length - 1].Split('#')[0]);
                            }

                            AddNewEmployees(filePath, lastRecord);
                        }
                        break;

                    default:

                        Console.WriteLine("Удачного дня!");

                        break;
                }

                Console.ReadLine();
            }

            Console.ReadLine();
        }

        public static void AddNewEmployees(string filePath, int lastRecord)
        {
            Console.WriteLine("Сколько хотите добавить сотрудников?");

            int employeesNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < employeesNumber; i++)
            {
                string txt = AddNewEmployee(lastRecord + i);

                File.AppendAllText(filePath, txt);

            }
        }

        public static string AddNewEmployee(int recordNumber)
        {
            string entryTime = DateTime.Now.ToString("g");

            Console.WriteLine("\nВведите Ф.И.О. сотрудника");
            string fullName = Console.ReadLine();

            //Console.WriteLine("\nВведите возраст сотрудника");
            //string age = Console.ReadLine();

            Console.WriteLine("\nВведите рост сотрудника");
            string growth = Console.ReadLine();

            Console.WriteLine("\nВведите дату рождения сотрудника");
            string dateBirth = Console.ReadLine();

            DateTime dBirth = Convert.ToDateTime(dateBirth);

            string age = Convert.ToInt32(DateTime.Now.Subtract(dBirth).TotalDays / 365.25).ToString();

            Console.WriteLine("\nВведите место рождения сотрудника");
            string placeBirth = Console.ReadLine();

            int newRecord = recordNumber + 1;

            return newRecord.ToString() + "#" + entryTime + "#" + fullName + "#" + age + "#" + growth + "#" + dateBirth + "#" + placeBirth;
        }
    }
}