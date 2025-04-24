using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace prakt16_2_Rogov
{
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string input = Console.ReadLine();
            string[] array = input.Split(' ');


            int digitCount = array.Sum(s => s.Count(char.IsDigit));
            var digits = input.Where(char.IsDigit).Distinct().ToList();
            Console.WriteLine("\nA) Количество цифр в массиве: {0}", digitCount);
            Console.WriteLine($"Уникальные цифры: {(digits.Any() ? string.Join(", ", digits) : "нет цифр")}\n");


            Console.WriteLine("B) Элементы до первого символа '/':");
            bool slashFound = false;
            foreach (var element in array)
            {
                if (element.Contains("/"))
                {
                    slashFound = true;
                    string partBeforeSlash = element.Substring(0, element.IndexOf('/'));
                    if (!string.IsNullOrEmpty(partBeforeSlash))
                    {
                        Console.WriteLine(partBeforeSlash);
                    }
                    break;
                }
                Console.WriteLine(element);
            }

            if (!slashFound)
            {
                Console.WriteLine("Символ '/' не найден в массиве.");
            }


            Console.WriteLine("\nC) Элементы после '/' с измененным регистром:");
            string[] afterSlashElements = input.Split('/')
                                              .Skip(1)
                                              .SelectMany(part => part.Split(' '))
                                              .Where(s => !string.IsNullOrEmpty(s))
                                              .ToArray();

            var processedElements = afterSlashElements.Select(s =>
                new string(s.Select(c => char.IsLetter(c) ?
                    (char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)) : c)
                .ToArray()));

            foreach (var element in processedElements)
            {
                Console.WriteLine(element);
            }

            // Запись в файл
            File.WriteAllLines("result.txt", processedElements);
            Console.WriteLine("\nРезультат записан в файл 'result.txt'");

            Console.ReadKey();
        }
    }
}
