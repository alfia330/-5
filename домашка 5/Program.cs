
using System;

class Program
{
    static void Main()
    {
        Console.Write("текст");
        string text = Console.ReadLine() ?? "";

        string vowels = "аеёиоуыэюяАЕЁИОУЫЭЮЯaeiouyAEIOUY";
        int vowelCount = 0;
        int consonantCount = 0;

        foreach (char ch in text)
        {
            if (!char.IsLetter(ch)) continue;

            if (vowels.Contains(ch))
                vowelCount++;
            else
                consonantCount++;
        }

        Console.WriteLine($"Гл: {vowelCount}");
        Console.WriteLine($"Согл: {consonantCount}");
    }
}
