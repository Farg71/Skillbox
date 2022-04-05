using System;

namespace Skillbox
{
    class ControlStructures
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
                    // Задание 1. Приложение по определению чётного или нечётного числа.
                    case "1":
                        {
                            int n;

                            Console.WriteLine("Введите целое число:");

                            string? value = Console.ReadLine();

                            if (value.Length != 0)
                            {
                                n = int.Parse(value);

                                if (n % 2 == 0)
                                {
                                    Console.WriteLine($"{n} - Чётное число!");
                                }
                                else
                                {
                                    Console.WriteLine($"{n} - Не чётное число!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Число не введено!");
                            }
                        }
                        break;

                    // Задание 2. Программу подсчёта суммы карт в игре «21».
                    case "2":
                        {
                            Console.WriteLine("\n\nПриветствую Вас в игре Blackjack\nСколько у Вас на руках карт?");

                            var value = Console.ReadLine();
                            int cardSumm = 0;

                            if(value.Length !=0)
                            {
                                int cardsNumber = int.Parse(value);
                                int i = 0;

                                while (i < cardsNumber)
                                {
                                    i++;

                                    Console.WriteLine($"Введите значение карты Nr.{i}");
                                    var cardValue = Console.ReadLine();

                                    if (cardValue.Length != 0 && cardValue.Length <= 2)
                                    {

                                        if (cardValue == "j" || cardValue == "q" || cardValue == "k" || cardValue == "t")
                                        {
                                            cardSumm += 10;
                                        }

                                        else if (Convert.ToInt16(cardValue) > 0 && Convert.ToInt16(cardValue) <= 10)
                                        {
                                            cardSumm += Convert.ToInt16(cardValue);
                                        }

                                        else
                                        {
                                            Console.WriteLine("Ведено неправильное значение!");
                                            i--;
                                        }

                                    }

                                    else
                                    {
                                        Console.WriteLine("Ведено неправильное значение!");
                                        i--;
                                    }

                                }

                                Console.WriteLine($"Сумма всех карт: {cardSumm}");

                            }
                            else
                            {
                                Console.WriteLine("Колличество карт не введено!");
                            }
                        }
                        break;

                    // Задание 3. Проверка простого числа.
                    case "3":
                        {
                            int n;
                            bool isPrimeNumber = true;

                            Console.WriteLine("\t\tПроверка простого числа\nВведите целое число:");

                            string? value = Console.ReadLine();

                            if (value.Length != 0)
                            {
                                n = int.Parse(value);

                                for(int i = 2; i < n; i++)
                                {
                                    if(n % i == 0)
                                    {
                                        Console.WriteLine($"Число {n} не является простым! Оно делиться на {i}");
                                        isPrimeNumber = false;
                                    }
                                }

                                if(isPrimeNumber) Console.WriteLine($"Число {n} является простым!");
                            }
                            else
                            {
                                Console.WriteLine("Число не введено!");
                            }

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

