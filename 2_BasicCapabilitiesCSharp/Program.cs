
#region Using
using System;
#endregion

namespace Skillbox
{
    class BasicCapabilitiesCSharp
    {
        static void Main(string[] args)
        {
            string fullName = "Иванов Иван Иванович";           // ФИО
            string eMail = "ivan@ivanov";                       // ФИО, эл.почта
            int age = 125;                                      // возраст
            float gradeProgramming = 75.3f;                     // оценка  по программированию
            float gradeMath = 99.95f;                           // оценка по математике
            float gradePhisics = 34.11f;                        // оценка по физике

            string taskNumber = "1";

            while (taskNumber == "1" || taskNumber == "2")
            {
                Console.Clear();
                Console.Write("Введите номер домашнего задания ('1' или '2'; другие - завершение проверки): ");

                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        {
                            Console.WriteLine($"Студент: {fullName}, возраст: {age}, эллектронный адрес: {eMail}.");
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                        {
                            var summGrades = gradeMath + gradePhisics + gradeProgramming;
                            var averageGrades = (double)summGrades / 3d;

                            var pattern = "Студент {0} набрал суииу баллов - {1} и получил средний балл {2: 0.000}";


                            Console.WriteLine(pattern,
                                                fullName,
                                                summGrades,
                                                averageGrades);
                            Console.ReadLine();

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