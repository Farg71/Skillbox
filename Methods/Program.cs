using System;

namespace Skillbox
{
    class Methods
    {
        static void Main(string[] args)
        {
            string? taskNumber = "1";

            while (taskNumber == "1" || taskNumber == "2")
            {
                Console.Clear();
                Console.Write("Введите номер домашнего задания ('1' или '2'; другие - завершение проверки): ");

                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    // Задание 1. Метод разделения строки на слова
                    case "1":
                        {
                            string inputPhrase = SentencesReading();                // Ввод предложения

                            string[] words = SplittingStringIntoWords(inputPhrase); // Разделение предложения на слова

                            WritesWords(words);                                     // Печать каждого слова в новой строке

                        }
                        break;

                    // Задание 2. Перестановка слов в предложении
                    case "2":
                        {
                            string inputPhrase = SentencesReading();                // Ввод предложения

                            string outputPhrase = ReversWords(inputPhrase);         // Получение предложения в обратной последовательности

                            Console.WriteLine($"Предложение а обратной последовательности:\n{outputPhrase}");
                        }
                        break;

                    default:

                        Console.WriteLine("Нет такого задания!! :)");

                        break;
                }

                Console.ReadLine();

            }
        }

        private static string ReversWords(string inputPhrase)
        {
            string resultString = "";

            string[] words = SplittingStringIntoWords(inputPhrase); // Разделение предложения на слова

            for(int i = words.Length -1; i >=0; i--)
            {
                resultString += words[i] + " ";
            }

            return resultString;
        }

        private static string SentencesReading()
        {
            Console.WriteLine("\n\t\tВведите предложение");

            string inputPhrase = Console.ReadLine();

            return inputPhrase;
        }

        private static void WritesWords(string[] words)
        {
            Console.WriteLine("\n\t\tПолученные слова:\n\n");

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        private static string[] SplittingStringIntoWords(string? inputPhrase)
        {
            string[] words = inputPhrase.Split(' ');

            return words;
        }
    }
}

