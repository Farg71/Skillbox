using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string? taskNumber = "1";

            while (taskNumber == "1" || taskNumber == "2" || taskNumber == "3")
            {
                Console.Clear();
                Console.Write("Введите номер домашнего задания ('1', '2' или '3'; другие - завершение проверки): ");

                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    // Задание 1.
                    case "1":
                        {
                        }
                        break;

                    // Задание 2.
                    case "2":
                        {
                        }
                        break;

                    // Задание 3.
                    case "3":
                        {
                        }
                        break;

                    default:

                        Console.WriteLine("Нет такого задания!! :)");

                        break;
                }

                Console.ReadLine();

            }
        }
    }
}

