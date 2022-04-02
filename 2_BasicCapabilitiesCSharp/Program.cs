
#region Using
using System;
#endregion

namespace BasicCapabilitiesCSharp
{ 
    class Program
    {
        static void Main(string[] args)
        {
            string fullName = "Иванов Иван Иванович";           // ФИО
            string eMail = "ivan@ivanov";                       // ФИО, эл.почта
            int age = 125;                                      // возраст
            float gradeProgramming = 75.3f;                     // оценка  по программированию
            float gradeMath = 99.95f;                           // оценка по математике
            float gradePhisics = 34.11f;                        // оценка по физике

            Console.Clear();
            Console.Write("Введите номер домашнего задания ('1' или '2'; другие - завершение проверки): ");

            Console.WriteLine($"Студент: {fullName}, возраст: {age}, эллектронный адрес: {eMail}.");
            Console.ReadKey();

            var summGrades = gradeMath + gradePhisics + gradeProgramming;
            var averageGrades = (double) summGrades / 3d;

            var pattern = "Студент {0} набрал суииу баллов - {1} и получил средний балл {2}";


            Console.WriteLine(pattern,
                                fullName,
                                summGrades,
                                averageGrades);
            Console.ReadLine();

            
        }
    }
}