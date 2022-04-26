using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Linq;

using MyLibrary;
using System.Xml.Serialization;
using System.Data;

namespace Skillbox
{
    class Collections
    {
        static void Main(string[] args)
        {
            string taskNumber = "1";

            while (taskNumber != " ")
            {
                taskNumber = SelectMode();

                switch (taskNumber)
                {
                    // Задание 1. Работа с List<>
                    case "1":
                        {
                            List<int> intsList = ListFilling();

                            ListScreenOutput(intsList);

                            intsList = ListDeletions(intsList);

                            ListScreenOutput(intsList);

                            break;
                        }

                    // Задание 2.Телефонная книга.
                    case "2":
                        {
                            Dictionary<int, string> phoneBook = DictionaryFilling();

                            DisplayOutput(phoneBook);

                            OwnerSearch(phoneBook);

                            break;
                        }

                    // Задание 3.Проверка повторов.
                    case "3":
                        {
                            HashSet<int> numbers = HashSetCollection();

                            Console.WriteLine("\tHashSet коллекция:\n");

                            foreach (int number in numbers)
                            {
                                Console.WriteLine(number);
                            }

                            Console.ReadLine();
                            break;
                        }

                    // Задание 4.Записная книжка.
                    case "4":
                        {
                            NotebookList notebook = CreateNotebook();

                            XmlSerialize(@"..\..\..\Notebook1.xml", notebook);

                            notebook = XmlDeserialize(@"..\..\..\Notebook1.xml");

                            foreach (var e in notebook.Notebook)
                            {
                                Console.WriteLine(e.Name);
                            }

                            Console.ReadLine();

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

        /// <summary>
        /// Ввод данных в записную книжку
        /// </summary>
        /// <returns></returns>
        private static NotebookList CreateNotebook()
        {
            NotebookList notebook = new NotebookList();
            List<Person> notebookList = new List<Person>();

            for (int i = 0; i < 2; i++)
            {
                Person person = new Person();
                Address address = new Address();
                Phones phones = new Phones();

                Console.WriteLine("ФИО человека");
                person.Name = Console.ReadLine();

                Console.WriteLine("Название улицы");
                address.Street = Console.ReadLine();

                Console.WriteLine("Номер дома");
                address.HouseNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Номер квартиры");
                address.FlatNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Мобильник");
                phones.MobilePhone = int.Parse(Console.ReadLine());

                Console.WriteLine("Телефон");
                phones.FlatPhone = int.Parse(Console.ReadLine());

                person.Address = address;
                person.Phones = phones;

                notebookList.Add(person);
            }

            notebook.Notebook = notebookList;

            return notebook;
        }

        /// <summary>
        /// Серилизация Записной книжки
        /// </summary>
        /// <param name="filePath"></param>
        public static void XmlSerialize(string filePath, NotebookList notebook)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NotebookList));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, notebook);

                Console.WriteLine("Object has been serialized");
            }
        }

        /// <summary>
        /// Десерилизация Записной книжки
        /// </summary>
        /// <param name="filePath"></param>
        public static NotebookList XmlDeserialize(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NotebookList));
            NotebookList notebook = new NotebookList();

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                notebook = xmlSerializer.Deserialize(fs) as NotebookList;
            }

            return notebook;
        }

        /// <summary>
        /// HashSet коллекция
        /// </summary>
        /// <returns></returns>
        private static HashSet<int> HashSetCollection()
        {
            Console.Clear();
            Console.WriteLine("\tИспользование коллекции HashSet:\n");
            HashSet<int> numbers = new HashSet<int>();

            while (true)
            {
                Console.WriteLine("\nВведите число:");
                string numString = Console.ReadLine();

                if (numString == "") break;

                int number = int.Parse(numString);

                if (numbers.Contains(number))
                {
                    Console.WriteLine("\nЕсть такое число!");
                }
                else
                {
                    numbers.Add(number);
                    Console.WriteLine("Число успешно сохранено!");
                }
            }

            return numbers;
        }

        /// <summary>
        /// Поиск пользователя по номеру телефона
        /// </summary>
        /// <param name="phoneBook"></param>
        private static void OwnerSearch(Dictionary<int, string> phoneBook)
        {
            Console.Clear();
            Console.WriteLine("\tПоиск пользователя по номеру телефона:\n");

            while (true)
            {
                Console.WriteLine("\nВведите номер телефона:");
                string telString = Console.ReadLine();

                if (telString == "") break;

                int telNumber = int.Parse(telString);
                string name;

                if (!phoneBook.TryGetValue(telNumber, out name))
                {
                    Console.WriteLine("\nТакого номера нет!");
                }
                else
                {
                    Console.WriteLine($"Пользователь номера {telNumber} - {name}");
                }

            }
        }

        /// <summary>
        /// Вывод телефонной книги на консоль
        /// </summary>
        /// <param name="phoneBook"></param>
        private static void DisplayOutput(Dictionary<int, string> phoneBook)
        {
            Console.WriteLine("Телефонная книга:\n");

            foreach (var e in phoneBook)
            {
                Console.WriteLine($"{e.Key} - {e.Value}");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Ввод номера телефонов и ФИО их владельцев
        /// </summary>
        /// <returns>Словарь с данными</returns>
        private static Dictionary<int, string> DictionaryFilling()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            Console.Clear();
            Console.WriteLine("\t\tТелефонная книга:\n");
            Console.WriteLine();

            while(true)
            {
                Console.WriteLine("\nВведите номер телефона:");
                string telString = Console.ReadLine();

                if (telString == "") break;

                int telNumber = int.Parse(telString);

                if (!dict.ContainsKey(telNumber))
                {
                    Console.WriteLine("\nВведите имя:");

                    string? name = Console.ReadLine();

                    dict.Add(telNumber, name);
                }
                else
                {
                    Console.WriteLine("\nТакой номер уже вводили!");
                }
            }

            return dict;
        }

        /// <summary>
        /// Удаление из листа числа, которые больше 25, но меньше 50.
        /// Два варианта
        /// </summary>
        /// <param name="intsList"></param>
        /// <returns></returns>
        private static List<int> ListDeletions(List<int> intsList)
        {
            //intsList.RemoveAll(n => n > 25 & n < 50);

            intsList.RemoveAll(DellRange);

            return intsList;
        }

        private static bool DellRange(int n)
        {
            return n > 25 & n < 50;
        }

        /// <summary>
        /// Вывод списка и его ёмеости на консоль
        /// </summary>
        /// <param name="intsList"></param>
        private static void ListScreenOutput(List<int> intsList)
        {
            foreach (int i in intsList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            Console.WriteLine($"Ёмеость List: {intsList.Count}");
            Console.ReadLine();
        }

        /// <summary>
        /// Заполнение списка случайными величинами
        /// </summary>
        /// <returns></returns>
        private static List<int> ListFilling()
        {
            Random random = new Random();
            List<int> list = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(random.Next(0, 101));
            }

            return list;
        }

        private static string SelectMode()
        {
            Console.Clear();
            Console.Write("\t\tВыберите режим работы:\n\n" +
                "1 - Работа с листом\n" +
                "2 - Телефонная книга\n" +
                "3 - Проверка повторов\n" +
                "4 - Записная книжка\n" +
                "другие - завершение работы:\n\n");

            return Console.ReadLine();
        }
    }
}

