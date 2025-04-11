using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {

        string filePath = "students.txt";
        if (File.Exists(filePath))
        {
            Queue<string> successfulStudents = new Queue<string>();
            Queue<string> otherStudents = new Queue<string>();


            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(new[] { " " }, StringSplitOptions.None);
                // первые 4 это фио и группа, их пропускаем
                int[] grades = parts.Skip(4).Select(int.Parse).ToArray();

                if (grades.All(grade => grade >= 4))
                    successfulStudents.Enqueue(line);
                else
                    otherStudents.Enqueue(line);
            }

            Console.WriteLine("Студенты, успешно сдавшие сессию:");
            while (successfulStudents.Count > 0)
                Console.WriteLine(successfulStudents.Dequeue());

            Console.WriteLine("\nОстальные студенты:");
            while (otherStudents.Count > 0)
                Console.WriteLine(otherStudents.Dequeue());
        }
        else { 
            Console.WriteLine("Файл не обнаружен");
        }
    }
}