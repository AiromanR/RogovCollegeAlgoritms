using System.Text.RegularExpressions;

class Program
{
    static int Calculate(string formula)
    {
        if (int.TryParse(formula, out int result))
            return result;

        Match pMatch = Regex.Match(formula, @"p\(([^,]+),([^)]+)\)");
        if (pMatch.Success)
        {
            string a = pMatch.Groups[1].Value;
            string b = pMatch.Groups[2].Value;
            return (Calculate(a) + Calculate(b)) % 10;
        }

        Match mMatch = Regex.Match(formula, @"m\(([^,]+),([^)]+)\)");
        if (pMatch.Success)
        {
            string a = pMatch.Groups[1].Value;
            string b = pMatch.Groups[2].Value;
            return (Calculate(a) - Calculate(b) + 10) % 10; //+10 для избежания отрицательных значений
        }
        else
            return 0;
    }
    static void Main(string[] args)
    {
        Console.Write("Введите имя файла: ");
        string path = Console.ReadLine();
        string formula = File.ReadAllText(path);
        int result = Calculate(formula);
        Console.WriteLine($"{formula} = {result}");
        Console.ReadKey();
    }
}