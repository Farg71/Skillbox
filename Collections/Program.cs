using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Linq;


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
                            //Что нужно сделать
                            
                            //Далее программа предлагает найти владельца по введенному номеру телефона.Пользователь вводит номер телефона
                            //и ему выдаётся ФИО владельца.Если владельца по такому номеру телефона не зарегистрировано, программа выводит
                            //на экран соответствующее сообщение.


                            //Совет
                            //Для того, чтобы находить значение в Dictionary, нужно использовать TryGetValue.



                            //Что оценивается
                            //Программа разделена на логические методы.
                            //Для хранения элементов записной книжки используется Dictionary.

                    case "2":
                        {
                            Dictionary<int, string> phoneBook = DictionaryFilling();






                            Console.WriteLine("Телефонная книга:\n");

                            foreach(var e in phoneBook)
                            {
                                Console.WriteLine($"{e.Key} - {e.Value}");
                            }

                            Console.ReadLine();
                            break;
                        }

                        // Задание 3.Проверка повторов.
                            //Что нужно сделать
                            //Пользователь вводит число. Число сохраняется в HashSet коллекцию.Если такое число уже присутствует в коллекции, то пользователю на экран выводится сообщение, что число уже вводилось ранее. Если числа нет, то появляется сообщение о том, что число успешно сохранено. 



                            //Советы и рекомендации
                            //Для добавление числа в HashSet используйте метод Add.



                            //Что оценивается
                            //В программе в качестве коллекции используется HashSet.
                    case "3":
                        {

                            break;
                        }

                        // Задание 4.Записная книжка.
                            //Что нужно сделать
                            //Программа спрашивает у пользователя данные о контакте:

                            //ФИО
                            //Улица
                            //Номер дома
                            //Номер квартиры
                            //Мобильный телефон
                            //Домашний телефон


                            //С помощью XElement создайте xml файл, в котором есть введенная информация. XML файл должен содержать следующую структуру:

                            //< Person name =”ФИО человека” >
                            //    < Address >
                            //        < Street > Название улицы </ Street >
                            //        < HouseNumber > Номер дома </ HouseNumber >
                            //        < FlatNumber > Номер квартиры </ FlatNumber >
                            //    </ Address >
                            //    < Phones >
                            //        < MobilePhone > 89999999999999 </ MobilePhone >
                            //        < FlatPhone > 123 - 45 - 67 < FlatPhone >
                            //    </ Phones >
                            //</ Person >


                            //Советы и рекомендации
                            //Заполняйте XElement в ходе заполнения данных. Изучите возможности XElement в документации Microsoft.



                            //Что оценивается
                            //Программа создаёт Xml файл, содержащий все данные о контакте.
                    case "4":
                        {

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

