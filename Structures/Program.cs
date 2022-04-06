using System;

namespace Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Разработать ежедневник.
            /// В ежедневнике реализовать возможность 
            /// - создания
            /// - удаления
            /// - реактирования 
            /// записей
            /// 
            /// В отдельной записи должно быть не менее пяти полей
            /// 
            /// Реализовать возможность 
            /// - Загрузки даннах из файла
            /// - Выгрузки даннах в файл
            /// - Добавления данных в текущий ежедневник из выбранного файла
            /// - Импорт записей по выбранному диапазону дат
            /// - Упорядочивания записей ежедневника по выбранному полю

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
                        }
                        break;

                    case "2":
                        {
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

