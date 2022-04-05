using System;

namespace Skillbox
{
    class Arrays
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
                    // Задание 1. Случайная матрица
                    case "1":
                        {
                            Console.WriteLine("Введите количество строк в будущей матрице");
                            int lines = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите количество столбцов в будущей матрице");
                            int columns = Convert.ToInt32(Console.ReadLine());

                            int[, ] array = new int[lines, columns];
                            int summElements = 0;

                            Random rand = new Random();

                            for(int i = 0; i < lines; i++)
                            {
                                for(int j = 0; j < columns; j++)
                                {
                                    array[i, j] = rand.Next(10);
                                    summElements += array[i, j];

                                    Console.Write($"{array[i, j], 4}");

                                }
                                Console.WriteLine();
                            }

                            Console.WriteLine($"Сумма всех элементов этой матрицы: {summElements}" );

                        }
                        break;

                    // Задание 2. Наименьший элемент в последовательности
                    case "2":
                        {
                            Console.WriteLine("Введите длину последовательности");
                            int sequenceLength = Convert.ToInt32(Console.ReadLine());

                            int[] sequence = new int[sequenceLength];

                            for (int i = 0; i < sequenceLength; i++)
                            {
                                Console.WriteLine($"Введите целое число Nr.{i+1} (как положительные, так и отрицательные)");
                                sequence[i] = Convert.ToInt32(Console.ReadLine());
                            }

                            int minValue = sequence[0];

                            // int minValue = int.MaxValue
                            // for (int j = 0; j < sequenceLength; j++)

                            for (int j = 1; j < sequenceLength; j++)
                            {
                                if (sequence[j] < minValue) minValue = sequence[j];
                            }

                            Console.WriteLine($"Минимальное значение последовательности: {minValue}");

                        }
                        break;

                    // Задание 3. Игра «Угадай число»
                    case "3":
                        {
                            Console.WriteLine("Введите максимальное целое число диапазона");
                            int maxNumber = Convert.ToInt32(Console.ReadLine());

                            Random rand = new Random();

                            while (true)
                            {

                                int randomNumber = rand.Next(maxNumber);

                                Console.WriteLine("\n\nВведите загаданное программой случайное число");

                                string line = Console.ReadLine();

                                if (line.Length == 0) break;

                                int hiddenNumber = Convert.ToInt32(line);

                                if (hiddenNumber == randomNumber) Console.WriteLine("Угадали!");

                                if (hiddenNumber > randomNumber) Console.WriteLine("Ваше число больше загаданного");

                                if (hiddenNumber < randomNumber) Console.WriteLine("Ваше число меньше загаданного");

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

