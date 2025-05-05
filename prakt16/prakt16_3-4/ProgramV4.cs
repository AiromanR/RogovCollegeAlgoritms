using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace prakt16_1_v4_Rogov
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "test.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                List<(string Name, long Population)> countries = new List<(string Name, long Population)>();
                
                foreach(string line in lines)
                {
                    string[] parts = line.Split(' ');
                    countries.Add((parts[0], long.Parse(parts[1])));
                }

                Console.Write("Введите минимальную численность населения: ");
                long minPopulation = long.Parse(Console.ReadLine());
                List<(string Name, long Population)> filterCountr = countries
                    .Where(c => c.Population > minPopulation)
                    .OrderBy(c => c.Name.Length)
                    .ThenBy(c => c.Name).ToList();

                Console.WriteLine("\nУпорядоченный список стран");
                foreach(var country in filterCountr)
                {
                    Console.WriteLine($"{country.Name} {country.Population}");
                }
            }
            else Console.WriteLine("Файл не найден");
        }
    }
}
