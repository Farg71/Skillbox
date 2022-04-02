//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


//Импорт сторонних пространст имён
using System;

/// <summary>
/// Пространство имён
/// Создание собственной библиотеки
/// </summary>
namespace MyHelloWorldConsoleApp
{
    class Program
    {
        /// <summary>
        /// Точка входа
        /// Статический метод, не возвращает значение
        /// </summary>
        /// <param name="args">строковый массив параметров</param>
        static void Main(string[] args)
        {
            string? taskNumber = "1";

            while (taskNumber == "1" || taskNumber == "2")
            {
                Console.Write("Введите номер домашнего задания ('1' или '2'; другие - завершение проверки): ");

                //ConsoleKeyInfo taskNumber = Console.ReadKey();
                //Console.WriteLine(taskNumber.ToString());

                taskNumber = Console.ReadLine();
                //string taskNumber = "1";

                switch (taskNumber)
                {
                    case "1":
                        {
                            Console.WriteLine("Hello World!!!");

                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                        }
                        break;

                    case "2":
                        {
                            Console.Write("Hello ");
                            Console.Write("World");
                            Console.Write("!!!");

                            string? readLine = Console.ReadLine();
                        }
                        break;

                    default:

                        Console.WriteLine("Нет такого задания!! :)");
                        Console.ReadLine();

                        break;
                }
            }

        }
    }
}